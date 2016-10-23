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
    public partial class NuevoAfiliado : Form
    {
        public SqlConnection conexion { get; set; }
        public int tipo { get; set; }
        public Int64 numFam { get; set; }

        public NuevoAfiliado(int tipo, Int64 numeroFamilia) //raíz = 0, casado 1, concubinato 2,3 familia
        {
            InitializeComponent();
            this.conexion = DBConnector.ObtenerConexion();
            this.tipo = tipo;
            this.numFam = numeroFamilia;
        }

        private void NuevoAfiliado_Load(object sender, EventArgs e)
        {
            PlanMedAfi.DataSource = Plan.traerPlanes();
            comboBox_EstadoCivilAfi.DataSource = Enum.GetValues(typeof(estado_civil));
            comboBox_SexoAfi.DataSource = Enum.GetValues(typeof(sexo));
            comboBox_TipoDoc.DataSource = Enum.GetValues(typeof(tipo_doc));

            switch (tipo)
            {//distintos tipos de formularios 
                case 1:
                    comboBox_EstadoCivilAfi.SelectedItem = estado_civil.Casado;
                    comboBox_EstadoCivilAfi.Enabled = false;
                    textBox_CantFami.Hide();
                    label11.Hide();  //si no funciona probar visible
                    break;
                case 2:
                    comboBox_EstadoCivilAfi.SelectedItem = estado_civil.Concubinato;
                    comboBox_EstadoCivilAfi.Enabled = false;
                    textBox_CantFami.Hide();
                    label11.Hide();
                    break;
                case 3:
                    textBox_CantFami.Hide();
                    label11.Hide();
                    break;
            }
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            Errores errores = new Errores();
            if (textBox_NombAfi.TextLength == 0) errores.agregarError("El nombre del afiliado no puede ser nulo");
            if (textBox_ApAfi.TextLength == 0) errores.agregarError("El apellido del afiliado no puede ser nulo");
            if (textBox_NumDoc.TextLength == 0) errores.agregarError("El número de documento del afiliado no puede ser nulo");
            if (PlanMedAfi.SelectedItem == "") errores.agregarError("El plan médico del afiliado no puede ser nulo");

            if (errores.huboError()) MessageBox.Show("Debe solucionar los siguientes errores:\n" + errores.stringErrores(), "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else //Coportamiento si esta todo ok
            {
                //Insertar Chabon

                MessageBox.Show("el afiliado fue agregado corrrectamente\n", "Clinica-FRBA", MessageBoxButtons.OK);
                //Casteo a tipo de dato, porque devuelve object 
            
                    if ((tipo == 0) && ((estado_civil)comboBox_EstadoCivilAfi.SelectedItem == estado_civil.Casado))
                    {
                        DialogResult res = MessageBox.Show("¿Desea agregar a su conyuge?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            NuevoAfiliado conyuge = new NuevoAfiliado(1, numFam);
                            this.Visible = false;
                            conyuge.ShowDialog();
                            this.Visible = true;

                        }
                    }

                    if ((tipo == 0) && ((estado_civil)comboBox_EstadoCivilAfi.SelectedItem == estado_civil.Concubinato))
                    {
                        DialogResult res = MessageBox.Show("¿Desea agregar a su conyuge?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            NuevoAfiliado conyuge = new NuevoAfiliado(2, numFam);
                            this.Visible = false;
                            conyuge.ShowDialog();
                            this.Visible = true;

                        }
                    }        
                
                      if ((tipo == 0) && textBox_CantFami.TextLength >0 && (int.Parse(textBox_CantFami.Text) > 0))
                        {
                            int cantFamiliares = int.Parse(textBox_CantFami.Text);
                            for (int i = 0; i < cantFamiliares; i++)
                            {
                                DialogResult resultado = MessageBox.Show("¿Desea agregar un nuevo familiar a cargo?", "Clinica-FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (resultado == DialogResult.Yes)
                                {
                                    NuevoAfiliado familiar = new NuevoAfiliado(3, numFam);
                                    this.Visible = false;
                                    familiar.ShowDialog();
                                    this.Visible = true;

                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    
                    this.Close();
                }
            }
        }
    }

