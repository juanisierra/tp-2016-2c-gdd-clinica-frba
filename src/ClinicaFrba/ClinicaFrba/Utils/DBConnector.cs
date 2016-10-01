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
                _conexion.ConnectionString = "Data source=.\\SQLSERVER2012; Initial Catalog=GD2C2016;User Id=gd; Password=gd2016";
                _conexion.Open();
            }
            return _conexion;
        }
    }
}
