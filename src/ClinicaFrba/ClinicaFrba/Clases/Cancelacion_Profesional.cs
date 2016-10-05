using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.Clases
{
    class Cancelacion_Profesional
    {
        public Int64 id_cancelacion { set; get; }
        public Int64 matricula { get; set; }
        public String motivo { set; get; }
        public int id_especialidad { set; get; }
        public DateTime fecha_desde { set; get; }
        public DateTime fecha_hasta { set; get; }
        public static List<Cancelacion_Profesional> cancelacionesPorProfesionalYEspecialidad(Int64 matricula,int id_especialidad)
        {
            SqlCommand traerCancelaciones = new SqlCommand();
            traerCancelaciones.Connection = DBConnector.ObtenerConexion();
            traerCancelaciones.CommandText = "SELECT id_cancelacion,matricula,id_especialidad,fecha_desde,fecha_hasta FROM ELIMINAR_CAR.Cancelacion_Profesional WHERE matricula=@matricula AND id_especialidad=@id_especialidad";
            traerCancelaciones.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
            traerCancelaciones.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = id_especialidad;
            SqlDataReader reader = traerCancelaciones.ExecuteReader();
            List<Cancelacion_Profesional> lista = new List<Cancelacion_Profesional>();
            while (reader.Read())
            {
                Cancelacion_Profesional c = new Cancelacion_Profesional();
                c.id_cancelacion = reader.GetInt64(0);
                c.matricula = reader.GetInt64(1);
                c.id_especialidad = reader.GetInt32(2);
                c.fecha_desde = reader.GetDateTime(3);
                c.fecha_hasta = reader.GetDateTime(4);
                lista.Add(c);
            }
            reader.Close();
            return lista;
        }
        public List<DateTime> diasCancelados()
        {
            List<DateTime> lista = new List<DateTime>();
            DateTime fecha = fecha_desde;
            while (fecha <= fecha_hasta)
            {
                lista.Add(fecha);
                fecha = fecha.AddDays(1);
            }
            return lista;
        }

    }
}
