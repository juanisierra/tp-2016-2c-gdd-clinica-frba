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

namespace ClinicaFrba.Abm_Especialidades_Medicas
{
    public partial class SeleccionarEspecialidad : Form
    {
        public Boolean fueCerradoPorUsuario = false;   //Vale true si la cierran con la X
        public SeleccionarEspecialidad(List<Especialidad> lista)
        {
            InitializeComponent();
            cb_especialidad.DataSource = lista;
            this.FormClosing += SeleccionarEspecialidad_Closing;
            fueCerradoPorUsuario = false;
        }

        private void SeleccionarEspecialidad_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) fueCerradoPorUsuario = true;

         
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (cb_especialidad.SelectedItem == null)
            {
                MessageBox.Show("ERROR: Debe seleccionar una especialidad.", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Close();
                fueCerradoPorUsuario = false;
            }
        }

        private void SeleccionarEspecialidad_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fueCerradoPorUsuario = true;
        }
    }
}
