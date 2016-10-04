using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Agenda_Diaria
    {
        public DayOfWeek dia { set; get; }
        public long matricula { set; get; }
        public DateTime hora_desde { set; get; }
        public DateTime hora_hasta { set; get; }
        public int id_especialidad { set; get; }
        public Boolean esValida()
        {
            return hora_desde < hora_hasta;
        }
        public Agenda_Diaria(int dia, long matricula, int h_desde, int m_desde, int h_hasta, int m_hasta, int id_especialidad)
        {
            this.dia =(DayOfWeek) dia;
            this.matricula = matricula;
            this.hora_desde = new DateTime(1, 1, 1, h_desde, m_desde,0);
            this.hora_hasta = new DateTime(1, 1, 1, h_hasta, m_hasta,0);
            this.id_especialidad = id_especialidad;
        }
        public double horasDiarias()
        {
            return (hora_hasta - hora_desde).TotalHours;
        }




    }
}
