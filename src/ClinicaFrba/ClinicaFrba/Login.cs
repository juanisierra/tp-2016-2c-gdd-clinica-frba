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
using System.Data;
using System.Security.Cryptography;
namespace ClinicaFrba
{  
    public partial class Login : Form
    {   SqlConnection conexion;
        public Login()
        {
            InitializeComponent();
            SqlConnection conexion = DBConnector.ObtenerConexion();
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
        private byte[] ComputePasswordHash(string password)
            {
    byte[] passwordBytes = UTF8Encoding.UTF8.GetBytes(password);

    byte[] preHashed = new byte[passwordBytes.Length];
    System.Buffer.BlockCopy(passwordBytes, 0, preHashed, 0, passwordBytes.Length);
       SHA256
    SHA1 sha1 = SHA1.Create();
    return sha1.ComputeHash(preHashed);
                }
        private void btn_iniciar_Click(object sender, EventArgs e)
        {
     using (SqlConnection con = DBConnector.ObtenerConexion())
{
    using (SqlCommand cmd = new SqlCommand("ELIMINAR_CAR.verificar_login", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@usuario", txtbox_usuario.Text);
        cmd.Parameters.AddWithValue("@contrasenia", txtlastname);
        con.Open();
        cmd.ExecuteNonQuery();
    }            
}
    }
  }

        }
    }
}
