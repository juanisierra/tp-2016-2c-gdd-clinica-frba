using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public class Errores
    {
        public List<String> descripciones { set; get; }
        public Errores()
        { this.descripciones = new List<String>();
        }
        public void agregarError(String desc)
        {
            this.descripciones.Add(desc);
        }
        public String stringErrores()
        {
            String stringError = "Error \n";
            descripciones.ForEach(error => stringError += (error + "\n"));
            return stringError;
        }
        public Boolean huboError()
        {
            return descripciones.Count > 0;
        }
    }
}
