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
    public partial class ABMAfiliado : Form
    {
        public String id_usuario { get; set; }
        private Afiliado afiliado = new Afiliado();

        public ABMAfiliado(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
         //   this.afiliado.idAfiliado = (Int64)textBox_NumAfi.Text; ver como hacer esto
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
            ModificarAfiliado ventana = new ModificarAfiliado(this.id_usuario, this.afiliado.idAfiliado);
            this.Visible = false;
            ventana.ShowDialog();
            this.Visible = true;
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            EliminarAfiliado ventana = new EliminarAfiliado(this.id_usuario, this.afiliado.idAfiliado);
            this.Visible = false;
            ventana.ShowDialog();
            this.Visible = true;
        }

    
    }
}
