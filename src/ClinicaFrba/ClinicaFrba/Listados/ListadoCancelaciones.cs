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

        private DataTable runStoredProcedure(String SP)
        {
            SqlCommand storedP = new SqlCommand(SP, conexion);
            storedP.CommandType = CommandType.StoredProcedure;
            storedP.Parameters.AddWithValue("@fecha", new DateTime(Int32.Parse(cb_anio.SelectedItem.ToString()),mesSeleccionado(),1).ToString());
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(storedP);
            adapter.Fill(dt);
            return dt;
        }

        private int mesSeleccionado()
        {
            if (cb_semestre.SelectedIndex == 0) return cb_mes.SelectedIndex + 1;
            return cb_mes.SelectedIndex + 7;
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
            else
            {
                if (semestre == 0) for (int j = 0; j < 6; j++) lista.Add((meses)j);
                else for (int j = 6; j < 12; j++) lista.Add((meses)j);
            }
            return lista;
        }
        
        private void cb_semestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mes.DataSource = mesesAMostrar(cb_semestre.SelectedIndex);
        }

        private void cb_anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_semestre_SelectedIndexChanged(sender, e);
        }

    }
}
