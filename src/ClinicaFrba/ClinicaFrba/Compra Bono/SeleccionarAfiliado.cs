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

namespace ClinicaFrba.Compra_Bono
{
    public partial class SeleccionarAfiliado : Form
    {
        public Boolean fueCerradoPorUsuario = false; //Dice si lo cerro el usuario o no
        List<Afiliado> listaAfiliados { set; get; }
        public Boolean soloListar { set; get; } //lista afiliados
        public SeleccionarAfiliado()
        {
            InitializeComponent();
            soloListar = false;
        }
        public SeleccionarAfiliado(int listar)
        {
            InitializeComponent();
            soloListar = true;
        }
        private void SeleccionarAfiliado_Load(object sender, EventArgs e)
        {
            listaAfiliados = Afiliado.listarAfiliadosConFiltro("", "", -1, -1, -1, -1);
            dgv_afiliado.DataSource = listaAfiliados;
            List<String> tiposDoc = new List<String>();
            tiposDoc.Add("Cualquiera");
            tiposDoc.AddRange(Enum.GetValues(typeof(tipo_doc)).Cast<tipo_doc>().Select(elem => elem.ToString()).ToList<String>());
            cb_tipoDoc.DataSource = tiposDoc;
            List<Plan> planes = new List<Plan>();
            Plan cualquiera = new Plan();
            cualquiera.desc_plan = "Cualquiera";
            cualquiera.id_plan = -1;
            planes.Add(cualquiera);
            planes.AddRange(Plan.traerPlanes());
            cb_plan.DataSource = planes;
            txt_idAfiliado.KeyPress += controlNumeros;
            txt_nDoc.KeyPress += controlNumeros;
            txt_nombre.KeyPress += controlLetras;
            txt_apellido.KeyPress += controlLetras;
            this.FormClosing += closing;
            fueCerradoPorUsuario = false;
            if(soloListar==true) btn_seleccionar.Hide();
        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {
            ActualizarFiltro();

        }
        private void ActualizarFiltro()
        {
            Int64 id_afiliado;
            int tipo_docu;
            int numero_doc;
            if (txt_nDoc.Text != "") numero_doc = int.Parse(txt_nDoc.Text);
            else numero_doc = -1;
            if (txt_idAfiliado.Text != "") id_afiliado = Int64.Parse(txt_idAfiliado.Text);
            else id_afiliado = -1;
            if (((String)cb_tipoDoc.SelectedItem).Equals("Cualquiera")) tipo_docu = -1;
            else tipo_docu = (int)Enum.Parse(typeof(tipo_doc), (String)cb_tipoDoc.SelectedItem, true);
            listaAfiliados = Afiliado.listarAfiliadosConFiltro(txt_nombre.Text, txt_apellido.Text, numero_doc, tipo_docu, ((Plan)cb_plan.SelectedItem).id_plan, id_afiliado);
            dgv_afiliado.DataSource = listaAfiliados;
        }
        private void controlNumeros(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b') //Numeros o borrar
                    {
                        e.Handled = false; //Se deja que entre
                    }
                else
                {
                    e.Handled = true; //Se cancela
                }
            }
        private void controlLetras(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //Numeros o borrar
            {
                e.Handled = true; //Se cancela
            }
            else
            {
                e.Handled = false; //Se deja que entre
            }
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            if (dgv_afiliado.CurrentRow != null)
            {
                this.Close();
                fueCerradoPorUsuario = false;
            }
            else
            {
                MessageBox.Show("Error: Debe seleccionar un afiliado", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) fueCerradoPorUsuario = true;

        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            cb_plan.SelectedIndex = 0;
            cb_tipoDoc.SelectedIndex = 0;
            txt_apellido.Text = "";
            txt_idAfiliado.Text = "";
            txt_nDoc.Text = "";
            txt_nombre.Text = "";
            ActualizarFiltro();
        }
    }
}
