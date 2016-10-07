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
    public partial class CancelacionAfiliado : Form
    {   public String id_usuario {set;get;}
        public int id_rol { set; get; }
        public Int64 id_afiliado { set; get; }
        public List<Turno> turnos { set; get; }
        public CancelacionAfiliado(String id_usuario,int id_rol)
        {
            InitializeComponent();
            this.id_rol = id_rol;
            this.id_usuario = id_usuario;
           
        }

        private void CancelacionAfiliado_Load(object sender, EventArgs e)
        {
            
            id_afiliado = Afiliado.getIdAfiliadoPorUsuario(id_usuario);
            if (id_afiliado == -1)
            {
                MessageBox.Show("Error, el usuario con el que ingreso no es un afiliado valido.", "Clinica-FRBA Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
            
            actualizarTurnos();
            actualizarBoton();
        }
        public void actualizarBoton()
        {
            if (dgv_turno.CurrentRow != null)
            {
                btn_cancelar.Enabled = true;
                tb_motivo.Enabled = true;
            }
            else
            {
                btn_cancelar.Enabled = false;
                tb_motivo.Enabled = false;
            }
        }
        public void actualizarTurnos()
        {
            dgv_turno.DataSource = null;
            turnos = Turno.traerTurnosCancelablesAfiliado(id_afiliado, DateTime.Now);
            dgv_turno.DataSource = turnos;
        }

        private void dgv_turno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            actualizarBoton();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (tb_motivo.TextLength == 0) MessageBox.Show("ERROR: Debe ingresar un motivo de cancelacion", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SqlCommand insertar = new SqlCommand("ELIMINAR_CAR.cancelarTurnoAfiliado", DBConnector.ObtenerConexion());
                insertar.CommandType = CommandType.StoredProcedure;
                insertar.Parameters.Add("@id_turno", SqlDbType.BigInt).Value = ((Turno)dgv_turno.CurrentRow.DataBoundItem).id_turno;
                insertar.Parameters.Add("@id_afiliado", SqlDbType.BigInt).Value = id_afiliado;
                insertar.Parameters.Add("@motivo", SqlDbType.VarChar).Value = tb_motivo.Text;
                insertar.ExecuteNonQuery();
                MessageBox.Show("El turno se ha cancelado correctamente.", "ClinicaFrba-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarTurnos();
                actualizarBoton();
            }
        }
    }
}
