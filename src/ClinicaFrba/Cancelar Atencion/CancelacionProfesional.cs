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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelacionProfesional : Form
    {
        private string id_usuario { set; get; }
        private int id_rol { set; get; }
        private Int64 matricula { set; get; }
        public Rango_Atencion rango { set; get; }

        public CancelacionProfesional(string id_usuario, int id_rol)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
            dtp_desde.Value = DateTime.Today;
            dtp_hasta.Value = DateTime.Today;
        }

        private void CancelacionProfesional_Load(object sender, EventArgs e)
        {
            matricula = Profesional.matriculaPorUsuario(id_usuario);
            if (matricula == -1)
            {
                MessageBox.Show("Error, el profesional con el que ingresó no cuenta con numero de matricula.", "Clinica-FRBA Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (Rango_Atencion.rangoPorProfesional(matricula) == null)
            {
                MessageBox.Show("Error, el profesional no tiene establecida una agenda.", "Clinica-FRBA Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                rango = Rango_Atencion.rangoPorProfesional(matricula);
                if(rango.fecha_desde<= DateTime.Today.Date) dtp_desde.MinDate = DateTime.Today.AddDays(1);
                else dtp_desde.MinDate = rango.fecha_desde;
                if (rango.fecha_hasta < dtp_desde.MinDate)
                {
                    dtp_desde.Enabled = false;
                    dtp_hasta.Enabled = false;
                    btn_cancelar.Enabled = false;
                    tb_motivo.Enabled = false;
                    MessageBox.Show("No hay ninguna franja para cancelar.", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    dtp_desde.MaxDate = rango.fecha_hasta;
                    dtp_hasta.MaxDate = rango.fecha_hasta;
                }
                
                if(rango.fecha_desde<= DateTime.Today.Date) dtp_hasta.MinDate = DateTime.Today.AddDays(1);
                else dtp_hasta.MinDate = rango.fecha_desde;
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Errores errores = new Errores();
            if (dtp_hasta.Value < dtp_desde.Value) errores.agregarError("La fecha final de la franja debe ser anterior a la inicial.");
            if (tb_motivo.TextLength == 0) errores.agregarError("Debe escribir un motivo de cancelacion");
            if (errores.huboError())MessageBox.Show(errores.stringErrores(),"Clinica-FRBA ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                SqlCommand cancelar = new SqlCommand("ELIMINAR_CAR.cancelarTurnoProfesional", DBConnector.ObtenerConexion());
                cancelar.CommandType = CommandType.StoredProcedure;
                cancelar.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
                cancelar.Parameters.Add("@fecha_desde", SqlDbType.Date).Value = dtp_desde.Value;
                cancelar.Parameters.Add("@fecha_hasta", SqlDbType.Date).Value = dtp_hasta.Value;
                cancelar.Parameters.Add("@motivo", SqlDbType.VarChar).Value = tb_motivo.Text;
                cancelar.ExecuteNonQuery();
                MessageBox.Show("Franja Cancelada Correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            }
        
    }
}
