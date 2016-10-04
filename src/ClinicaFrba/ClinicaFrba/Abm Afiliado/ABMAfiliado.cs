using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABMAfiliado : Form
    {
        public ABMAfiliado()
        {
            InitializeComponent();
        }

        private void ABMAfiliado_Load(object sender, EventArgs e)
        {

        }


        private void botonAgregar_Click(object sender, EventArgs e)
        {
            NuevoAfiliado ventana = new NuevoAfiliado(this.id_usuario);
            this.Visible = false;
            ventana.ShowDialog();
            this.Visible = true;
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            ModificarAfiliado ventana = new ModificarAfiliado(listaRoles.SelectedRows[0]);
            this.Visible = false;
            ventana.ShowDialog();
            this.Visible = true;
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {

        }

    
    }
}
