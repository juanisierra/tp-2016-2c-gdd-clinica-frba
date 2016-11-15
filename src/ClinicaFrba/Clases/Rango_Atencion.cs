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
            return fecha_desde.Date <= fecha_hasta.Date;
        }
        public static List<Rango_Atencion> rangosPorProfesional(Int64 matricula)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = DBConnector.ObtenerConexion();
            comando.CommandText = "SELECT id_rango,matricula,fecha_desde,fecha_hasta FROM ELIMINAR_CAR.Rango_Atencion WHERE matricula=@matricula";
            comando.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
            SqlDataReader reader = comando.ExecuteReader();
            List<Rango_Atencion> lista = new List<Rango_Atencion>();
            while (reader.Read())
            {
                Rango_Atencion rango = new Rango_Atencion();
                rango.id_rango = reader.GetInt64(0);
                rango.matricula = reader.GetInt64(1);
                rango.fecha_desde = reader.GetDateTime(2);
                rango.fecha_hasta = reader.GetDateTime(3);
                lista.Add(rango);
            }
            reader.Close();
            return lista;
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

        internal static bool SeSolapan(Int64 matricula, Rango_Atencion rango)
        {
            List<DateTime> diasRangosActuales = new List<DateTime>();
            Rango_Atencion.rangosPorProfesional(matricula).ForEach(r => diasRangosActuales.AddRange(Rango_Atencion.generarDiasRango(r)));
            List<DateTime> diasRangoNuevo = Rango_Atencion.generarDiasRango(rango);
            return diasRangoNuevo.Any(dia => diasRangosActuales.Select(d => d.Date).Contains(dia.Date));
        }

        internal static List<DateTime> generarDiasQueTrabajaRango(Profesional prof,int id_especialidad,Rango_Atencion r)
        {
            List<DateTime> dias = Rango_Atencion.generarDiasRango(r);
            List<DayOfWeek> diasQueTrabaja = prof.diasQueTrabajaNormalmente(id_especialidad,r);
            dias.RemoveAll(dia => !diasQueTrabaja.Contains(dia.DayOfWeek));
            return dias;
        }
        public static Int64 rangoPorDia(Int64 matricula, int id_especialidad, DateTime dia)
        {
            List<Rango_Atencion> rangos = Rango_Atencion.rangosPorProfesional(matricula);
            return rangos.Find(rango => Rango_Atencion.generarDiasRango(rango).Contains(dia)).id_rango;
        }
    }
}
