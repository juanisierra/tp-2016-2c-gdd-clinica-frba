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

namespace ClinicaFrba.Abm_Profesional
{
    public partial class SeleccionarProfesional : Form
    {
        List<Profesional> profesionales;
        public Boolean fueCerradoPorUsuario = false;
        public SeleccionarProfesional()
        {
            InitializeComponent();
            profesionales  = Profesional.profesionales(DBConnector.ObtenerConexion());
             dgv_profesional.DataSource = profesionales;
             this.FormClosing += SeleccionarProfesional_Closing;
             fueCerradoPorUsuario = false;
        }

        private void dgv_profesional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fueCerradoPorUsuario = false;
        }

        private void SeleccionarProfesional_Load(object sender, EventArgs e)
        {

        }
        private void SeleccionarProfesional_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) fueCerradoPorUsuario = true;

            }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fueCerradoPorUsuario = true;
        }
    }
}
