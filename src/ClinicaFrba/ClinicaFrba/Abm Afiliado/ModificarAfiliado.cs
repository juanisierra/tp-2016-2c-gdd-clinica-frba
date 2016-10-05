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

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class ModificarAfiliado : Form
    {
        private string id_usuario { get; set; }
        private SqlConnection conexion { get; set; }
        private Afiliado afiliadoAMod = new Afiliado();

        public ModificarAfiliado(String id_usuario, Int64 id_Afiliado)
        {
            InitializeComponent();
            this.afiliadoAMod.idAfiliado = id_Afiliado;
            this.id_usuario = id_usuario;
        }

        private void ModificarAfiliado_Load(object sender, EventArgs e)
        {

        }
        

    }
}
