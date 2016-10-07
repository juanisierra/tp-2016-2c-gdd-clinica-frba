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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class RegistroResultado : Form
    {   public String id_usuario {set;get;}
        public int id_rol {set;get;}
        public Int64 matricula { set; get; }
        List<Turno> turnos { set; get; }
        public RegistroResultado(String id_usuario,int id_rol)
        {
            InitializeComponent();
            matricula = Profesional.matriculaPorUsuario(id_usuario);
            dt_dia.MinDate = DateTime.Today.Subtract(new TimeSpan(24,0,0));
            ActualizarHora();
        }

        private void RegistroResultado_Load(object sender, EventArgs e)
        {
            if (matricula == -1)
            {
                MessageBox.Show("Error, el usuario con el que ingresó no posee matricula.", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                turnos = Turno.turnosDiagnosticablesPorProfesional(matricula, DateTime.Today);
                dgv_turno.DataSource = turnos;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Errores errores = new Errores();
            if (dt_dia.Value.DayOfWeek == DayOfWeek.Sunday) errores.agregarError("No se puede realizar una consulta un domingo");
            if (tb_diagnostico.TextLength == 0) errores.agregarError("El diagnostico no puede ser nulo.");
            if (tb_sintomas.TextLength == 0) errores.agregarError("Los sintomas no pueden ser nulos.");
            if(errores.huboError()) {
                MessageBox.Show(errores.stringErrores(), "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                SqlCommand insertar = new SqlCommand("ELIMINAR_CAR.registrarConsulta", DBConnector.ObtenerConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dt_dia.Value.Date.Add(dt_hora.Value.TimeOfDay);
                insertar.Parameters.Add("@turno", SqlDbType.BigInt).Value = ((Turno)dgv_turno.CurrentRow.DataBoundItem).id_turno;
                insertar.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = tb_sintomas.Text;
                insertar.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = tb_diagnostico.Text;
                insertar.ExecuteNonQuery();
                MessageBox.Show("Atencion registrada Correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarHora();
                ActualizarTurnos();
            }
        }

        private void dt_dia_ValueChanged(object sender, EventArgs e)
        {
            ActualizarHora();
        }
        private void ActualizarHora()
        {
            if (dt_dia.Value.DayOfWeek == DayOfWeek.Saturday) //Si es sabado abre de 10 a 15
            {
                dt_hora.MinDate = new DateTime(1900, 1, 1, 10, 0, 0);
                dt_hora.MaxDate = new DateTime(1900, 1, 1, 15, 0, 0);
            }
            else
            {
                dt_hora.MinDate = new DateTime(1900, 1, 1, 7, 0, 0);
                dt_hora.MaxDate = new DateTime(1900, 1, 1, 20, 0, 0);
            }
        }
        private void ActualizarTurnos()
        {
            dgv_turno.DataSource = null;
            turnos = Turno.turnosDiagnosticablesPorProfesional(matricula, DateTime.Today);
            dgv_turno.DataSource = turnos;
        }
    }
}
