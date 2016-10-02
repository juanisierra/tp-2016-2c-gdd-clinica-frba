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

namespace ClinicaFrba.AbmRol
{
    public partial class ABMRol : Form
    {
        private string id_usuario { get; set; }
        private SqlConnection conexion { get; set; }

        public ABMRol(string id_usuario)
        {
            InitializeComponent();
            this.conexion = DBConnector.ObtenerConexion();
            this.id_usuario = id_usuario;
        }

        private void limpiarFuncionalidades()
        {
            foreach (DataGridViewRow f in listaFun.Rows)
            {
                DataGridViewCheckBoxCell cell = f.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value == cell.TrueValue) cell.Value = false;
            }
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

            listaFun.DataSource = lista;
            listaFun.Columns[1].Visible = false;
            listaFun.Columns[2].Width = 250;
            listaFun.Columns[2].HeaderText = "Descripción";
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            tb_nombre.Clear();
            this.limpiarFuncionalidades();
            if (cb_habilitar.Checked) cb_habilitar.Checked = false;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.agregarATablaRol();
            this.agregarAEntidadAsociativa();
            this.btn_limpiar_Click(sender, e);
        }

        private void agregarATablaRol()
        {
            int habilitar = 0;
            if (cb_habilitar.Checked) habilitar = 1;
            SqlCommand agregarRol = new SqlCommand(string.Format("insert into eliminar_car.rol (nombre_rol, habilitado) values (@nombre,@habilitado)"), conexion);
            agregarRol.Parameters.AddWithValue("@nombre", tb_nombre.Text);
            agregarRol.Parameters.AddWithValue("@habilitado", habilitar);
            agregarRol.ExecuteNonQuery();
        }

        private int obtenerIdRol()
        {
            SqlCommand obteneRol = new SqlCommand(string.Format("select id_rol from eliminar_car.Rol where nombre_rol = '{0}'",tb_nombre.Text), conexion);
            SqlDataReader lector = obteneRol.ExecuteReader();
            lector.Read();
            int id = lector.GetInt16(0);
            lector.Close();
            return id;
        }

        private void agregarAEntidadAsociativa()
        {
            List<int> lista = this.obtenerIdFunChecked();
            foreach (int id in lista)
            {
                SqlCommand agregarFuncionalidadesPorRol = new SqlCommand(string.Format("insert into ELIMINAR_CAR.Funcionalidades_por_rol (id_rol, id_funcionalidad) values (@id_rol, @id_fun)"), conexion);
                agregarFuncionalidadesPorRol.Parameters.AddWithValue("@id_rol", this.obtenerIdRol());
                
                agregarFuncionalidadesPorRol.Parameters.AddWithValue("@id_fun", id);
                agregarFuncionalidadesPorRol.ExecuteNonQuery();
            }
        }

        private List<int> obtenerIdFunChecked()
        {
            List<int> lista = new List<int>();
            foreach (DataGridViewRow f in listaFun.Rows)
            {
                DataGridViewCheckBoxCell cell = f.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value == cell.TrueValue) lista.Add((int)f.Cells[1].Value);//obtengo el id_funcionalidad para cada uno
            }
            return lista;
        }
    }
}
