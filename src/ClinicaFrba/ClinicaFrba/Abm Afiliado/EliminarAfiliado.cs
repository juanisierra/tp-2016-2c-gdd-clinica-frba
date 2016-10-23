using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class EliminarAfiliado : Form
    {
        int tipo { get; set; }
        private System.Data.SqlClient.SqlConnection conexion { get; set; }
        private Afiliado afiliado = new Afiliado();

        public EliminarAfiliado(Afiliado afiliado)
        {
            InitializeComponent();
            this.afiliado = afiliado;
        }

        private int tipoAfi()//tipo = 0 es raíz, los otros no importan
        {
            String textAfi = afiliado.idAfiliado.ToString();
            if (textAfi.EndsWith("01"))
            {
                tipo = 0;
            }
            else
            {
                tipo = 1;
            }
            return tipo;
        }



        private void EliminarAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar a este afiliado?", "Clinica-FRBA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK)
            {
                afiliado.activo = false;
                MessageBox.Show("El afiliado fue eliminado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }

            this.Close();
        }
    }
}
