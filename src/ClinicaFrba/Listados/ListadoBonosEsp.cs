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
    public partial class ListadoBonosEsp : Form
    {
        SqlConnection conexion { get; set; }
        DateTime fechaParametro { get; set; }

        public ListadoBonosEsp(DateTime fechaP)
        {
            InitializeComponent();
            conexion = DBConnector.ObtenerConexion();
            this.fechaParametro = fechaP;
        }

        private void ListadoBonosEsp_Load(object sender, EventArgs e)
        {
            if (this.fechaParametro.Year < 2015)
            {
                cb_anio.Enabled = false;
                cb_mes.Enabled = false;
                cb_semestre.Enabled = false;
                btn_aceptar.Enabled = false;
            }
            else
            {
                List<int> lista1 = new List<int>();
                int anio = 2015;
                lista1.Add(anio);
                while (anio < this.fechaParametro.Year)
                {
                    anio++;
                    lista1.Add(anio);
                }
                cb_anio.DataSource = lista1;

                List<String> lista2 = new List<String>();
                lista2.Add("Primero");
                lista2.Add("Segundo");
                cb_semestre.DataSource = lista2;
            }
        }

        private DataTable runStoredProcedure()
        {
            SqlCommand storedP = new SqlCommand("ELIMINAR_CAR.especialidades_con_mas_bonos", conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            storedP.Parameters.AddWithValue("@fecha", new DateTime((int)cb_anio.SelectedItem, ((int)cb_mes.SelectedItem)+1, 1).ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            return dt;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            listaFun.DataSource = runStoredProcedure();
            listaFun.Columns[0].Width = 200;
            listaFun.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private List<meses> mesesAMostrar(int semestre)
        {
            List<meses> lista = new List<meses>();
            if (cb_anio.SelectedIndex + 2015 == this.fechaParametro.Year)
            {
                if (semestre == 0)
                {
                    if (this.fechaParametro.Month <= 6) for (int j = 0; j < this.fechaParametro.Month; j++) lista.Add((meses)j);
                    else for (int j = 0; j < 6; j++) lista.Add((meses)j);
                }
                else
                {
                    if (this.fechaParametro.Month == 12) for (int j = 6; j < 12; j++) lista.Add((meses)j);
                    else for (int j = 6; j < this.fechaParametro.Month; j++) lista.Add((meses)j);
                }
            }
            else if (cb_anio.SelectedIndex + 2015 < this.fechaParametro.Year)
            {
                if (semestre == 0) for (int j = 0; j < 6; j++) lista.Add((meses)j);
                else for (int j = 6; j < 12; j++) lista.Add((meses)j);
            }
            return lista;
        }

        private Boolean hayMesesDisponibles()
        {
            return cb_mes.Items.Count > 0;
        }

        private void cb_semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mes.DataSource = mesesAMostrar(cb_semestre.SelectedIndex);
            cb_mes.Enabled = hayMesesDisponibles();
            btn_aceptar.Enabled = hayMesesDisponibles();
        }

        private void cb_anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_semestre_SelectedIndexChanged(sender, e);
        }
    }
}
