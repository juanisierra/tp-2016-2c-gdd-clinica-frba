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
    public partial class ListadoBonosEsp : Form
    {
        SqlConnection conexion { get; set; }

        public ListadoBonosEsp()
        {
            InitializeComponent();
            conexion = DBConnector.ObtenerConexion();
        }

        private void ListadoBonosEsp_Load(object sender, EventArgs e)
        {
            List<String> lista1 = new List<String>();
            int anio = 2015;
            lista1.Add(anio.ToString());
            while (anio < DateTime.Now.Year)
            {
                anio++;
                lista1.Add(anio.ToString());
            }
            cb_anio.DataSource = lista1;

            List<String> lista2 = new List<String>();
            lista2.Add("Primero");
            lista2.Add("Segundo");
            cb_semestre.DataSource = lista2;
        }

        private DataTable runStoredProcedure()
        {
            SqlCommand storedP = new SqlCommand("ELIMINAR_CAR.especialidades_con_mas_bonos", conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            storedP.Parameters.AddWithValue("@fecha", new DateTime(Int32.Parse(cb_anio.SelectedItem.ToString()), mesSeleccionado(), 1).ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            return dt;
        }

        private int mesSeleccionado()
        {
            if (cb_semestre.SelectedIndex == 0) return cb_mes.SelectedIndex + 1;
            else return cb_mes.SelectedIndex + 7;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            listaFun.DataSource = runStoredProcedure();
            listaFun.Columns[0].Width = 200;
            listaFun.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private List<String> mesesAMostrar(int i)
        {
            List<String> primerosMeses = new List<String>();
            if (i == 0)
            {
                primerosMeses.Add("Enero");
                primerosMeses.Add("Febrero");
                primerosMeses.Add("Marzo");
                primerosMeses.Add("Abril");
                primerosMeses.Add("Mayo");
                primerosMeses.Add("Junio");
            }
            else if (i == 1)
            {
                primerosMeses.Add("Julio");
                primerosMeses.Add("Agosto");
                primerosMeses.Add("Septiembre");
                primerosMeses.Add("Octubre");
                primerosMeses.Add("Noviembre");
                primerosMeses.Add("Diciembre");
            }
            return primerosMeses;
        }

        private void cb_semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mes.DataSource = mesesAMostrar(cb_semestre.SelectedIndex);
        }
    }
}
