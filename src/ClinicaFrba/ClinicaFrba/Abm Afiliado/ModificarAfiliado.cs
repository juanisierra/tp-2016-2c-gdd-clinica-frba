using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClinicaFrba.Clases;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        public int tipo { get; set; }
        public SqlConnection conexion { get; set; }
        public Afiliado afiliadoAMod { set; get; }

        public ModificarAfiliado( Afiliado afiliado)
        {
            InitializeComponent();
            afiliadoAMod = afiliado;
        }

        private int tipoAfi()//tipo = 0 es raíz, los otros no importan
        {
            String textAfi = afiliadoAMod.idAfiliado.ToString();
            if (textAfi.EndsWith("01"))
            {
                tipo = 0;
            }
            else
            {
                tipo = 1;
            }
            return tipo;
        }


        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {
            tbidAfiliado.Text = afiliadoAMod.idAfiliado.ToString();
            tbNom.Text = afiliadoAMod.nombre.ToString();
            tbAp.Text = afiliadoAMod.apellido.ToString();
            tbTDoc.Text = afiliadoAMod.tipoDoc.ToString();
            tbNDoc.Text = afiliadoAMod.nroDoc.ToString();
            tbFech.Text = afiliadoAMod.fechaNac.ToString("dd/M/yyyy");
            estadoCiv.DataSource = Enum.GetValues(typeof(estado_civil));
            estadoCiv.SelectedItem = afiliadoAMod.estadoCivil.ToString();
            direc.Text = afiliadoAMod.direccion.ToString();
            tel.Text = afiliadoAMod.telefono.ToString();
            mail.Text = afiliadoAMod.mail.ToString();
            planMed.DataSource = Plan.traerPlanes();
            planMed.SelectedItem = afiliadoAMod.descPlan.ToString(); 
            Sexo.DataSource = Enum.GetValues(typeof(sexo));
            Sexo.Text = afiliadoAMod.sexo.ToString();

            switch (tipo)
            {
                case 0:
                    cantFam.Text = afiliadoAMod.familiaresACargo.ToString();
                    break;
                case 1:
                    cantFam.Hide();
                    label7.Hide();
                    btAgregarFamiliar.Hide();
                    break;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea realizar estos cambios?", "Clinica-FRBA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            
            if (resultado == DialogResult.OK)
            {
                String planMedAct = planMed.Text.ToString();
                if (planMed.ToString() != planMedAct)
                {
                    MotivoCambioPlan motivo = new MotivoCambioPlan();
                    this.Visible = false;
                    motivo.ShowDialog();
                    this.Visible = true;
                }
            
                //hacer modificacion
                MessageBox.Show("El afiliado fue modificado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if ((tipo == 0) && ((estado_civil)estadoCiv.SelectedItem == estado_civil.Casado))
                {
                    DialogResult res = MessageBox.Show("¿Desea agregar a su conyuge?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        NuevoAfiliado conyuge = new NuevoAfiliado(1, -1);
                        this.Visible = false;
                        conyuge.ShowDialog();
                        this.Visible = true;
                    }
                }

                if ((tipo == 0) && ((estado_civil)estadoCiv.SelectedItem == estado_civil.Concubinato))
                {
                    DialogResult res = MessageBox.Show("¿Desea agregar a su conyuge?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        NuevoAfiliado conyuge = new NuevoAfiliado(2, -1);
                        this.Visible = false;
                        conyuge.ShowDialog();
                        this.Visible = true;
                    }
                }        
              }
        }

        private void btAgregarFamiliar_Click(object sender, EventArgs e)
        {
            NuevoAfiliado form = new NuevoAfiliado(3, afiliadoAMod.idAfiliado);
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }
    }
}
