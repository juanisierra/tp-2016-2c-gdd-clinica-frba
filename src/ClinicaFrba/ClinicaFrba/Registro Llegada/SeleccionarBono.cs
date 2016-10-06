using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class SeleccionarBono : Form
    {
        public Int64 id_afiliado { set; get; }
        public List<Int64> bonos { set; get; }
        public Boolean fueCerradoPorUsuario { set; get; }
        public SeleccionarBono(Int64 id_afiliado)
        {
            InitializeComponent();
            this.fueCerradoPorUsuario = false;
            this.FormClosing += SeleccionarBono_Closing;
            this.id_afiliado = id_afiliado;
        }

        private void SeleccionarBono_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) fueCerradoPorUsuario = true;
        }

        private void SeleccionarBono_Load(object sender, EventArgs e)
        {   
            this.fueCerradoPorUsuario = false;
            bonos = Bono.bonosDisponibles(id_afiliado);
            if (bonos.Count == 0)
            {
                MessageBox.Show("Error: El afiliado no posee bonos disponibles", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                this.fueCerradoPorUsuario = false;
            }
            cb_id_bono.DataSource = bonos;
        }

        private void btn_utilizar_Click(object sender, EventArgs e)
        {
            if (cb_id_bono.SelectedItem == null) MessageBox.Show("Error: Debe seleccionar un bono","Clinica-FRBA ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                this.Close();
                this.fueCerradoPorUsuario = false;
            }
        }
    }
}
