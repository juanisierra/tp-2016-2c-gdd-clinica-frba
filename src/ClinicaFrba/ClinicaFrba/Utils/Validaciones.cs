using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Utils
{
    class Validaciones
    {
        public static void controlNumeros(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b') //Numeros o borrar
            {
                e.Handled = false; //Se deja que entre
            }
            else
            {
                e.Handled = true; //Se cancela
            }
        }
        public static void controlLetras(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') //Numeros o borrar
            {
                e.Handled = true; //Se cancela
            }
            else
            {
                e.Handled = false; //Se deja que entre
            }
        }

    }
}
