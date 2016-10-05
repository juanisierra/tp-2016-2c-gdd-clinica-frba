using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class PedirTurno : Form
    {
        public String id_usuario { set; get; }
        public int id_rol { set; get; }
        public Profesional profesionalElegido { set; get; }
        public Especialidad especialidadElegida { set; get; }
        public List<DateTime> diasRango { set; get; }
        public List<Agenda_Diaria> agenda { set; get; }
        public List<TimeSpan> horarios { set; get; }
        public PedirTurno(String id_usuario,int id_rol)
        {
            InitializeComponent();
            this.id_rol = id_rol;
            this.id_usuario = id_usuario;
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            SeleccionarProfesionalPorEspecialidad formularioProf = new SeleccionarProfesionalPorEspecialidad();
            formularioProf.ShowDialog();
            profesionalElegido = (Profesional)((DataGridView)formularioProf.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
            especialidadElegida = (Especialidad)((ComboBox)formularioProf.Controls["cb_especialidad"]).SelectedItem;
            label_nombre_profesional.Text = "Turnos disponibles con el Dr./Dra. " + profesionalElegido.apellido + ", " + profesionalElegido.nombre;
            label_especialidad.Text = "Especialidad: " + especialidadElegida.descripcion;
            CalcularDiasRango();
            cb_dia.DataSource = diasRango;
            agenda = Agenda_Diaria.getAgendaProfesional(profesionalElegido.matricula, especialidadElegida.id_especialidad);
            horarios = new List<TimeSpan>();
            if(cb_dia.SelectedItem!=null) {
                CalcularHorarios();
                }
            
            
            }
        public void CalcularDiasRango()
        {
            Rango_Atencion rango = Rango_Atencion.rangoPorProfesional(profesionalElegido.matricula);
            List<DayOfWeek> diasQueTrabaja = profesionalElegido.diasQueTrabajaNormalmente(especialidadElegida.id_especialidad);
            
            if (rango != null)
            {
                diasRango = Rango_Atencion.generarDiasRango(rango);
            }
            else
            {
                diasRango = new List<DateTime>();
            }
            diasRango.RemoveAll(dia => !diasQueTrabaja.Contains(dia.DayOfWeek)); //Remuevo los dias que no trabaja
            List<Cancelacion_Profesional> cancelaciones = Cancelacion_Profesional.cancelacionesPorProfesionalYEspecialidad(profesionalElegido.matricula, especialidadElegida.id_especialidad);
            List<DateTime> diasCancelados = new List<DateTime>();
            cancelaciones.ForEach(c => diasCancelados.AddRange(c.diasCancelados())); //Agrego los dias que se cancelan
            diasRango.RemoveAll(elem => diasCancelados.Contains(elem));
            diasRango = diasRango.Distinct().OrderBy(d => d.Year).ThenBy(d => d.Month).ThenBy(d => d.Day).ToList<DateTime>();
        }
        public void CalcularHorarios()
        {   Agenda_Diaria dia = null;
            if(cb_dia.SelectedItem!=null && agenda!=null)  dia = agenda.Find(elem => elem.dia == (((DateTime)cb_dia.SelectedItem).DayOfWeek));
            if (dia != null) horarios = dia.generarHorarios();
            List<Turno> turnos = Turno.turnosPorProfesionalYEspecialidad(profesionalElegido.matricula, especialidadElegida.id_especialidad);
            List<TimeSpan> horariosOcupados = turnos.FindAll(t => t.activo && t.fecha_estipulada.Date == ((DateTime)cb_dia.SelectedItem).Date).Select(t => t.fecha_estipulada.TimeOfDay).ToList<TimeSpan>();
           if(horarios!=null) horarios.RemoveAll(horario => horariosOcupados.Contains(horario));
            cb_hora.DataSource = horarios;
        }

        private void cb_dia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularHorarios();
        }
    }
}
