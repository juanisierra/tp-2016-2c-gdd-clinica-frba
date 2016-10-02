﻿using System;
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
            SqlCommand funcionalidades = new SqlCommand(string.Format("SELECT descripcion FROM ELIMINAR_CAR.Funcionalidad"), conexion);
            SqlDataReader lector = funcionalidades.ExecuteReader();

            ListaFun.Columns[1].DataPropertyName = "Descripcion";
            
            while (lector.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.descripcion = lector.GetString(0);
                ListaFun.Rows.Add(0,func);//0 los pone sin seleccionar, 1 seleccionados
            }
            lector.Close();
        }

        private void ListaFun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
