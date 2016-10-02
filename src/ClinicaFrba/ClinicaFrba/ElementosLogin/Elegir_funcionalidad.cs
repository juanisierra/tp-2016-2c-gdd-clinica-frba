using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.ElementosLogin
{
    public partial class Elegir_funcionalidad : Form
    {
        public int id_rol { get; set; }
        public String id_usuario { get; set; }
        public Elegir_funcionalidad(int id_rol,String id_usuario)
        {
            InitializeComponent();
            this.id_rol = id_rol;
            this.id_usuario = id_usuario;
        }

        private void Elegir_funcionalidad_Load(object sender, EventArgs e)
        {   List<Funcionalidad> funcionalidadesDisponibles = Funcionalidad.funcionalidadesPorRol(id_rol);
        cb_funcionalidad.DataSource = funcionalidadesDisponibles;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Form formularioAAbrir = Funcionalidad.formularioPorID(((Funcionalidad)cb_funcionalidad.SelectedItem).id_funcionalidad,id_usuario);
            formularioAAbrir.ShowDialog();
        }
    }
}
