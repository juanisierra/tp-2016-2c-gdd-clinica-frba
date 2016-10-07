using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.Clases
{
    public class Turno
    {
       public Int64 id_turno { set; get; }
       public DateTime fecha_estipulada { set; get; }
       public Int64 matricula { set; get; }
       public Int64 id_afiliado { set; get; }
       public String afiliado_nombre { set; get; }
       public String afiliado_apellido { set; get; }
       public  Nullable<Int64> id_bono { set; get; }
       public Nullable<DateTime> momento_llegada { set; get; }
       public  int id_especialidad { set; get; }
       public String desc_especialidad { set; get; }
       public Boolean activo { set; get; }
        public static List<Turno> turnosFuturosPorProfesionalYEspecialidad(Int64 matricula, int id_especialidad)
        {
            List<Turno> turnos = new List<Turno>();
            SqlCommand traerTurnos = new SqlCommand();
            traerTurnos.CommandText = "ELIMINAR_CAR.turnosFuturosPorProfesionalYEspecialidad";
            traerTurnos.CommandType = CommandType.StoredProcedure;
            traerTurnos.Connection = DBConnector.ObtenerConexion();
            traerTurnos.Parameters.Add("@matricula",SqlDbType.BigInt).Value = matricula;
            traerTurnos.Parameters.Add("@id_especialidad",SqlDbType.Int).Value = id_especialidad;
            SqlDataReader reader = traerTurnos.ExecuteReader();
            while (reader.Read())
            {
                Turno turno = new Turno();
                turno.id_turno = reader.GetInt64(0);
                turno.fecha_estipulada = reader.GetDateTime(1);
                turno.matricula = reader.GetInt64(2);
                turno.id_afiliado = reader.GetInt64(3);
                if (!reader.IsDBNull(4)) turno.id_bono = reader.GetInt64(4);
                else turno.id_bono = null;
                if (!reader.IsDBNull(5)) turno.momento_llegada = reader.GetDateTime(5);
                else turno.momento_llegada = null;
                turno.id_especialidad = reader.GetInt32(6);
                turno.activo = reader.GetBoolean(7);
                turno.desc_especialidad = reader.GetString(8);
                turno.afiliado_nombre = reader.GetString(9);
                turno.afiliado_apellido = reader.GetString(10);
                turnos.Add(turno);
            }
            reader.Close();
            return turnos;
        }
        public static List<Turno> turnosDelDiaPorProfesional(Int64 matricula,DateTime dia)
        {
            List<Turno> turnos = new List<Turno>();
            SqlCommand traerTurnos = new SqlCommand();
            traerTurnos.CommandText = "ELIMINAR_CAR.turnosDelDiaPorProfesional";
            traerTurnos.CommandType = CommandType.StoredProcedure;
            traerTurnos.Connection = DBConnector.ObtenerConexion();
            traerTurnos.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
            traerTurnos.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dia;
            SqlDataReader reader = traerTurnos.ExecuteReader();
            while (reader.Read())
            {
                Turno turno = new Turno();
                turno.id_turno = reader.GetInt64(0);
                turno.fecha_estipulada = reader.GetDateTime(1);
                turno.matricula = reader.GetInt64(2);
                turno.id_afiliado = reader.GetInt64(3);
                if (!reader.IsDBNull(4)) turno.id_bono = reader.GetInt64(4);
                else turno.id_bono = null;
                if (!reader.IsDBNull(5)) turno.momento_llegada = reader.GetDateTime(5);
                else turno.momento_llegada = null;
                turno.id_especialidad = reader.GetInt32(6);
                turno.activo = reader.GetBoolean(7);
                turno.desc_especialidad = reader.GetString(8);
                turno.afiliado_nombre = reader.GetString(9);
                turno.afiliado_apellido = reader.GetString(10);
                turnos.Add(turno);
            }
            reader.Close();
            return turnos;
        }
        public static List<Turno> turnosDiagnosticablesPorProfesional(Int64 matricula, DateTime dia)
        {
            List<Turno> turnos = new List<Turno>();
            SqlCommand traerTurnos = new SqlCommand();
            traerTurnos.CommandText = "ELIMINAR_CAR.turnosParaDiagnosticar";
            traerTurnos.CommandType = CommandType.StoredProcedure;
            traerTurnos.Connection = DBConnector.ObtenerConexion();
            traerTurnos.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
            traerTurnos.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dia;
            SqlDataReader reader = traerTurnos.ExecuteReader();
            while (reader.Read())
            {
                Turno turno = new Turno();
                turno.id_turno = reader.GetInt64(0);
                turno.fecha_estipulada = reader.GetDateTime(1);
                turno.matricula = reader.GetInt64(2);
                turno.id_afiliado = reader.GetInt64(3);
                if (!reader.IsDBNull(4)) turno.id_bono = reader.GetInt64(4);
                else turno.id_bono = null;
                if (!reader.IsDBNull(5)) turno.momento_llegada = reader.GetDateTime(5);
                else turno.momento_llegada = null;
                turno.id_especialidad = reader.GetInt32(6);
                turno.activo = reader.GetBoolean(7);
                turno.desc_especialidad = reader.GetString(8);
                turno.afiliado_nombre = reader.GetString(9);
                turno.afiliado_apellido = reader.GetString(10);
                turnos.Add(turno);
            }
            reader.Close();
            return turnos;
        }
    }
}
