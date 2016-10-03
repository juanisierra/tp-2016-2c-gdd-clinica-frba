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
    public partial class ModifRol : Form
    {
        public DataGridViewRow rolAModificar { get; set; }

        public ModifRol(DataGridViewRow seleccionado)
        {
            InitializeComponent();
            this.rolAModificar = seleccionado;
        }

        private void ModifRol_Load(object sender, EventArgs e)
        {
            tb_nombre.Text = (String)rolAModificar.Cells[1].Value;
            listaFun.DataSource = Funcionalidad.todasLasFuncionalidades();
            tildarFuncionalidadesDelRol();
            listaFun.Columns[1].ReadOnly = true;
        }

        private void tildarFuncionalidadesDelRol()
        {
            int j=0;
            foreach (Funcionalidad f in Funcionalidad.funcionalidadesPorRol((int)rolAModificar.Cells[0].Value)) j++;
            if (j == 0)
            {
                foreach (DataGridViewRow f in listaFun.Rows)
                {
                    DataGridViewCheckBoxCell cell = f.Cells[0] as DataGridViewCheckBoxCell;
                    if (cell.Value == cell.TrueValue) cell.Value = false;
                }
            }
            else
            {
                j = 0;
                foreach (Funcionalidad f in Funcionalidad.funcionalidadesPorRol((int)rolAModificar.Cells[0].Value))
                {
                    DataGridViewCheckBoxCell cell = listaFun.Rows[j].Cells[0] as DataGridViewCheckBoxCell;
                    if (f.id_funcionalidad == (int)listaFun.Rows[j].Cells[1].Value)
                    {
                        cell.Value = cell.TrueValue;
                    }
                    j++;
                }
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            tb_nombre.Text = (String)rolAModificar.Cells[1].Value;
            tildarFuncionalidadesDelRol();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            actualizarTablaRol();
            actualizarFuncXRol();
        }

        private void actualizarTablaRol()
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand modificarRol = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.rol SET nombre_rol='{0}' WHERE id_rol='{1}'", tb_nombre.Text, (int)rolAModificar.Cells[0].Value), conexion);
            modificarRol.ExecuteNonQuery();
        }

        private void actualizarFuncXRol()
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand eliminarTodas = new SqlCommand(string.Format("delete from ELIMINAR_CAR.Funcionalidades_por_rol where id_rol = {0}", (int)rolAModificar.Cells[0].Value), conexion);
            eliminarTodas.ExecuteNonQuery();
            foreach (DataGridViewRow f in funCheckeadas())
            {
                SqlCommand agregarCheckeadas = new SqlCommand(string.Format("insert into ELIMINAR_CAR.Funcionalidades_por_rol (id_rol, id_funcionalidad) values (@rol,@funcionalidad)"), conexion);
                agregarCheckeadas.Parameters.AddWithValue("@rol", (int)rolAModificar.Cells[0].Value);
                agregarCheckeadas.Parameters.AddWithValue("@funcionalidad", (int)f.Cells[1].Value);
                agregarCheckeadas.ExecuteNonQuery();
            }
        }

        private List<DataGridViewRow> funCheckeadas()
        {
            List<DataGridViewRow> lista = new List<DataGridViewRow>();
            foreach (DataGridViewRow r in listaFun.Rows)
            {
                DataGridViewCheckBoxCell cell = r.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value == cell.TrueValue) lista.Add(r);
            }
            return lista;
        }
    }
}