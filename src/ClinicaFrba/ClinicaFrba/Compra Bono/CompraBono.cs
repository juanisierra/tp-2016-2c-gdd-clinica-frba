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
        const int ancho = 570;
        const int altoAdmin = 705;
        const int altoAfiliado = 226;

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
            conexion = DBConnector.ObtenerConexion();
            if (id_rol == 1)
            {
                this.Height = altoAfiliado;
                dtgAfiliados.Enabled = false;
                dtgAfiliados.Visible = false;
                SqlCommand datosAfiliado = new SqlCommand(string.Format("SELECT id_afiliado, tipo_doc, numero_doc, nombre, apellido, a.id_plan, desc_plan, num_consulta_actual, precio_bono_consulta FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan) WHERE usuario='{0}'", id_usuario), conexion);

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
            }
            else
            {
                SqlCommand afiliados = new SqlCommand(string.Format("SELECT id_afiliado, nombre, apellido, tipo_doc, numero_doc, fecha_nac, direccion, telefono, desc_plan, a.id_plan, num_consulta_actual, activo, fecha_baja FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan)"), conexion);
                List<Afiliado> lista = Afiliado.listarAfiliadosCompraBonos(afiliados);
                dtgAfiliados.DataSource = lista;
                dtgAfiliados.MultiSelect = false;
                chkFiltro.Checked = true;
                dtgAfiliados.Columns[7].Visible = false;
                dtgAfiliados.Columns[9].Visible = false;
                dtgAfiliados.Columns[10].Visible = false;
                dtgAfiliados.Columns[11].Visible = false;
                dtgAfiliados.Columns[13].Visible = false;
                dtgAfiliados.Columns[14].Visible = false;
                dtgAfiliados.Columns[18].Visible = false;
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
                SqlCommand estado = new SqlCommand(string.Format(
                    "SELECT activo FROM ELIMINAR_CAR.Afiliado WHERE id_afiliado={0}", id_afiliado), conexion);
                reader = estado.ExecuteReader();
                reader.Read();
                if (!reader.GetBoolean(0))
                    return;
                reader.Close();

                string fecha_compra = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //Insertar en Compra_Bonos
                SqlCommand insertarBono = new SqlCommand(string.Format(
                    "INSERT INTO ELIMINAR_CAR.Compra_Bonos (id_afiliado_comprador, precio_total, fecha_compra, cantidad_bonos) VALUES ({0}, {1}, '{2}', {3})", id_afiliado, precioTotal, fecha_compra, cantidadComprada), conexion);
                insertarBono.ExecuteNonQuery();
                //Insertar en Bono
                for (int j = 0; j < cantidadComprada; j++)
                {
                    insertarBono = new SqlCommand(string.Format(
                    "INSERT INTO ELIMINAR_CAR.Bono (id_bono, id_afiliado_comprador, id_afiliado_consumidor, num_consulta, id_plan, utilizado, precio, fecha_compra, fecha_uso) VALUES ({4}, {0}, NULL, NULL , {1}, 0, (SELECT (precio_bono_consulta) FROM ELIMINAR_CAR.Planes WHERE id_plan={2}), '{3}', NULL)", id_afiliado, id_plan, id_plan, fecha_compra, j + 9999999), conexion);
                    insertarBono.ExecuteNonQuery();
                }
            }
            else
            {
                txtCantCompra.Text = "";
                lblPrecioF.Text = "";
            }
        }



        private void dtgAfiliados_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgAfiliados.SelectedRows.Count != 0)
            {
                txtAfiliado.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[0].Value);
                txtNombre.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[3].Value);
                txtApellido.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[4].Value);
                txtPlan.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[12].Value);
                txtTipoDoc.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[1].Value);
                txtNroDoc.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[2].Value);
                txtCantidad.Text = Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[17].Value);
                id_plan = Convert.ToInt32(dtgAfiliados.SelectedRows[0].Cells[11].Value);
                SqlCommand precioBono = new SqlCommand(string.Format(
                "SELECT precio_bono_consulta FROM ELIMINAR_CAR.Planes WHERE id_plan={0}", Convert.ToString(dtgAfiliados.SelectedRows[0].Cells[11].Value)), conexion);
                reader = precioBono.ExecuteReader();
                reader.Read();
                txtPrecioU.Text = Convert.ToString(reader.GetInt32(0));
                reader.Close();
            }

            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SqlCommand filtrar;
            string condId = "id_afiliado={0}";
            string condNroDoc = "numero_doc={1}";
            string condNombre = "nombre LIKE '%{2}%'";
            string condApellido = "apellido LIKE '%{3}%'";
            string condPlan = "desc_plan LIKE '%{4}%'";
            string filtro = " and ";
            long id_afiliado;
            Decimal nroDoc;
            string plan = "";

            if (!chkFiltro.Checked && ((txtFiltroId.Text != "") || (txtFiltroDoc.Text != "") || (txtFiltroPlan.Text != "") || (txtFiltroNombre.Text != "") || (txtFiltroApellido.Text != "")))
            {
                filtro = " or ";
            }

            if (txtFiltroId.Text == "")
            {
                if (filtro==" and ")
                    condId = "{0}={0}";
                else
                    condId = "{0}!={0}";
                id_afiliado = 1;
            }
            else
                id_afiliado = Convert.ToInt64(txtFiltroId.Text);
            if (txtFiltroDoc.Text == "")
            {
                if (filtro==" and ")
                    condNroDoc = "{1}={1}";
                else
                    condNroDoc = "{1}!={1}";
                nroDoc = 1;
            }
            else
                nroDoc = Convert.ToDecimal(txtFiltroDoc.Text);
            if (txtFiltroPlan.Text == "")
            {
                if (filtro==" and ")
                    condPlan = "{4}={4}";
                else
                    condPlan = "{4}!={4}";
                id_plan = 1;
            }
            else
                plan = txtFiltroPlan.Text;
            if (txtFiltroNombre.Text == "")
                if (filtro==" and ")
                    condNombre = "'{2}'='{2}'";
                else
                    condNombre = "'{2}'!='{2}'";
            if (txtFiltroApellido.Text == "")
                if (filtro==" and ")
                    condApellido = "'{3}'='{3}'";
                else
                    condApellido = "'{3}'!='{3}'";

            string consulta = "SELECT id_afiliado, nombre, apellido, tipo_doc, numero_doc, fecha_nac, direccion, telefono, desc_plan, a.id_plan, num_consulta_actual, activo, fecha_baja FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan) WHERE " + condId + filtro + condNroDoc + filtro + condNombre + filtro + condApellido + filtro + condPlan;
            filtrar = new SqlCommand(string.Format(consulta, id_afiliado, nroDoc, txtFiltroNombre.Text, txtFiltroApellido.Text, plan), conexion);
            List<Afiliado> lista = Afiliado.listarAfiliadosCompraBonos(filtrar);
            dtgAfiliados.DataSource = lista;
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
