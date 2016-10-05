using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
