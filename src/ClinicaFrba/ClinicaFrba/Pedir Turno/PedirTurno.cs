using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public Afiliado afiliado { set; get; }
        public Boolean cerrar { set; get; }
        public PedirTurno(String id_usuario,int id_rol)
        {
            InitializeComponent();
            this.id_rol = id_rol;
            this.id_usuario = id_usuario;
            this.cerrar = false;
        }

        private void PedirTurno_Load(object sender, EventArgs e)
        {
            if (id_rol == 1) //Es afilliado
            {
                Int64 id_afiliado = Afiliado.getIdAfiliadoPorUsuario(id_usuario);
                if (id_afiliado == -1) //No tiene id_afiliado
                {
                    MessageBox.Show("Error, el usuario con el que se ingresó tiene rol de Afiliado pero no tiene id_afiliado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cerrar = true;
                    this.Close();    
                }
                afiliado = Afiliado.getAfiliadoPorID(id_afiliado);
            }
            else
            {
                MessageBox.Show("Error, el usuario con el que se ingresó no tiene rol de Afiliado, no deberia poder ver esta funcionalidad.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cerrar = true;
                this.Close();
                
            }
            if (cerrar == false)
            {
                SeleccionarProfesionalPorEspecialidad formularioProf = new SeleccionarProfesionalPorEspecialidad();
                formularioProf.ShowDialog();
                profesionalElegido = (Profesional)((DataGridView)formularioProf.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
                especialidadElegida = (Especialidad)((ComboBox)formularioProf.Controls["cb_especialidad"]).SelectedItem;
                label_nombre_profesional.Text = "Turnos disponibles con el Dr./Dra. " + profesionalElegido.apellido + ", " + profesionalElegido.nombre;
                label_especialidad.Text = "Especialidad: " + especialidadElegida.descripcion;
                cb_dia.DataSource = null;
                CalcularDiasRango();
                cb_dia.DataSource = diasRango;
                agenda = Agenda_Diaria.getAgendaProfesional(profesionalElegido.matricula, especialidadElegida.id_especialidad);
                horarios = new List<TimeSpan>();
                if (cb_dia.SelectedItem != null)
                {
                    CalcularHorarios();
                }

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
        {
            cb_hora.DataSource = null;
            Agenda_Diaria dia = null;
            if(cb_dia.SelectedItem!=null && agenda!=null)  dia = agenda.Find(elem => elem.dia == (((DateTime)cb_dia.SelectedItem).DayOfWeek));
            if (dia != null)
            {
                horarios = dia.generarHorarios(); //Genera todos los horarios del dia
                if (((DateTime)cb_dia.SelectedItem).Date == DateTime.Today.Date) //Son turnos para hoy, filtrar horarios que pasaron
                {
                    horarios.RemoveAll(horario => (horario < DateTime.Now.TimeOfDay));
                }
            }
            List<Turno> turnos = Turno.turnosPorProfesionalYEspecialidad(profesionalElegido.matricula, especialidadElegida.id_especialidad);
            List<TimeSpan> horariosOcupados = turnos.FindAll(t => t.activo && t.fecha_estipulada.Date == ((DateTime)cb_dia.SelectedItem).Date).Select(t => t.fecha_estipulada.TimeOfDay).ToList<TimeSpan>();
           // tantes.Text = horarios.Count().ToString();
            //tacancelar.Text = horariosOcupados.Count().ToString();
            if(horarios!=null) horarios.RemoveAll(horario => horariosOcupados.Contains(horario));
            //tdespues.Text = horarios.Count().ToString();
            cb_hora.DataSource = horarios;
        }

        private void cb_dia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularHorarios();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Errores errores = new Errores();
            if (cb_dia.SelectedItem == null) errores.agregarError("El campo dia no puede ser nulo.");
            if (cb_hora.SelectedItem == null) errores.agregarError("El campo hora no puede ser nulo.");
            if (errores.huboError())
            {
                MessageBox.Show(errores.stringErrores(), "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!pedirTurno()) MessageBox.Show("No se pudo agregar el turno", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Turno agregado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cerrar = true;
                this.Close();
                
            }
        }
        private Boolean pedirTurno()
        {
            SqlCommand insertarTurno = new SqlCommand("ELIMINAR_CAR.insertarNuevoTurno", DBConnector.ObtenerConexion());
            insertarTurno.CommandType = CommandType.StoredProcedure;
            insertarTurno.Parameters.Add(new SqlParameter("@fecha",SqlDbType.DateTime)).Value = ((DateTime) cb_dia.SelectedItem).Add(((TimeSpan) cb_hora.SelectedItem));
            insertarTurno.Parameters.Add(new SqlParameter("@matricula", SqlDbType.BigInt)).Value = profesionalElegido.matricula;
            insertarTurno.Parameters.Add(new SqlParameter("@id_afiliado", SqlDbType.BigInt)).Value = afiliado.idAfiliado;
            insertarTurno.Parameters.Add(new SqlParameter("@id_especialidad", SqlDbType.Int)).Value = especialidadElegida.id_especialidad;
            int filasAfectadas = insertarTurno.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            else return false;
        }
        
    }
}
