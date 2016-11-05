using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba
{
    class DBConnector
    {
        private static SqlConnection _conexion = new SqlConnection();
        public static SqlConnection ObtenerConexion()
        {
            if (_conexion.State == ConnectionState.Closed)
            {
                _conexion.ConnectionString = "Data source=" + System.Configuration.ConfigurationManager.AppSettings["DBSource"] + "; Initial Catalog=" + System.Configuration.ConfigurationManager.AppSettings["DBInitialCatalog"] + ";User Id=" + System.Configuration.ConfigurationManager.AppSettings["DBUser"] + "; Password=" + System.Configuration.ConfigurationManager.AppSettings["DBPassword"];
                _conexion.Open();
            }
            return _conexion;
        }
    }
}
