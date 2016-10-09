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

namespace ClinicaFrba.AbmRol
{
    public partial class ABMRol : Form
    {
        public String id_usuario { get; set; }
        SqlConnection conexion { get; set; }

        public ABMRol(String id_usuario)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.conexion = DBConnector.ObtenerConexion();
        }

        private void tildarFuncionalidadesDelRol()
        {
            int j = 0;            
            foreach (Funcionalidad f in Funcionalidad.funcionalidadesPorRol((int)listaRoles.SelectedRows[0].Cells[0].Value))
            {
                DataGridViewCheckBoxCell cell = listaFun.Rows[j].Cells[0] as DataGridViewCheckBoxCell;
                if (f.id_funcionalidad == (int)listaFun.Rows[j].Cells[1].Value) cell.Value = cell.TrueValue;
                j++;
            }
        }

        private void destildarTodasFun()
        {
            foreach (DataGridViewRow fila in listaFun.Rows)
            {
                DataGridViewCheckBoxCell celda = fila.Cells[0] as DataGridViewCheckBoxCell;
                celda.Value = celda.FalseValue;
            }
        }

        private Boolean estaHabilitadoRol(Int16 id_rol)
        {
            SqlCommand verificar = new SqlCommand(string.Format("select habilitado from eliminar_car.rol where id_rol='{0}'", id_rol), conexion);
            SqlDataReader reader = verificar.ExecuteReader();
            reader.Read();
            Boolean habilitado = reader.GetBoolean(0);
            reader.Close();
            return habilitado;
        }

        private int obtenerIdRol()
        {
            SqlCommand obteneRol = new SqlCommand(string.Format("select id_rol from eliminar_car.Rol where nombre_rol = '{0}'", tb_nombre.Text), conexion);
            SqlDataReader lector = obteneRol.ExecuteReader();
            lector.Read();
            int id = lector.GetInt16(0);
            lector.Close();
            return id;
        }

        private Boolean yaExisteRolACrear()
        {
            SqlCommand verificar = new SqlCommand(string.Format("select nombre_rol from eliminar_car.Rol where nombre_rol = '{0}'", tb_nombre.Text), conexion);
            SqlDataReader reader = verificar.ExecuteReader();
            String value;
            if (reader.Read())
            {
                value = reader.GetString(0);
                reader.Close();
                if (value.Equals(tb_nombre.Text, StringComparison.InvariantCultureIgnoreCase)) return true;
            }
            reader.Close();
            return false;
        }

        private void modificarTablaRol()
        {
            int habilitar = 0;
            if (cb_habilitar.Checked) habilitar = 1;
            SqlCommand agregarRol = new SqlCommand();
            if (btn_crear.Checked)
            {
                agregarRol = new SqlCommand(string.Format("insert into eliminar_car.rol (nombre_rol, habilitado) values (@nombre,@habilitado)"), conexion);
                agregarRol.Parameters.AddWithValue("@nombre", tb_nombre.Text);
                agregarRol.Parameters.AddWithValue("@habilitado", habilitar);
            }
            if (btn_modif.Checked) agregarRol = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.rol SET nombre_rol='{0}', habilitado='{2}' WHERE id_rol='{1}'", tb_nombre.Text, (int)listaRoles.SelectedRows[0].Cells[0].Value, habilitar), conexion);
            if (btn_quitar.Checked) agregarRol = new SqlCommand(string.Format("UPDATE ELIMINAR_CAR.rol SET habilitado=0 WHERE id_rol='{0}'", (int)listaRoles.SelectedRows[0].Cells[0].Value), conexion);
            agregarRol.ExecuteNonQuery();
        }

        private void modificarEntidadAsociativa()
        {
            if (btn_quitar.Checked)
            {
                eliminarRolesPorUsuario();
                return;
            }
            List<int> lista = this.obtenerIdFunChecked();
            SqlCommand agregarFuncionalidadesPorRol;
            if (btn_modif.Checked) eliminarEntidadesAsoc();
            foreach (int id in lista)
            {
                agregarFuncionalidadesPorRol = new SqlCommand(string.Format("insert into ELIMINAR_CAR.Funcionalidades_por_rol (id_rol, id_funcionalidad) values (@id_rol, @id_fun)"), conexion);
                agregarFuncionalidadesPorRol.Parameters.AddWithValue("@id_rol", obtenerIdRol());
                agregarFuncionalidadesPorRol.Parameters.AddWithValue("@id_fun", id);
                agregarFuncionalidadesPorRol.ExecuteNonQuery();
            }
        }

        private void eliminarRolesPorUsuario()
        {
            SqlCommand eliminar = new SqlCommand(string.Format("delete from ELIMINAR_CAR.Roles_por_usuarios where id_rol = {0}", (int)listaRoles.SelectedRows[0].Cells[0].Value), conexion);
            eliminar.ExecuteNonQuery();
        }

        private void eliminarEntidadesAsoc()
        {
            SqlCommand eliminarTodas = new SqlCommand(string.Format("delete from ELIMINAR_CAR.Funcionalidades_por_rol where id_rol = {0}", (int)listaRoles.SelectedRows[0].Cells[0].Value), conexion);
            eliminarTodas.ExecuteNonQuery();
        }

        private int contarCheckeadas()
        {
            int i = 0;
            foreach (DataGridViewRow row in listaFun.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value == cell.TrueValue) i++;
            }
            return i;
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

        private List<int> obtenerIdFunChecked()
        {
            List<int> lista = new List<int>();
            foreach (DataGridViewRow f in this.funCheckeadas())
            {
                lista.Add((int)f.Cells[1].Value);//obtengo el id_funcionalidad para cada uno
            }
            return lista;
        }

        private void ABMRol_Load(object sender, EventArgs e)
        {
            List<Rol> roles = Rol.rolesTotales();
            listaRoles.DataSource = roles;
            listaRoles.Columns[0].Visible = false;
            listaRoles.Columns[2].HeaderText = "Habilitado";
            listaRoles.Columns[1].Width = 190;
            listaFun.DataSource = Funcionalidad.todasLasFuncionalidades();
            listaFun.Columns[1].Visible = false;
            listaFun.Columns[2].Width = 250;
            listaFun.Columns[2].HeaderText = "Descripción";
            tb_nombre.Enabled = false;
            listaFun.ReadOnly = true;
            cb_habilitar.Enabled = false;
            btn_limpiar.Enabled = false;
        }

        private void btn_modif_CheckedChanged(object sender, EventArgs e)
        {
            btn_limpiar.Enabled = true;
            tb_nombre.ReadOnly = false;
            listaFun.ReadOnly = false;
            listaFun.Columns[2].ReadOnly = true;
            cb_habilitar.Enabled = true;
            tb_nombre.Enabled = true;
            tb_nombre.Text = listaRoles.SelectedRows[0].Cells[1].Value.ToString();
            destildarTodasFun();
            tildarFuncionalidadesDelRol();
            cb_habilitar.Checked = false;
            if (estaHabilitadoRol(Int16.Parse(listaRoles.SelectedRows[0].Cells[0].Value.ToString()))) cb_habilitar.Checked = true;
        }

        private void btn_crear_CheckedChanged(object sender, EventArgs e)
        {
            btn_limpiar.Enabled = true;
            tb_nombre.ReadOnly = false;
            listaFun.ReadOnly = false;
            listaFun.Columns[2].ReadOnly = true;
            cb_habilitar.Enabled = true;
            tb_nombre.Enabled = true;
            tb_nombre.Clear();
            this.destildarTodasFun();
            cb_habilitar.Checked = false;
        }

        private void btn_quitar_CheckedChanged(object sender, EventArgs e)
        {
            btn_modif_CheckedChanged(sender, e);
            tb_nombre.Text = listaRoles.SelectedRows[0].Cells[1].Value.ToString();
            tb_nombre.ReadOnly = true;
            listaFun.ReadOnly = true;
            cb_habilitar.Enabled = false;
            btn_limpiar.Enabled = false;
        }

        private void listaRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (btn_modif.Checked) this.btn_modif_CheckedChanged(sender, e);
            if (btn_quitar.Checked) this.btn_quitar_CheckedChanged(sender, e);
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            if (btn_crear.Checked)
            {
                btn_crear_CheckedChanged(sender, e);
            }

            if (btn_modif.Checked)
            {
                btn_modif_CheckedChanged(sender, e);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            String cadenaErrores = "";
            Boolean error = false;
            if (tb_nombre.Text == "")
            {
                cadenaErrores = cadenaErrores + "- Introduzca un nombre de rol\n";
                error = true;
            }
            if (btn_crear.Checked)
            {
                if (yaExisteRolACrear())
                {
                    cadenaErrores = cadenaErrores + "- El rol a crear ya existe\n";
                    error = true;
                }
            }
            if (btn_crear.Checked || btn_modif.Checked)
            {
                if (contarCheckeadas() == 0)
                {
                    cadenaErrores = cadenaErrores + "- Seleccione alguna funcionalidad\n";
                    error = true;
                }
            }

            if (error)
            {
                MessageBox.Show("Solucione los siguientes errores:\n\n"+cadenaErrores, "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.modificarTablaRol();
                this.modificarEntidadAsociativa(); //agrega a funcionalidades_por_rol
                btn_crear.Checked = true;
                DialogResult resultado = MessageBox.Show("Operación realizada con éxito!", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultado == DialogResult.OK) this.Close();
            }
        }
    }
}
