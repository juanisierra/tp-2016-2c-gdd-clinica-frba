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
        
        public SeleccionarProfesional()
        {
            InitializeComponent();
            profesionales  = Profesional.profesionales(DBConnector.ObtenerConexion());
             dgv_profesional.DataSource = profesionales;
            
        }

        private void dgv_profesional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
