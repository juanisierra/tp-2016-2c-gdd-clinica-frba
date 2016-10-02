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
using System.Data;

namespace ClinicaFrba.AbmRol
{
    public partial class ABMRol : Form
    {
        private string id_usuario;

        public ABMRol()
        {
            InitializeComponent();
            SqlConnection conexion = DBConnector.ObtenerConexion();
        }

        public ABMRol(string id_usuario)
        {
            InitializeComponent();
            SqlConnection conexion = DBConnector.ObtenerConexion();
            this.id_usuario = id_usuario;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NuevoRol_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand funcionalidades = new SqlCommand(string.Format("SELECT id_funcionalidad, descripcion FROM ELIMINAR_CAR.Funcionalidad"), conexion);
            SqlDataReader lector = funcionalidades.ExecuteReader();

            List<Funcionalidad> lista = new List<Funcionalidad>();
            
            while (lector.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.id_funcionalidad = lector.GetInt16(0);
                func.descripcion = lector.GetString(1);
                lista.Add(func);
            }
            lector.Close();

            ListaFun.DataSource = lista;
            ListaFun.Columns[1].Visible = false;
            ListaFun.Columns[2].Width = 250;
            ListaFun.Columns[2].HeaderText = "Descripcion";
        }

        private void ListaFun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
