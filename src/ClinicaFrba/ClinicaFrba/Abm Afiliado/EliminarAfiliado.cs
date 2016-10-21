using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class EliminarAfiliado : Form
    {        
        private string id_usuario { get; set; }
        private System.Data.SqlClient.SqlConnection conexion { get; set; }
        private Afiliado afiliado = new Afiliado();

        public EliminarAfiliado(String id_usuario, Int64 id_Afiliado)
        {
            InitializeComponent();
            this.afiliado.idAfiliado = id_Afiliado;
            this.id_usuario = id_usuario;

        }

        private void EliminarAfiliado_Load(object sender, EventArgs e)
        {

        }
    }
}
