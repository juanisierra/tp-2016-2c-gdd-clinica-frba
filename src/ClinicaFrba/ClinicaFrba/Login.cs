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
using ClinicaFrba.ElementosLogin;

namespace ClinicaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
        }

        private Usuario login()
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            Usuario usuario = Usuario.buscarUsuario(txtbox_usuario.Text,conexion);
            if (usuario == null)
            {
                MessageBox.Show("El nombre de usuario y la contraseña no coinciden", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (usuario.habilitado == true) //Si existe el usuario
                {
                    //Si puso bien la clave, que no tire error
                    if (usuario.contrasenia.SequenceEqual(Hash.ComputePasswordHash(txtbox_contrasenia.Text))) {
                        if (usuario.intentosFallidos > 0)
                        {
                            usuario = restablecerIntentosFallidos(usuario, conexion);
                        }
                    }
                    else
                    { //Contraseña incorrecta
                        usuario = sumarIntentoFallido(usuario, conexion);
                        if (usuario.intentosFallidos >= 3)
                        {
                            usuario = inhabilitarUsuario(usuario, conexion);
                            MessageBox.Show("El usuario se encuentra bloqueado", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario y la contraseña no coinciden", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Usuario inhabilitarUsuario(Usuario usuario, SqlConnection conexion)
        {
            SqlCommand inhabilitarUsuario = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.Usuario SET habilitado=0 WHERE id_usuario='{0}'", usuario.id_usuario), conexion);
            inhabilitarUsuario.ExecuteNonQuery();
            return Usuario.buscarUsuario(txtbox_usuario.Text, conexion); //Actualizamos usuario
        }

        private Usuario sumarIntentoFallido(Usuario usuario, SqlConnection conexion)
        {
            SqlCommand sumarIntentoFallido = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.Usuario SET intentos_fallidos=intentos_fallidos+1 WHERE id_usuario='{0}'", usuario.id_usuario), conexion);
            sumarIntentoFallido.ExecuteNonQuery();
            return Usuario.buscarUsuario(txtbox_usuario.Text, conexion); //Actualizamos usuario
        }

        private Usuario restablecerIntentosFallidos(Usuario usuario, SqlConnection conexion)
        {
            SqlCommand restablecerIntentosFallidos = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.Usuario SET intentos_fallidos=0 WHERE id_usuario='{0}'", usuario.id_usuario), conexion);
            restablecerIntentosFallidos.ExecuteNonQuery();
            return Usuario.buscarUsuario(txtbox_usuario.Text, conexion); //Actualizamos usuario
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {   
            Usuario u = login();
            if (u != null)
            {
                int id_rol = -1;
                List<Rol> roles = Rol.rolesDeUsuario(u.id_usuario);
                if (roles.Count > 1)            //Hay que elegir rol
                {
                    Elegir_Rol elegirRol = new Elegir_Rol(u.id_usuario);
                    elegirRol.ShowDialog();
                    ComboBox cb_rol = (ComboBox)elegirRol.Controls["cb_rol"];
                    id_rol = ((Rol)cb_rol.SelectedItem).id_rol;
                }
                else if (roles.Count != 0) //Tiene uno solo
                {
                    id_rol = roles.First<Rol>().id_rol;
                }
                if (id_rol != -1)
                {
                    Elegir_funcionalidad elegirFuncionalidad = new Elegir_funcionalidad(id_rol, u.id_usuario);
                    this.Visible = false; //Se oculta hasta que retorne el otro formulario
                    elegirFuncionalidad.ShowDialog();
                    this.Visible = true;

                    txtbox_contrasenia.Clear();
                    txtbox_usuario.Clear();
                }
                else
                {
                    MessageBox.Show("El usuario no cuenta con ningún rol", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
            }
        }
    }
}