using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Bono
    {   public Int64 id_bono {set;get;}
        public Int64 id_afiliado_comprador {set;get;}
        public Int64 id_afiliado_consumidor {set;get;}
        public Int64 num_consulta {set;get;}
        public int id_plan {set;get;}
        public Boolean utilizado {set;get;}
        public int precio {set;get;}
        public DateTime fecha_compra {set;get;}
        public DateTime fecha_uso { set; get; }
        public static List<Int64> bonosDisponibles(Int64 id_afiliado)
        {
            SqlCommand traerBonos = new SqlCommand("ELIMINAR_CAR.bonosDisponibles", DBConnector.ObtenerConexion());
            traerBonos.CommandType = System.Data.CommandType.StoredProcedure;
            traerBonos.Parameters.Add("@id_afiliado", SqlDbType.BigInt).Value = id_afiliado;
            SqlDataReader reader = traerBonos.ExecuteReader();
            List<Int64> bonos = new List<Int64>();
            while (reader.Read())
            {
                bonos.Add(reader.GetInt64(0));
            }
            reader.Close();
            return bonos;
        }
    }
}
