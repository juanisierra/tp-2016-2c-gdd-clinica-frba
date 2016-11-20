using ClinicaFrba.Abm_Especialidades_Medicas;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
            this.diasRango = new List<DateTime>();
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
               if (!formularioProf.fueCerradoPorUsuario)
               {
                   if (especialidadElegida.id_especialidad == -1) //Todavia no eligio especialidad
                   {
                       SeleccionarEspecialidad formularioEsp = new SeleccionarEspecialidad(Especialidad.especialidadesPorProfesional(profesionalElegido.matricula));
                       formularioEsp.ShowDialog();
                       if (formularioEsp.fueCerradoPorUsuario) this.Close(); //El usuario se va
                       else
                       {
                           especialidadElegida =(Especialidad) ((ComboBox)formularioEsp.Controls["cb_especialidad"]).SelectedItem;
                       }
                   }
                   label_nombre_profesional.Text = "Turnos disponibles con el Dr./Dra. " + profesionalElegido.apellido + ", " + profesionalElegido.nombre;
                   label_especialidad.Text = "Especialidad: " + especialidadElegida.descripcion;
                   CalcularDiasRango();
                   actualizarAnios();
                   actualizarDias();
                   actualizarMeses();
                   
                  horarios = new List<TimeSpan>();
                   if (cb_anio.SelectedItem != null &&cb_mes.SelectedItem!=null && cb_dia_mes.SelectedItem != null)
                   {
                       CalcularHorarios();
                   }
               } else {
                   this.Close();
               }
            }
            }
        public void CalcularDiasRango()
        {
            List<Rango_Atencion> rangos = Rango_Atencion.rangosPorProfesional(profesionalElegido.matricula);
            if (rangos.Count > 0)
            {       
                    rangos.ForEach(r => diasRango.AddRange(Rango_Atencion.generarDiasQueTrabajaRango(profesionalElegido,especialidadElegida.id_especialidad,r)));
            }
            else
            {
                diasRango = new List<DateTime>();
            }
            diasRango.RemoveAll(dia => dia.Year<2016); //Saca los dias anteriores a 2016 para que no se pueda pedir turno ahi.
            List<Cancelacion_Profesional> cancelaciones = Cancelacion_Profesional.cancelacionesPorProfesional(profesionalElegido.matricula);
            List<DateTime> diasCancelados = new List<DateTime>();
            cancelaciones.ForEach(c => diasCancelados.AddRange(c.diasCancelados())); //Agrego los dias que se cancelan
            diasRango.RemoveAll(elem => diasCancelados.Contains(elem));
            diasRango = diasRango.Distinct().OrderBy(d => d.Year).ThenBy(d => d.Month).ThenBy(d => d.Day).ToList<DateTime>();
        }
        public void actualizarAnios()
        {
            List<int> anios = new List<int>();
            anios.AddRange(diasRango.Select(dia => dia.Year).Distinct());
            cb_anio.DataSource = anios;
        }
        public void actualizarMeses()
        {
            if (cb_anio.SelectedItem != null)
            {
                List<meses> mesesConEnum = new List<meses>();
                diasRango.FindAll(elem => elem.Year == (int)cb_anio.SelectedItem).GroupBy(elem => elem.Month).Select(e => e.First()).ToList<DateTime>().ForEach(elem => mesesConEnum.Add((meses)elem.Month-1));
                cb_mes.DataSource = mesesConEnum;
            }
            else cb_mes.DataSource = null;
        }
        public void actualizarDias()
        {
            if (cb_mes.SelectedItem != null)
            {
                List<DateTime> dias = new List<DateTime>();
                diasRango.FindAll(elem => elem.Year == (int)cb_anio.SelectedItem && elem.Month == (int)cb_mes.SelectedItem+1).ForEach(fecha => dias.Add(fecha));
                cb_dia_mes.DataSource = dias;
            }
            else cb_dia_mes.DataSource = null;
        }
        public void actualizarAgenda()
        {
            agenda = Agenda_Diaria.getAgendaProfesional(profesionalElegido.matricula, especialidadElegida.id_especialidad, Rango_Atencion.rangoPorDia(profesionalElegido.matricula, especialidadElegida.id_especialidad, (DateTime)cb_dia_mes.SelectedItem));
        }
        public void CalcularHorarios()
        {
            actualizarAgenda();
            cb_hora.DataSource = null;
            Agenda_Diaria dia = null;
            if (cb_anio.SelectedItem != null && cb_mes.SelectedItem != null && cb_dia_mes.SelectedItem != null && agenda != null) dia = agenda.Find(elem => elem.dia == (((DateTime) cb_dia_mes.SelectedItem).DayOfWeek));
            if (dia != null)
            {
                horarios = dia.generarHorarios(); //Genera todos los horarios del dia
                if (((DateTime)cb_dia_mes.SelectedItem).Date == ClinicaFrba.Utils.Fechas.getCurrentDateTime().Date.Date) //Son turnos para hoy, filtrar horarios que pasaron
                {
                    horarios.RemoveAll(horario => (horario < ClinicaFrba.Utils.Fechas.getCurrentDateTime().TimeOfDay));
                }
            }
            List<Turno> turnos = Turno.turnosFuturosPorProfesionalYEspecialidad(profesionalElegido.matricula, especialidadElegida.id_especialidad);
            List<TimeSpan> horariosOcupados = turnos.FindAll(t => t.activo && t.fecha_estipulada.Date == ((DateTime)cb_dia_mes.SelectedItem).Date).Select(t => t.fecha_estipulada.TimeOfDay).ToList<TimeSpan>();
           // tantes.Text = horarios.Count().ToString();
            //tacancelar.Text = horariosOcupados.Count().ToString();
            if(horarios!=null) horarios.RemoveAll(horario => horariosOcupados.Contains(horario));
            //tdespues.Text = horarios.Count().ToString();
            cb_hora.DataSource = horarios;
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Errores errores = new Errores();
            if (cb_dia_mes.SelectedItem == null) errores.agregarError("El campo dia no puede ser nulo.");
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
            insertarTurno.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = ((DateTime)cb_dia_mes.SelectedItem).Add(((TimeSpan)cb_hora.SelectedItem));
            insertarTurno.Parameters.Add(new SqlParameter("@matricula", SqlDbType.BigInt)).Value = profesionalElegido.matricula;
            insertarTurno.Parameters.Add(new SqlParameter("@id_afiliado", SqlDbType.BigInt)).Value = afiliado.idAfiliado;
            insertarTurno.Parameters.Add(new SqlParameter("@id_especialidad", SqlDbType.Int)).Value = especialidadElegida.id_especialidad;
            int filasAfectadas = insertarTurno.ExecuteNonQuery();
            if (filasAfectadas == 1) return true;
            else return false;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarMeses();
        }

        private void cb_dia_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularHorarios();
        }

        private void cb_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarDias();
        }
        
    }
}
