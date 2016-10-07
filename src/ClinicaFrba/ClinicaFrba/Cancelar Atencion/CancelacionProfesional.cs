using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelacionProfesional : Form
    {
        private string id_usuario;
        private int id_rol;

        public CancelacionProfesional()
        {
            InitializeComponent();
        }

        public CancelacionProfesional(string id_usuario, int id_rol)
        {
            // TODO: Complete member initialization
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
        }
    }
}
