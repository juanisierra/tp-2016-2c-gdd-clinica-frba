using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Clases;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        public int tipo { get; set; }
        public SqlConnection conexion { get; set; }
        public Afiliado afiliadoAMod = new Afiliado();

        public ModificarAfiliado(int tipo, Int64 id_Afiliado)
        {
            InitializeComponent();
            this.afiliadoAMod.idAfiliado = id_Afiliado;
            this.tipo = tipo;
        }

        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {
            tbidAfiliado.Text = (this.afiliadoAMod.idAfiliado).ToString();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El afiliado se ha modificado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

    }
}
