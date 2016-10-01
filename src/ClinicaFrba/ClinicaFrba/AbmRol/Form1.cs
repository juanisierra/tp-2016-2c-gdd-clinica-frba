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
    public partial class NuevoRol : Form
    {
        public NuevoRol()
        {
            InitializeComponent();
            SqlConnection conexion = DBConnector.ObtenerConexion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NuevoRol_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand funcionalidades = new SqlCommand("SELECT descripcion FROM ELIMINAR_CAR.Funcionalidad", conexion);
            SqlDataReader lector = funcionalidades.ExecuteReader();

            while (lector.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.descripcion = lector.GetString(0);
                ListaFun.ColumnCount = 1;
                ListaFun.Columns[0].Name = "Descripcion";
                ListaFun.Rows.Add(func);
            }
            lector.Close();
        }
    }
}
