using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{
    static class Program
    { 
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnector.ObtenerConexion();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
           /* using ( SqlConnection conexion =  DBConnector.ObtenerConexion()){

            SqlCommand comando = new SqlCommand("SELECT * FROM ELIMINAR_CAR.Afiliado",conexion);
            comando.ExecuteNonQuery();*/
            DBConnector.ObtenerConexion().Close();
            }
        }
    }

