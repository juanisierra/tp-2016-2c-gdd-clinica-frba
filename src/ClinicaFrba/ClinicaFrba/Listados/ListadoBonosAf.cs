using ClinicaFrba.Clases;
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
    public partial class ListadoBonosAf : Form
    {
        SqlConnection conexion { get; set; }

        public ListadoBonosAf()
        {
            InitializeComponent();
            conexion = DBConnector.ObtenerConexion();
        }

        private void ListadoBonosAf_Load(object sender, EventArgs e)
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
            SqlCommand storedP = new SqlCommand("ELIMINAR_CAR.afiliados_con_mas_bonos", conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            storedP.Parameters.AddWithValue("@fecha", new DateTime(Int32.Parse(cb_anio.SelectedItem.ToString()), ((int)cb_mes.SelectedItem) + 1, 1).ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            return dt;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            listaFun.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private List<meses> mesesAMostrar(int semestre)
        {
            List<meses> lista = new List<meses>();
            if (cb_anio.SelectedIndex + 2015 == DateTime.Now.Year)
            {
                if (semestre == 0)
                {
                    if (DateTime.Now.Month <= 6) for (int j = 0; j < DateTime.Now.Month; j++) lista.Add((meses)j);
                    else for (int j = 0; j < 6; j++) lista.Add((meses)j);
                }
                else
                {
                    if (DateTime.Now.Month == 12) for (int j = 6; j < 12; j++) lista.Add((meses)j);
                    else for (int j = 6; j < DateTime.Now.Month; j++) lista.Add((meses)j);
                }
            }
            else if (cb_anio.SelectedIndex + 2015 < DateTime.Now.Year)
            {
                if (semestre == 0) for (int j = 0; j < 6; j++) lista.Add((meses)j);
                else for (int j = 6; j < 12; j++) lista.Add((meses)j);
            }
            return lista;
        }

        private void cb_semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mes.DataSource = mesesAMostrar(cb_semestre.SelectedIndex);
            if (cb_mes.Items.Count == 0) cb_mes.Enabled = false;
            else cb_mes.Enabled = true;
        }

        private void cb_anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_semestre_SelectedIndexChanged(sender, e);
        }
    }
}
