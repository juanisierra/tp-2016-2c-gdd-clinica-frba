using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.Clases
{
    public class Agenda_Diaria
    {
        public DayOfWeek dia { set; get; }
        public long matricula { set; get; }
        public TimeSpan hora_desde { set; get; }
        public TimeSpan hora_hasta { set; get; }
        public int id_especialidad { set; get; }
        public long id_rango { set; get; }
        public String diaPropio { set; get; }
        public String nombreEspecialidad { set; get; }

        public Boolean esValida()
        {
            return hora_desde < hora_hasta;
        }
        public Agenda_Diaria(int dia, long matricula, int h_desde, int m_desde, int h_hasta, int m_hasta, int id_especialidad)
        {
            this.dia = (DayOfWeek)dia;
            this.matricula = matricula;
            this.hora_desde = new TimeSpan(h_desde,m_desde,0);
            this.hora_hasta = new TimeSpan(h_hasta, m_hasta, 0);
            this.id_especialidad = id_especialidad;
            this.diaPropio = Dia.generarDia(dia).nombre;
            this.nombreEspecialidad = Especialidad.especialidadesPorProfesional(matricula).Find(esp => esp.id_especialidad == id_especialidad).descripcion;
        }
        public Agenda_Diaria() {}
        public double horasDiarias()
        {
            return (hora_hasta - hora_desde).TotalHours;
        }
        public Dia generarDia()
        {
            return Dia.generarDia((int) dia);
        }
        public static  List<Agenda_Diaria> getAgendaProfesional(Int64 matricula,int id_especialidad,Int64 id_rango)
        {   
            SqlCommand traerAgendas = new SqlCommand();
            traerAgendas.Connection = DBConnector.ObtenerConexion();
            traerAgendas.CommandText = "SELECT matricula,dia,hora_desde,hora_hasta,id_especialidad,id_rango FROM ELIMINAR_CAR.Agenda_Diaria WHERE matricula=@matricula AND id_especialidad=@id_especialidad AND id_rango=@id_rango";
            traerAgendas.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
            traerAgendas.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = id_especialidad;
            traerAgendas.Parameters.Add("@id_rango", SqlDbType.BigInt).Value = id_rango;
            SqlDataReader reader = traerAgendas.ExecuteReader();
            List<Agenda_Diaria> lista = new List<Agenda_Diaria>();
            while (reader.Read())
            {
                Agenda_Diaria a = new Agenda_Diaria();
                a.matricula = reader.GetInt64(0);
                a.dia = (DayOfWeek) reader.GetInt32(1);
                a.hora_desde = reader.GetTimeSpan(2);
                a.hora_hasta = reader.GetTimeSpan(3);
                a.id_especialidad = reader.GetInt32(4);
                a.id_rango = reader.GetInt64(5);
                lista.Add(a);
            }
            reader.Close();
            return lista;
        }
        public List<TimeSpan> generarHorarios()
        {
            List<TimeSpan> lista = new List<TimeSpan>();
            TimeSpan tiempo = hora_desde;
            while (tiempo + new TimeSpan(0, 30, 0) <= hora_hasta)
            {
                lista.Add(tiempo);
                tiempo += new TimeSpan(0, 30, 0);
            }
            return lista;
        }

        public static Boolean seSuperponen(List<Agenda_Diaria> agendas, Agenda_Diaria nueva)
        {
            List<Agenda_Diaria> agendasDelDia = agendas.FindAll(a => a.dia == nueva.dia);
            List<TimeSpan> horarios = new List<TimeSpan>();
            agendasDelDia.ForEach(a => horarios.AddRange(a.generarHorarios()));
            return nueva.generarHorarios().Any(horario => horarios.Contains(horario));
        }

    }
}
