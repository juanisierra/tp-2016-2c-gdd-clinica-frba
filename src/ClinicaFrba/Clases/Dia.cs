using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
   public  class Dia
    {
        public int dia { set; get; }
        public String nombre { set; get; }
        public Dia(int dia, String nombre)
        {
            this.dia = dia;
            this.nombre = nombre;
        }
        public static Dia generarDia(int num)
        {
            return crearDias().Find(elem => elem.dia == num);
        }
        public static List<Dia> crearDias()
        {
            List<Dia> dias = new List<Dia>();
            dias.Add(new Dia(1, "Lunes"));
            dias.Add(new Dia(2, "Martes")); 
            dias.Add(new Dia(3, "Miercoles"));
            dias.Add(new Dia(4, "Jueves"));
            dias.Add(new Dia(5, "Viernes"));
            dias.Add(new Dia(6, "Sabado"));
            return dias;
        }
    }
}
