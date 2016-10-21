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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class RegistroLlegada : Form
    {     public Profesional profesionalElegido {set;get;}
          public int id_rol { set; get; }
          public String id_usuario { set; get; }
          public Turno turnoElegido { set; get; }
        public RegistroLlegada(String id_usuario,int id_rol)
        {
            InitializeComponent();
            this.id_rol = id_rol;
            this.id_usuario = id_usuario;
        }

        private void RegistroLlegada_Load(object sender, EventArgs e)
        {
            if (id_rol != 2 && id_rol != 4)
            {
                MessageBox.Show("Error: El usuario con el que ha ingresado no puede registrar llegadas a la clinica.", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                SeleccionarProfesionalPorEspecialidad formulario = new SeleccionarProfesionalPorEspecialidad();
                formulario.ShowDialog();
                if (formulario.fueCerradoPorUsuario) this.Close();
                else
                {
                    profesionalElegido = (Profesional)((DataGridView)formulario.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
                    List<Turno> turnosProfesional;
                    turnosProfesional = Turno.turnosDelDiaPorProfesional(profesionalElegido.matricula, DateTime.Today);
                    if (((Especialidad)((ComboBox)formulario.Controls["cb_especialidad"]).SelectedItem).id_especialidad != -1) //Se selecciono una especialidad
                    {
                        turnosProfesional.RemoveAll(turno => turno.id_especialidad != ((Especialidad)((ComboBox)formulario.Controls["cb_especialidad"]).SelectedItem).id_especialidad); //Sacamos los turnos de otras especialidades
                    }
                    turnosProfesional.RemoveAll(turno => turno.activo == false);
                    turnosProfesional.RemoveAll(turno => turno.momento_llegada != null);
                    dgv_turno.DataSource = turnosProfesional;
                }
            }
        }
        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            turnoElegido = ((Turno)dgv_turno.CurrentRow.DataBoundItem);
            SeleccionarBono form = new SeleccionarBono(turnoElegido.id_afiliado);
            form.ShowDialog();
            if (form.fueCerradoPorUsuario) this.Close();
            else if (((ComboBox)form.Controls["cb_id_bono"]).SelectedItem!=null)
            {
                SqlCommand insertar = new SqlCommand("ELIMINAR_CAR.registrarLlegada", DBConnector.ObtenerConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@id_afiliado", SqlDbType.BigInt).Value = turnoElegido.id_afiliado;
                insertar.Parameters.Add("@id_bono", SqlDbType.BigInt).Value = (Int64)((ComboBox)form.Controls["cb_id_bono"]).SelectedItem;
                insertar.Parameters.Add("@id_turno", SqlDbType.BigInt).Value = turnoElegido.id_turno;
                insertar.Parameters.Add("@fecha_llegada", SqlDbType.DateTime).Value = DateTime.Now;
                insertar.ExecuteNonQuery();
                MessageBox.Show("Se registro correctamente la llegada", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

    }
}
