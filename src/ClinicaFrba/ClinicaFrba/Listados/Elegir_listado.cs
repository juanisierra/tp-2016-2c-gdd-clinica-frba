using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class Elegir_listado : Form
    {
        public List<String> listados { get; set; }

        public Elegir_listado()
        {
            InitializeComponent();
            listados = new List<String>();
            listados.Add("Especialidades con más cancelaciones");
            listados.Add("Profesionales más consultados");
            listados.Add("Profesionales con menos horas trabajadas");
            listados.Add("Afiliados con mayor cantidad de bonos comprados");
            listados.Add("Especialidades con más bonos de consulta utilizados");
            cb_listado.DataSource = listados;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            switch (cb_listado.SelectedIndex)
            {
                case 0:
                    new ListadoCancelaciones().ShowDialog();
                    break;
                case 1:
                    new ListadoConsultas().ShowDialog();
                    break;
                case 2:
                    new ListadoHoras().ShowDialog();
                    break;
            }
            this.Visible = true;
        }


    }
}
