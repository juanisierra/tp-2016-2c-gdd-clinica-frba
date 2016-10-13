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

namespace ClinicaFrba.Compra_Bono
{
    public partial class CompraBonos : Form
    {
        private string id_usuario { get; set; }
        private int id_rol { get; set; }
        private SqlConnection conexion { get; set; }
        int id_plan;


        SqlDataReader reader;

        public CompraBonos()
        {
            InitializeComponent();
        }

        public CompraBonos(string id_usuario, int id_rol)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
        }

        private void CompraBonos_Load(object sender, EventArgs e)
        {
             
            SqlCommand datosAfiliado = new SqlCommand();
            conexion = DBConnector.ObtenerConexion();
            if (id_rol == 1)
            {   
                datosAfiliado = new SqlCommand(string.Format("SELECT id_afiliado, tipo_doc, numero_doc, nombre, apellido, a.id_plan, desc_plan, num_consulta_actual, precio_bono_consulta FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan) WHERE usuario='{0}'", id_usuario), conexion);
            }
            else
            {
                SeleccionarAfiliado form = new SeleccionarAfiliado();
                form.ShowDialog();
                if (form.fueCerradoPorUsuario)
                {
                    this.Close();
                    return;
                }
                else
                {
                    Int64 id_afiliadoSeleccionado = ((Afiliado)((DataGridView)form.Controls["dgv_afiliado"]).CurrentRow.DataBoundItem).idAfiliado;
                    datosAfiliado = new SqlCommand(string.Format("SELECT id_afiliado, tipo_doc, numero_doc, nombre, apellido, a.id_plan, desc_plan, num_consulta_actual, precio_bono_consulta FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan) WHERE id_afiliado={0}", id_afiliadoSeleccionado), conexion);

                }
            }
            reader = datosAfiliado.ExecuteReader();

            reader.Read();
            txtAfiliado.Text = Convert.ToString(reader.GetInt64(0));
            txtTipoDoc.Text = Convert.ToString(reader.GetInt32(1));
            txtNroDoc.Text = Convert.ToString(reader.GetDecimal(2));
            txtNombre.Text = reader.GetString(3);
            txtApellido.Text = reader.GetString(4);
            id_plan = reader.GetInt32(5);
            txtPlan.Text = reader.GetString(6);
            txtCantidad.Text = Convert.ToString(reader.GetInt64(7));
            txtPrecioU.Text = Convert.ToString(reader.GetInt32(8));

            reader.Close();
            txtCantCompra.KeyPress += controlNumeros;
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
        private void btnComprar_Click(object sender, EventArgs e)
        {
            long id_afiliado = Convert.ToInt64(txtAfiliado.Text);
            int cantidadComprada = Convert.ToInt32(txtCantCompra.Text);
            int precioTotal = Convert.ToInt32(txtPrecioU.Text) * cantidadComprada;
            lblPrecioF.Text = Convert.ToString(precioTotal);

            if (MessageBox.Show("¿Está seguro? \n" + txtCantCompra.Text + " bonos a $" + Convert.ToString(precioTotal), "Cofirmar operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlCommand insertarBonos = new SqlCommand("ELIMINAR_CAR.comprar_bono", DBConnector.ObtenerConexion());
                insertarBonos.CommandType = CommandType.StoredProcedure;
                insertarBonos.Parameters.Add(new SqlParameter("@id_afiliado", id_afiliado));
                insertarBonos.Parameters.Add(new SqlParameter("@cant_bonos",cantidadComprada));
                insertarBonos.Parameters.Add(new SqlParameter("@fecha_compra", DateTime.Now));
                insertarBonos.ExecuteNonQuery();
                MessageBox.Show("Compra de Bonos Realizada","Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantCompra.Text = "";
                lblPrecioF.Text = "";
            }
            else
            {
                txtCantCompra.Text = "";
                lblPrecioF.Text = "";
            }
        }





        
        private void txtCantCompra_TextChanged(object sender, EventArgs e)
        {

            if (txtCantCompra.Text != "")
            {
                int cantidadComprada = Convert.ToInt32(txtCantCompra.Text);
                int precioTotal = Convert.ToInt32(txtPrecioU.Text) * cantidadComprada;
                lblPrecioF.Text = Convert.ToString(precioTotal);
            }
            else
                lblPrecioF.Text = "";
        }



    }
}
