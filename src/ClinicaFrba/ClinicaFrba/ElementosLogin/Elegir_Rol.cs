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
namespace ClinicaFrba.ElementosLogin
{
    public partial class Elegir_Rol : Form
    {
        public String id_usuario { get; set; }
        public Elegir_Rol(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
        }
        
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Elegir_Rol_Load(object sender, EventArgs e)
        {   List<Rol> roles = Rol.rolesDeUsuario(id_usuario);
            cb_rol.DataSource = roles;          
        }
    }
}
