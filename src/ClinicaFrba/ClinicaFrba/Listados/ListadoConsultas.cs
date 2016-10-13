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

namespace ClinicaFrba.Listados
{
    public partial class ListadoConsultas : Form
    {
        SqlConnection conexion { get; set; }

        public ListadoConsultas()
        {
            InitializeComponent();
            this.conexion = DBConnector.ObtenerConexion();
        }

        private void ListadoConsultas_Load(object sender, EventArgs e)
        {
            SqlCommand storedP = new SqlCommand("ELIMINAR_CAR.profesionales_mas_consultados", conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            storedP.Parameters.Add("@id_plan", 555555);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            listaFun.DataSource = dt;
        }

    }
}
