using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Utils
{
    class Fechas
    {
        public static DateTime getCurrentDateTime()
        {
            return DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Fecha"]);
        }
    }
}
