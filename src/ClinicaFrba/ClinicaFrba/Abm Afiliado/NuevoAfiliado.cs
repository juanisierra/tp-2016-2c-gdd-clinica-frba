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
            textBox_ApAfi.KeyPress += Validaciones.controlLetras;
            textBox_NombAfi.KeyPress += Validaciones.controlLetras;
            textBox_NumDoc.KeyPress += Validaciones.controlNumeros;
           textBox_TelAfi.KeyPress += Validaciones.controlNumeros;
           textBox_CantFami.KeyPress += Validaciones.controlNumeros;
            dtp_fecha_nac.MaxDate = DateTime.Now;
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
            if (PlanMedAfi.SelectedItem==null) errores.agregarError("El plan médico del afiliado no puede ser nulo");
            SqlCommand cuantosHayConDNI = new SqlCommand("ELIMINAR_CAR.verificar_doc_afiliado", DBConnector.ObtenerConexion());
            int cantDNI = 0;
            cuantosHayConDNI.CommandType = CommandType.StoredProcedure;
            cuantosHayConDNI.Parameters.AddWithValue("@tipo", (int) comboBox_TipoDoc.SelectedItem);
            cuantosHayConDNI.Parameters.AddWithValue("@dni", Int64.Parse(textBox_NumDoc.Text));
            cuantosHayConDNI.Parameters.AddWithValue("@resultado", cantDNI);
            cuantosHayConDNI.Parameters["@resultado"].Direction = ParameterDirection.Output;
            cuantosHayConDNI.ExecuteNonQuery();
            cantDNI = (int)cuantosHayConDNI.Parameters["@resultado"].Value;
            if (cantDNI > 0) errores.agregarError("El tipo y numero de documento ingresado ya existe.");
            if (errores.huboError()) MessageBox.Show(errores.stringErrores(), "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else //Coportamiento si esta todo ok
            {
                //Insertar Chabon
                if (tipo == 0)
                {
                    SqlCommand insertar = new SqlCommand("ELIMINAR_CAR.insertarAfiliadoRaiz", DBConnector.ObtenerConexion());
                    insertar.CommandType = CommandType.StoredProcedure;
                    insertar.Parameters.Add(new SqlParameter("@tipo_doc",(Int32)comboBox_TipoDoc.SelectedValue));
                    insertar.Parameters.Add(new SqlParameter("@n_doc", Decimal.Parse(textBox_NumDoc.Text)));
                    insertar.Parameters.Add(new SqlParameter("@nombre", textBox_NombAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@apellido", textBox_ApAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@direccion", textBox_DirecAfi.Text));
                    int telefono;
                    if (Int32.TryParse(textBox_TelAfi.Text, out telefono)) insertar.Parameters.Add(new SqlParameter("@telefono", Int64.Parse(textBox_TelAfi.Text)));
                    else insertar.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                    insertar.Parameters.Add(new SqlParameter("@mail", textBox_MailAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@fecha_nac", dtp_fecha_nac.Value));
                    insertar.Parameters.Add(new SqlParameter("@estado_civil",(Int32) comboBox_EstadoCivilAfi.SelectedItem));
                    insertar.Parameters.Add(new SqlParameter("@sexo", (Int32)comboBox_SexoAfi.SelectedItem));
                    insertar.Parameters.Add(new SqlParameter("@id_plan", ((Plan)PlanMedAfi.SelectedItem).id_plan));
                    int familiares = 0;
                    //Le ponemos 0 a cargo porque no cuenta el conyuge y al agregar los demas se suman
                   // if (Int32.TryParse(textBox_CantFami.Text, out familiares)) ;
                    //else familiares = 0;
                    insertar.Parameters.Add(new SqlParameter("@familiares_a_cargo", familiares));
                    
                    insertar.Parameters.Add(new SqlParameter("@id_familia_out", numFam));
                    Int64 id_afiliado = 0;
                    insertar.Parameters.Add(new SqlParameter("@id_afiliado_out", id_afiliado));
                    insertar.Parameters["@id_familia_out"].Direction = ParameterDirection.Output;
                    insertar.Parameters["@id_afiliado_out"].Direction = ParameterDirection.Output;
                    insertar.ExecuteNonQuery();
                    numFam = (Int64) insertar.Parameters["@id_familia_out"].Value;

                    id_afiliado = (Int64)insertar.Parameters["@id_afiliado_out"].Value;
                }
                else if (tipo == 1 || tipo == 2)
                {
                    SqlCommand insertar = new SqlCommand("ELIMINAR_CAR.insertarConyuge", DBConnector.ObtenerConexion());
                    insertar.CommandType = CommandType.StoredProcedure;
                    insertar.Parameters.Add(new SqlParameter("@id_familia", numFam));
                    insertar.Parameters.Add(new SqlParameter("@tipo_doc", (Int32)comboBox_TipoDoc.SelectedValue));
                    insertar.Parameters.Add(new SqlParameter("@n_doc", Decimal.Parse(textBox_NumDoc.Text)));
                    insertar.Parameters.Add(new SqlParameter("@nombre", textBox_NombAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@apellido", textBox_ApAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@direccion", textBox_DirecAfi.Text));
                    int telefono;
                    if (Int32.TryParse(textBox_TelAfi.Text, out telefono)) insertar.Parameters.Add(new SqlParameter("@telefono", Int64.Parse(textBox_TelAfi.Text)));
                    else insertar.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                    insertar.Parameters.Add(new SqlParameter("@mail", textBox_MailAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@fecha_nac", dtp_fecha_nac.Value));
                    insertar.Parameters.Add(new SqlParameter("@estado_civil", (Int32)comboBox_EstadoCivilAfi.SelectedItem));
                    insertar.Parameters.Add(new SqlParameter("@sexo", (Int32)comboBox_SexoAfi.SelectedItem));
                    insertar.Parameters.Add(new SqlParameter("@id_plan", ((Plan)PlanMedAfi.SelectedItem).id_plan));

                    Int64 id_afiliado = 0;
                    insertar.Parameters.Add(new SqlParameter("@id_afiliado_out", id_afiliado));
                    insertar.Parameters["@id_afiliado_out"].Direction = ParameterDirection.Output;
                    insertar.ExecuteNonQuery();

                    id_afiliado = (Int64)insertar.Parameters["@id_afiliado_out"].Value;
                }
                else
                {
                    SqlCommand insertar = new SqlCommand("ELIMINAR_CAR.insertarDependiente", DBConnector.ObtenerConexion());
                    insertar.CommandType = CommandType.StoredProcedure;
                    insertar.Parameters.Add(new SqlParameter("@id_familia", numFam));
                    insertar.Parameters.Add(new SqlParameter("@tipo_doc", (Int32)comboBox_TipoDoc.SelectedValue));
                    insertar.Parameters.Add(new SqlParameter("@n_doc", Decimal.Parse(textBox_NumDoc.Text)));
                    insertar.Parameters.Add(new SqlParameter("@nombre", textBox_NombAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@apellido", textBox_ApAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@direccion", textBox_DirecAfi.Text));
                    int telefono;
                    if (Int32.TryParse(textBox_TelAfi.Text, out telefono)) insertar.Parameters.Add(new SqlParameter("@telefono", Int64.Parse(textBox_TelAfi.Text)));
                    else insertar.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                    insertar.Parameters.Add(new SqlParameter("@mail", textBox_MailAfi.Text));
                    insertar.Parameters.Add(new SqlParameter("@fecha_nac", dtp_fecha_nac.Value));
                    insertar.Parameters.Add(new SqlParameter("@estado_civil", (Int32)comboBox_EstadoCivilAfi.SelectedItem));
                    insertar.Parameters.Add(new SqlParameter("@sexo", (Int32)comboBox_SexoAfi.SelectedItem));
                    insertar.Parameters.Add(new SqlParameter("@id_plan", ((Plan)PlanMedAfi.SelectedItem).id_plan));

                    Int64 id_afiliado = 0;
                    insertar.Parameters.Add(new SqlParameter("@id_afiliado_out", id_afiliado));
                    insertar.Parameters["@id_afiliado_out"].Direction = ParameterDirection.Output;
                    insertar.ExecuteNonQuery();

                    id_afiliado = (Int64)insertar.Parameters["@id_afiliado_out"].Value;
                }


                MessageBox.Show("El afiliado fue agregado corrrectamente\n", "Clinica-FRBA", MessageBoxButtons.OK);
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

