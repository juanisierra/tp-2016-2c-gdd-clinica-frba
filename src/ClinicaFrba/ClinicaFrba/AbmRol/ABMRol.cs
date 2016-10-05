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

namespace ClinicaFrba.AbmRol
{
    public partial class ABMRol : Form
    {
        public String id_usuario { get; set; }

        public ABMRol(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            NuevoRol ventana = new NuevoRol(this.id_usuario);
            this.Visible = false;
            ventana.ShowDialog();
            this.Visible = true;
        }

        private void btn_modif_Click(object sender, EventArgs e)
        {
            ModifRol ventana = new ModifRol(listaRoles.SelectedRows[0]);
            this.Visible = false;
            ventana.ShowDialog();
            this.Visible = true;
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {

        }

        private void listaRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ABMRol_Load(object sender, EventArgs e)
        {
            List<Rol> roles = Rol.rolesTotales();
            listaRoles.DataSource = roles;
            listaRoles.Columns[0].Visible = false;
            listaRoles.Columns[2].HeaderText = "Habilitado";
            listaRoles.Columns[1].Width = 190;
        }
    }
}
