using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.Clases
{
    public class Rango_Atencion
    {
        public Int64 id_rango { set; get; }
        public Int64 matricula { set; get; }
        public DateTime fecha_desde { set; get; }
        public DateTime fecha_hasta { set; get; }
        public Boolean esValido()
        {
            return fecha_desde < fecha_hasta;
        }
        public static Rango_Atencion rangoPorProfesional(Int64 matricula)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = DBConnector.ObtenerConexion();
            comando.CommandText = "SELECT TOP 1 id_rango,matricula,fecha_desde,fecha_hasta FROM ELIMINAR_CAR.Rango_Atencion WHERE matricula=@matricula";
            comando.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
            SqlDataReader reader = comando.ExecuteReader();
            Rango_Atencion rango = null;
            if (reader.Read())
            {
                rango = new Rango_Atencion();
                rango.id_rango = reader.GetInt64(0);
                rango.matricula = reader.GetInt64(1);
                rango.fecha_desde = reader.GetDateTime(2);
                rango.fecha_hasta = reader.GetDateTime(3);
            }
            reader.Close();
            return rango;
        }
        public static List<DateTime> generarDiasRango(Rango_Atencion rango) //Devuelve todos los dias menos el domingo
        {
            List<DateTime> lista = new List<DateTime>();
            DateTime fecha = rango.fecha_desde;
            if (DateTime.Today > fecha) fecha = DateTime.Today;
            while (fecha <= rango.fecha_hasta)
            {   if(fecha.DayOfWeek!=DayOfWeek.Sunday) lista.Add(fecha);
                fecha = fecha.AddDays(1);
            }
            return lista;
        }
    }
}
