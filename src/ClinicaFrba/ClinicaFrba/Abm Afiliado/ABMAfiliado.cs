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
        private Afiliado afiliadoSeleccionado;
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
                        afiliadoSeleccionado = ((Afiliado)((DataGridView)selecB.Controls["dgv_afiliado"]).CurrentRow.DataBoundItem);
                       
                    }

                    DialogResult resultado = MessageBox.Show("¿Desea eliminar a este afiliado?", "Clinica-FRBA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.OK)
                    {
                        SqlCommand eliminar;
                        if (afiliadoSeleccionado.idAfiliado.ToString().EndsWith("01")) eliminar = new SqlCommand("ELIMINAR_CAR.eliminarAfiliadoRaiz", DBConnector.ObtenerConexion());
                        else eliminar = new SqlCommand("ELIMINAR_CAR.eliminarAfiliadoNoRaiz", DBConnector.ObtenerConexion());
                        eliminar.CommandType = CommandType.StoredProcedure;
                        eliminar.Parameters.Add(new SqlParameter("@id_afiliado",(Int64) afiliadoSeleccionado.idAfiliado));
                        eliminar.Parameters.Add(new SqlParameter("@id_familia", (Int64)afiliadoSeleccionado.idFamilia));
                        eliminar.ExecuteNonQuery();
                        MessageBox.Show("El afiliado fue eliminado correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                    }

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
                        afiliadoSeleccionado = ((Afiliado)((DataGridView)selecM.Controls["dgv_afiliado"]).CurrentRow.DataBoundItem);
                        
                    }

                    ModificarAfiliado modif = new ModificarAfiliado(this.afiliadoSeleccionado);
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
