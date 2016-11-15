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
using ClinicaFrba.Utils;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        public int tipo { get; set; }
        public SqlConnection conexion { get; set; }
        public Afiliado afiliadoAMod { set; get; }
        public Boolean seCambioTelefono { set; get; }
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
            seCambioTelefono = false;
            tel.KeyPress += Validaciones.controlNumeros;
            tbidAfiliado.Text = afiliadoAMod.idAfiliado.ToString();
            tbNom.Text = afiliadoAMod.nombre.ToString();
            tbAp.Text = afiliadoAMod.apellido.ToString();
            tbTDoc.Text = afiliadoAMod.tipoDoc.ToString();
            tbNDoc.Text = afiliadoAMod.nroDoc.ToString();
            tbFech.Text = afiliadoAMod.fechaNac.ToString("dd/M/yyyy");
            estadoCiv.DataSource = Enum.GetValues(typeof(estado_civil));
            estadoCiv.SelectedItem = afiliadoAMod.estadoCivil;
            direc.Text = afiliadoAMod.direccion.ToString();
            tel.Text = afiliadoAMod.telefono.ToString();
            mail.Text = afiliadoAMod.mail.ToString();
            List<Plan> planes = Plan.traerPlanes();
            planMed.DataSource = planes;
            planMed.SelectedItem = planes.Find(plan => plan.id_plan==afiliadoAMod.idPlan); 
            Sexo.DataSource = Enum.GetValues(typeof(sexo));
            Sexo.Text = afiliadoAMod.sexo.ToString();
            tipoAfi();
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

            this.tel.TextChanged += new System.EventHandler(this.tel_TextChanged);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {   SqlCommand modificarAfi = new SqlCommand("ELIMINAR_CAR.modificarAfiliado",DBConnector.ObtenerConexion());
            modificarAfi.CommandType = CommandType.StoredProcedure;
            modificarAfi.Parameters.Add(new SqlParameter("@id_afiliado",afiliadoAMod.idAfiliado));
           Boolean huboCambios = false;
            //Telefono
            if(seCambioTelefono) {
                huboCambios = true;
                modificarAfi.Parameters.AddWithValue("@telefono",Int64.Parse(tel.Text));
            } else modificarAfi.Parameters.AddWithValue("@telefono",DBNull.Value);
            //Direccion
            if (!afiliadoAMod.direccion.Equals(direc.Text)) {
                huboCambios = true;
            modificarAfi.Parameters.Add(new SqlParameter("@direccion",direc.Text));
            } else 
            modificarAfi.Parameters.Add(new SqlParameter("@direccion",DBNull.Value));
            //Estado civil
            if (afiliadoAMod.estadoCivil != (estado_civil)estadoCiv.SelectedItem)
            {
                huboCambios=true;
                modificarAfi.Parameters.AddWithValue("@estado_civil", (Int32)estadoCiv.SelectedItem);
            }
            else modificarAfi.Parameters.AddWithValue("@estado_civil", DBNull.Value);
            //MAIL
            if (!afiliadoAMod.mail.Equals(mail.Text))
            {
                huboCambios = true;
                modificarAfi.Parameters.AddWithValue("@mail", mail.Text);
            }
            else modificarAfi.Parameters.AddWithValue("@mail", DBNull.Value);
            //Sexo
            if (afiliadoAMod.sexo!=(sexo)Sexo.SelectedItem)
            {
                huboCambios = true;
                modificarAfi.Parameters.AddWithValue("@sexo",(int) Sexo.SelectedItem);
            }
            else modificarAfi.Parameters.AddWithValue("@sexo", DBNull.Value);
            //Plan
            if (afiliadoAMod.idPlan != ((Plan)planMed.SelectedItem).id_plan)
            {
                huboCambios = true;
                modificarAfi.Parameters.AddWithValue("@id_plan", ((Plan)planMed.SelectedItem).id_plan);
            }
            else modificarAfi.Parameters.AddWithValue("@id_plan", DBNull.Value);
            if (huboCambios)
            {
                DialogResult resultado = MessageBox.Show("¿Desea realizar estos cambios?", "Clinica-FRBA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.OK)
                {
                    if (afiliadoAMod.idPlan != ((Plan)planMed.SelectedItem).id_plan)
                    {
                        MotivoCambioPlan motivo = new MotivoCambioPlan();
                        this.Visible = false;
                        motivo.ShowDialog();
                        this.Visible = true;
                        modificarAfi.Parameters.AddWithValue("@fecha_cambio", ClinicaFrba.Utils.Fechas.getCurrentDateTime().Date);
                        if (motivo.fueCerradoPorusuario) modificarAfi.Parameters.AddWithValue("@motivo_cambio_plan", "No especificado");
                        else modificarAfi.Parameters.AddWithValue("@motivo_cambio_plan", ((RichTextBox)motivo.Controls["tb_motivo"]).Text);
                    }
                    else
                    {
                        modificarAfi.Parameters.AddWithValue("@fecha_cambio",DBNull.Value);
                        modificarAfi.Parameters.AddWithValue("@motivo_cambio_plan", DBNull.Value);
                    }

                    modificarAfi.ExecuteNonQuery();
                    MessageBox.Show("El afiliado fue modificado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    huboCambios = false;
                    seCambioTelefono = false;
                    
                    if ((tipo == 0) && ((estado_civil)estadoCiv.SelectedItem == estado_civil.Casado) && afiliadoAMod.estadoCivil != estado_civil.Casado)
                    {
                        DialogResult res = MessageBox.Show("¿Desea agregar a su conyuge?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            NuevoAfiliado conyuge = new NuevoAfiliado(1, afiliadoAMod.idFamilia);
                            this.Visible = false;
                            conyuge.ShowDialog();
                            this.Visible = true;
                        }
                    }

                    if ((tipo == 0) && ((estado_civil)estadoCiv.SelectedItem == estado_civil.Concubinato) && afiliadoAMod.estadoCivil != estado_civil.Concubinato)
                    {
                        DialogResult res = MessageBox.Show("¿Desea agregar a su conyuge?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            NuevoAfiliado conyuge = new NuevoAfiliado(2, afiliadoAMod.idFamilia);
                            this.Visible = false;
                            conyuge.ShowDialog();
                            this.Visible = true;
                        }
                    }
                    afiliadoAMod = Afiliado.getAfiliadoPorID(afiliadoAMod.idAfiliado); // Lo recargamos
                }
            }
        }

        private void btAgregarFamiliar_Click(object sender, EventArgs e)
        {
            NuevoAfiliado form = new NuevoAfiliado(3, afiliadoAMod.idFamilia);
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }

        private void tel_TextChanged(object sender, EventArgs e)
        {
            seCambioTelefono = true;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
