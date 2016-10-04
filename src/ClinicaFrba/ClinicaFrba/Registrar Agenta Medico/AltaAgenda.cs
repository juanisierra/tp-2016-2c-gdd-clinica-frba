using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Clases;
namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class AltaAgenda : Form
    {
        public string id_usuario { set; get; }
        public AltaAgenda(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
        }

        private void AltaAgenda_Load(object sender, EventArgs e)
        {
            SeleccionarProfesional formulario = new SeleccionarProfesional();
            formulario.ShowDialog();
            Profesional profesional = (Profesional)((DataGridView)formulario.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
