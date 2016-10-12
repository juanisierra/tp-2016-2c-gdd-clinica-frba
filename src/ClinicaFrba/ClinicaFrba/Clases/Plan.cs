using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
   public  class Plan
    {   public int id_plan {set;get;}
    public String desc_plan { set; get; }
        public static List<Plan> traerPlanes()
        {
            SqlCommand traer = new SqlCommand("SELECT id_plan,desc_plan FROM ELIMINAR_CAR.Planes", DBConnector.ObtenerConexion());
            SqlDataReader reader = traer.ExecuteReader();
            List<Plan> planes = new List<Plan>();
            while (reader.Read())
            {
                Plan a = new Plan();
                a.id_plan = reader.GetInt32(0);
                a.desc_plan = reader.GetString(1);
                planes.Add(a);
            }
            reader.Close();
            return planes;
        }
    }
}
