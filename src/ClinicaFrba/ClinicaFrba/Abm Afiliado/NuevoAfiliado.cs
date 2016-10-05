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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class NuevoAfiliado : Form
    {
        private string id_usuario { get; set; }
        private SqlConnection conexion { get; set; }

        public NuevoAfiliado(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.conexion = DBConnector.ObtenerConexion();
        }

        private void NuevoAfiliado_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox_MailAfi_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_SexoAfi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void botonAceptar_Click(object sender, EventArgs e)
        {
            Boolean hayError = false;
            String mensajeAEnviar = "";
            if (textBox_NombAfi.Text == "")
            {
                mensajeAEnviar = mensajeAEnviar + "-Debe ingresar su nombre\n";
                hayError = true;
            }
            else if (textBox_NombAfi.Text.Length > 40)
            {
                mensajeAEnviar = mensajeAEnviar + "- El nombre es demasiado largo\n";
                hayError = true;
            }
            if (textBox_ApAfi.Text == "")
            {
                mensajeAEnviar = mensajeAEnviar + "-Debe ingresar su apellido\n";
                hayError = true;
            }
            else if (textBox_ApAfi.Text.Length > 40)
            {
                mensajeAEnviar = mensajeAEnviar + "- El apellido es demasiado largo\n";
                hayError = true;
            }
            if (textBox_NumDoc.Text == "")
            {
                mensajeAEnviar = mensajeAEnviar + "-Debe ingresar su número de documento\n";
                hayError = true;
            }
            else if (textBox_NombAfi.Text.Length > 8)
            {
                mensajeAEnviar = mensajeAEnviar + "- sólo debe ingresar números\n";
                hayError = true;
            }
            
            if (textBox_DirecAfi.Text.Length > 100)
            {
                mensajeAEnviar = mensajeAEnviar + "- La dirección es demasiado larga\n";
                hayError = true;
            }


            if (hayError)
            {
                MessageBox.Show("Debe solucionar los siguientes errores:\n" + mensajeAEnviar, "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               //agregar a la base de datos
                //MessageBox.Show("El afiliado fue creado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
