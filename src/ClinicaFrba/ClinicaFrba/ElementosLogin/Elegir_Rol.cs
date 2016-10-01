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
        public Elegir_Rol()
        {
            InitializeComponent();
        }
        
        private void btn_aceptar_Click(object sender, EventArgs e)
        {

        }

        private void Elegir_Rol_Load(object sender, EventArgs e)
        {   List<Rol> roles = Rol.rolesDeUsuario("admin");
            cb_rol.DisplayMember = "Nombre";
            cb_rol.Items.AddRange(roles.ToArray());
        }
    }
}
