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
using System.Security.Cryptography;
using ClinicaFrba.Clases;
using ClinicaFrba.Utils;
namespace ClinicaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private Usuario login()
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            Usuario usuario = Usuario.buscarUsuario(txtbox_usuario.Text,conexion);
            if (usuario == null)
            {
                MessageBox.Show("El nombre de usuario no existe", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (usuario.habilitado == true)
                {
                    //Si existe el usuario
                    if (usuario.contrasenia.SequenceEqual(Hash.ComputePasswordHash(txtbox_contrasenia.Text)))
                    {
                    }
                    else
                    { //Contraseña incorrecta
                        SqlCommand sumarIntentoFallido = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.Usuario SET intentos_fallidos=intentos_fallidos+1 WHERE id_usuario='{0}'", usuario.id_usuario), conexion);
                        sumarIntentoFallido.ExecuteNonQuery();
                        usuario = Usuario.buscarUsuario(txtbox_usuario.Text, conexion); //Actualizamos usuario
                        if (usuario.intentosFallidos >= 3)
                        {
                            SqlCommand inhabilitarUsuario = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.Usuario SET habilitado=0 WHERE id_usuario='{0}'", usuario.id_usuario), conexion);
                            inhabilitarUsuario.ExecuteNonQuery();
                            usuario = Usuario.buscarUsuario(txtbox_usuario.Text, conexion); //Actualizamos usuario
                            MessageBox.Show("El usuario se encuentra bloqueado", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return null;
                    }
                }
                else {
                    MessageBox.Show("El usuario se encuentra bloqueado", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                    }            
            }
            return usuario;
        }
        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            if (login() != null) resultado.Text = "OK";
        }
    }
}