using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class ListadoCancelaciones : Form
    {
        SqlConnection conexion { get; set; }

        public ListadoCancelaciones()
        {
            InitializeComponent();
            this.conexion = DBConnector.ObtenerConexion();
        }

        private void ListadoCancelaciones_Load(object sender, EventArgs e)
        {
            List<String> lista = new List<String>();
            lista.Add("Todos");
            lista.Add("Profesional");
            lista.Add("Afiliado");
            cb_cancelaciones.DataSource = lista;
        }

        private DataTable runStoredProcedure(String SP)
        {
            SqlCommand storedP = new SqlCommand(SP, conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            return dt;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (cb_cancelaciones.SelectedIndex == 0) listaFun.DataSource = runStoredProcedure("ELIMINAR_CAR.cancelaciones_totales");
            else if (cb_cancelaciones.SelectedIndex == 1) listaFun.DataSource = runStoredProcedure("ELIMINAR_CAR.cancelaciones_profesional");
            else listaFun.DataSource = runStoredProcedure("ELIMINAR_CAR.cancelaciones_afiliado");
            listaFun.Columns[0].Width = 200;
            listaFun.Columns[1].Width = 110;
            listaFun.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }


    }
}
