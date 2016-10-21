using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;
using ClinicaFrba.Compra_Bono;
using System.Data.SqlClient;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ABMAfiliado : Form
    {
        public String id_usuario { get; set; }
        private Afiliado afiliado = new Afiliado();
        private SqlConnection conexion { get; set; }
        SqlCommand datosAfiliado = new SqlCommand();
        private long id_afiliadoSeleccionado;
        public int id_rol { set; get; }

        public List<String> abm { set; get; }

        public List<String> crearABM()
        {
            abm = new List<String>();
            abm.Add("Alta");
            abm.Add("Baja");
            abm.Add("Modificar");
            abm.Add("Listar");
            return abm;
        }

        public ABMAfiliado(String id_usuario, int id_rol)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
        }

        private void ABMAfiliado_Load(object sender, EventArgs e)
        {
            ABMAfi.DataSource = this.crearABM();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            switch (ABMAfi.SelectedIndex)
            {
                case 0:

                    NuevoAfiliado form = new NuevoAfiliado(0, -1);
                    this.Visible = false;
                    form.ShowDialog();
                    this.Visible = true;

                    break;

                case 1:

                    SeleccionarAfiliado selecB = new SeleccionarAfiliado();
                    this.Visible = false;
                    selecB.ShowDialog();
                    this.Visible = true;
                    if (selecB.fueCerradoPorUsuario)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        Int64 id_afiliadoSeleccionado = ((Afiliado)((DataGridView)selecB.Controls["dgv_afiliado"]).CurrentRow.DataBoundItem).idAfiliado;
                        datosAfiliado = new SqlCommand(string.Format("SELECT id_afiliado, tipo_doc, numero_doc, nombre, apellido, a.id_plan, desc_plan, num_consulta_actual, precio_bono_consulta FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan) WHERE id_afiliado={0}", id_afiliadoSeleccionado), conexion);

                    }

                    EliminarAfiliado ventana = new EliminarAfiliado(this.id_usuario, this.id_afiliadoSeleccionado);
                    this.Visible = false;
                    ventana.ShowDialog();
                    this.Visible = true;

                    break;

                case 2:
                    SeleccionarAfiliado selecM = new SeleccionarAfiliado();
                    this.Visible = false;
                    selecM.ShowDialog();
                    this.Visible = true;
                    if (selecM.fueCerradoPorUsuario)
                    {
                        this.Close();
                        return;
                    }
                    else
                    {
                        Int64 id_afiliadoSeleccionado = ((Afiliado)((DataGridView)selecM.Controls["dgv_afiliado"]).CurrentRow.DataBoundItem).idAfiliado;
                        datosAfiliado = new SqlCommand(string.Format("SELECT id_afiliado, tipo_doc, numero_doc, nombre, apellido, a.id_plan, desc_plan, num_consulta_actual, precio_bono_consulta FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan) WHERE id_afiliado={0}", id_afiliadoSeleccionado), conexion);

                    }

                    ModificarAfiliado modif = new ModificarAfiliado(0, this.id_afiliadoSeleccionado);
                    this.Visible = false;
                    modif.ShowDialog();
                    this.Visible = true;

                    break;

                case 3:
                    //listar;
                    break;
            }

        }
    }
}
