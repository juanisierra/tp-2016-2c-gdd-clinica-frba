using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{   public enum tipo_doc {PASAPORTE,DNI};
    public enum estado_civil { Casado, Soltero, Viudo, Concubinato, Divorciado };
    public enum sexo {NoEspecificado, Masculino, Femenino }
    //Cuidado, es +1 del de datetime
    public enum meses { Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre, Noviembre, Diciembre };
}
