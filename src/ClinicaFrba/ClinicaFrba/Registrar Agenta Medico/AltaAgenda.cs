using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Clases;
using System.Data.SqlClient;
namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class AltaAgenda : Form
    {
        public string id_usuario { set; get; }
        public Profesional profesional { set; get; }
        public AltaAgenda(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
        }

        public void AltaAgenda_Load(object sender, EventArgs e)
        {
           SeleccionarProfesional formulario = new SeleccionarProfesional();
           formulario.ShowDialog();
           profesional = (Profesional)((DataGridView)formulario.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
           while(Profesional.tieneAgenda(profesional.matricula))
           {
               MessageBox.Show("El profesional seleccionado ya tiene una agenda.", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               formulario.ShowDialog();
               profesional = (Profesional)((DataGridView)formulario.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
           }
           List<Especialidad> especialidades = Especialidad.especialidadesPorProfesional(profesional.matricula);
           label_agenda.Text = "Agenda de: " + profesional.nombre+" " + profesional.apellido;
          l_especialidad.Items.AddRange(especialidades.ToArray());
          m_especialidad.Items.AddRange(especialidades.ToArray());
          x_especialidad.Items.AddRange(especialidades.ToArray());
          j_especialidad.Items.AddRange(especialidades.ToArray());
          v_especialidad.Items.AddRange(especialidades.ToArray());
          s_especialidad.Items.AddRange(especialidades.ToArray());
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            List<Agenda_Diaria> agenda = crearAgenda();
            Rango_Atencion rango = new Rango_Atencion();
            rango.matricula = profesional.matricula;
            rango.fecha_desde = franja_inicio.Value;
            rango.fecha_hasta = franja_fin.Value;
            Errores errores = new Errores();
            if(!rango.esValido())
            {
                errores.agregarError("La fecha de inicio de la franja debe ser anterior a la de fin.");
            }
            if(rango.fecha_desde< DateTime.Today || rango.fecha_hasta<DateTime.Today)
            {
                errores.agregarError("Las fechas de inicio y fin de la franja deben ser posteriores al dia de hoy.");
            }
            if(agenda.Any(elem => !elem.esValida()))
            {
                errores.agregarError("La hora de fin del turno no puede ser anterior a la de inicio.");
            }
            if (agenda.Sum(elem => elem.horasDiarias()) > 48)
            {
                errores.agregarError("Esta prohibido trabajar mas de 48hs semanales. Por favor disminuya sus horas diarias.");
            }
            if ((check_lunes.Checked && l_especialidad.SelectedItem == null) || (check_martes.Checked && m_especialidad.SelectedItem == null) || (check_miercoles.Checked && x_especialidad.SelectedItem == null) || (check_jueves.Checked && j_especialidad.SelectedItem == null) || (check_viernes.Checked && v_especialidad.SelectedItem == null) || (check_sabados.Checked && s_especialidad.SelectedItem == null))
            {
                errores.agregarError("La especialidad no puede ser nula.");
            }
            if (errores.huboError())
            {

                MessageBox.Show(errores.stringErrores(), "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                insert(agenda,rango);
                MessageBox.Show("Se ha insertado la agenda correctamente.", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Close();
        }

        #region checkeos campos
        //Checkeos lunes
        private void l_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if(l_desde_h.Value==20) l_desde_m.Value=0;
        }

        private void l_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (l_desde_h.Value == 20) l_desde_m.Value = 0;
        }

        private void l_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (l_hasta_h.Value == 20) l_hasta_m.Value = 0;
        }

        private void l_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (l_hasta_h.Value == 20) l_hasta_m.Value = 0;
        }

        private void check_lunes_CheckedChanged(object sender, EventArgs e)
        {
            l_hasta_h.Enabled = check_lunes.Checked;
            l_hasta_m.Enabled = check_lunes.Checked;
            l_desde_h.Enabled = check_lunes.Checked;
            l_desde_m.Enabled = check_lunes.Checked;
            l_especialidad.Enabled = check_lunes.Checked;

        }
        //Checkeos Martes
        private void m_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if (m_desde_h.Value == 20) l_desde_m.Value = 0;
        }

        private void m_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (m_desde_h.Value == 20) m_desde_m.Value = 0;
        }

        private void m_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (m_hasta_h.Value == 20) m_hasta_m.Value = 0;
        }

        private void m_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (m_hasta_h.Value == 20) m_hasta_m.Value = 0;
        }

        private void check_martes_CheckedChanged(object sender, EventArgs e)
        {
            m_hasta_h.Enabled = check_martes.Checked;
            m_hasta_m.Enabled = check_martes.Checked;
            m_desde_h.Enabled = check_martes.Checked;
            m_desde_m.Enabled = check_martes.Checked;
            m_especialidad.Enabled = check_martes.Checked;

        }
        //Checkeos miercoles
        private void x_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if (x_desde_h.Value == 20) l_desde_m.Value = 0;
        }

        private void x_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (x_desde_h.Value == 20) x_desde_m.Value = 0;
        }

        private void x_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (x_hasta_h.Value == 20) x_hasta_m.Value = 0;
        }

        private void x_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (x_hasta_h.Value == 20) x_hasta_m.Value = 0;
        }

        private void check_miercoles_CheckedChanged(object sender, EventArgs e)
        {
            x_hasta_h.Enabled = check_miercoles.Checked;
            x_hasta_m.Enabled = check_miercoles.Checked;
            x_desde_h.Enabled = check_miercoles.Checked;
            x_desde_m.Enabled = check_miercoles.Checked;
            x_especialidad.Enabled = check_miercoles.Checked;

        }
        //Checkeos jueves
        private void j_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if (j_desde_h.Value == 20) l_desde_m.Value = 0;
        }

        private void j_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (j_desde_h.Value == 20) j_desde_m.Value = 0;
        }

        private void j_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (j_hasta_h.Value == 20) j_hasta_m.Value = 0;
        }

        private void j_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (j_hasta_h.Value == 20) j_hasta_m.Value = 0;
        }

        private void check_jueves_CheckedChanged(object sender, EventArgs e)
        {
            j_hasta_h.Enabled = check_jueves.Checked;
            j_hasta_m.Enabled = check_jueves.Checked;
            j_desde_h.Enabled = check_jueves.Checked;
            j_desde_m.Enabled = check_jueves.Checked;
            j_especialidad.Enabled = check_jueves.Checked;

        }
        //Checkeos viernes
        private void v_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if (v_desde_h.Value == 20) l_desde_m.Value = 0;
        }

        private void v_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (v_desde_h.Value == 20) v_desde_m.Value = 0;
        }

        private void v_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (v_hasta_h.Value == 20) v_hasta_m.Value = 0;
        }

        private void v_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (v_hasta_h.Value == 20) v_hasta_m.Value = 0;
        }

        private void check_viernes_CheckedChanged(object sender, EventArgs e)
        {
            v_hasta_h.Enabled = check_viernes.Checked;
            v_hasta_m.Enabled = check_viernes.Checked;
            v_desde_h.Enabled = check_viernes.Checked;
            v_desde_m.Enabled = check_viernes.Checked;
            v_especialidad.Enabled = check_viernes.Checked;

        }
        //Checkeos sabados
        private void s_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if (s_desde_h.Value == 20) l_desde_m.Value = 0;
        }

        private void s_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (s_desde_h.Value == 20) s_desde_m.Value = 0;
        }

        private void s_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (s_hasta_h.Value == 15) s_hasta_m.Value = 0;
        }

        private void s_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (s_hasta_h.Value == 15) s_hasta_m.Value = 0;
        }

        private void check_sabados_CheckedChanged(object sender, EventArgs e)
        {
            s_hasta_h.Enabled = check_sabados.Checked;
            s_hasta_m.Enabled = check_sabados.Checked;
            s_desde_h.Enabled = check_sabados.Checked;
            s_desde_m.Enabled = check_sabados.Checked;
            s_especialidad.Enabled = check_sabados.Checked;

        }
        #endregion

        private List<Agenda_Diaria> crearAgenda()
        {
            List<Agenda_Diaria> disponibilidades = new List<Agenda_Diaria>();
            if (check_lunes.Checked && l_especialidad.SelectedItem!=null)
            {
                disponibilidades.Add(new Agenda_Diaria(1, profesional.matricula, (int)l_desde_h.Value, (int)l_desde_m.Value, (int)l_hasta_h.Value, (int)l_hasta_m.Value, ((Especialidad)l_especialidad.SelectedItem).id_especialidad));

            }
            if (check_martes.Checked && m_especialidad.SelectedItem != null)
            {
                disponibilidades.Add(new Agenda_Diaria(2, profesional.matricula, (int)m_desde_h.Value, (int)m_desde_m.Value, (int)m_hasta_h.Value, (int)m_hasta_m.Value, ((Especialidad)m_especialidad.SelectedItem).id_especialidad));

            }
            if (check_miercoles.Checked && x_especialidad.SelectedItem != null)
            {
                disponibilidades.Add(new Agenda_Diaria(3, profesional.matricula, (int)x_desde_h.Value, (int)x_desde_m.Value, (int)x_hasta_h.Value, (int)x_hasta_m.Value, ((Especialidad)x_especialidad.SelectedItem).id_especialidad));

            }
            if (check_jueves.Checked && j_especialidad.SelectedItem != null)
            {
                disponibilidades.Add(new Agenda_Diaria(4, profesional.matricula, (int)j_desde_h.Value, (int)j_desde_m.Value, (int)j_hasta_h.Value, (int)j_hasta_m.Value, ((Especialidad)j_especialidad.SelectedItem).id_especialidad));

            }
            if (check_viernes.Checked && v_especialidad.SelectedItem != null)
            {
                disponibilidades.Add(new Agenda_Diaria(5, profesional.matricula, (int)v_desde_h.Value, (int)v_desde_m.Value, (int)v_hasta_h.Value, (int)v_hasta_m.Value, ((Especialidad)v_especialidad.SelectedItem).id_especialidad));

            }
            if (check_sabados.Checked && s_especialidad.SelectedItem != null)
            {
                disponibilidades.Add(new Agenda_Diaria(6, profesional.matricula, (int)s_desde_h.Value, (int)s_desde_m.Value, (int)s_hasta_h.Value, (int)s_hasta_m.Value, ((Especialidad)s_especialidad.SelectedItem).id_especialidad));

            }
            return disponibilidades;
        }
        private void insert(List<Agenda_Diaria> agenda,Rango_Atencion rango)
        {   
            agenda.ForEach(elem => {
              SqlCommand insertar = new SqlCommand("INSERT INTO ELIMINAR_CAR.Agenda_Diaria (dia,matricula,hora_desde,hora_hasta,id_especialidad) VALUES (@dia,@matricula,@hora_desde,@hora_hasta,@id_especialidad)",DBConnector.ObtenerConexion());
              insertar.Parameters.Add("@dia", SqlDbType.Int).Value = (int) elem.dia;
              insertar.Parameters.Add("@matricula", SqlDbType.BigInt).Value = elem.matricula;
              //string format = "yyyy-MM-dd HH:MM:ss";
              insertar.Parameters.Add("@hora_desde", SqlDbType.DateTime).Value = elem.hora_desde;
              insertar.Parameters.Add("@hora_hasta", SqlDbType.DateTime).Value = elem.hora_hasta;
              insertar.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = elem.id_especialidad;
              insertar.ExecuteNonQuery();
            });
            SqlCommand insertarRango = new SqlCommand("INSERT INTO ELIMINAR_CAR.Rango_Atencion (matricula,fecha_desde,fecha_hasta) VALUES (@matricula,@fecha_desde,@fecha_hasta)", DBConnector.ObtenerConexion());
            insertarRango.Parameters.Add("@matricula", SqlDbType.BigInt).Value = rango.matricula;
            insertarRango.Parameters.Add("@fecha_desde", SqlDbType.DateTime).Value = rango.fecha_desde;
            insertarRango.Parameters.Add("@fecha_hasta", SqlDbType.DateTime).Value = rango.fecha_hasta;
            insertarRango.ExecuteNonQuery();
        }

    }
}
