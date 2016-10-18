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
            Plan plan = new Plan();
            plan.id_plan = -1;
            plan.desc_plan = "Todos";
            List<Plan> lista = new List<Plan>();
            lista.Add(plan);
            lista.AddRange(Plan.traerPlanes());
            cb_plan.DataSource = lista;
            cb_plan.DisplayMember = "desc_plan";
        }

        private DataTable runStoredProcedure()
        {
            SqlCommand storedP = new SqlCommand("ELIMINAR_CAR.profesionales_mas_consultados", conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            storedP.Parameters.AddWithValue("@id_plan", ((Plan)cb_plan.SelectedItem).id_plan);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            return dt;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            listaFun.DataSource = runStoredProcedure();
            listaFun.Columns[2].Width = 120;
            listaFun.Columns[3].Width = 200;
            listaFun.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

    }
}
