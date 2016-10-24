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
    public partial class MotivoCambioPlan : Form
    {
        public Boolean fueCerradoPorusuario { set; get; }
        public MotivoCambioPlan()
        {
            InitializeComponent();

        }

        private void MotivoCambioPlan_Load(object sender, EventArgs e)
        {
            this.FormClosing += closing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            fueCerradoPorusuario = false;
        }
        private void closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) fueCerradoPorusuario = true;

        }
    }
}
