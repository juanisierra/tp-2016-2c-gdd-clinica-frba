using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Clases
{
    class Afiliado
    {
        public Int64 idAfiliado { get; set; }
        public int tipoDoc { get; set; }
        public Decimal nroDoc { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public long telefono { get; set; }
        public string mail { get; set; }
        public string fechaNac { get; set; }
        public string estadoCivil { get; set; }
        public char sexo { get; set; }
        public int idPlan { get; set; }
        public long idFamilia { get; set; }
        public int familiaresACargo { get; set; }
        public bool activo { get; set; }
        public string fechaBaja { get; set; }
        public long numConsultaActual { get; set; }
        public string usuario { get; set; }

        public static List<Afiliado> listarAfiliados(SqlCommand comando)
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            
            SqlDataReader reader = comando.ExecuteReader();

            List<Afiliado> lista = new List<Afiliado>();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                afiliado.idAfiliado = reader.GetInt64(0);
                afiliado.tipoDoc= reader.GetInt32(1);
                afiliado.nroDoc= reader.GetDecimal(2);
                afiliado.nombre= reader.GetString(3);
                afiliado.apellido= reader.GetString(4);
                afiliado.direccion= reader.GetString(5);
                afiliado.telefono= reader.GetInt64(6);
                afiliado.mail= reader.GetString(7);
                afiliado.fechaNac = reader.GetDateTime(8).ToString("yyyy-MM-dd HH:mm:ss");
                afiliado.estadoCivil= reader.GetString(9);
                if (reader.IsDBNull(10))
                    afiliado.sexo = '-';
                else
                    afiliado.sexo = reader.GetString(10)[0];
                afiliado.idPlan= reader.GetInt32(11);
                afiliado.idFamilia= reader.GetInt64(12);
                afiliado.familiaresACargo= reader.GetInt32(13);
                afiliado.activo= reader.GetBoolean(14);
                if (reader.IsDBNull(15))
                    afiliado.fechaBaja = "";
                else
                    afiliado.fechaBaja = reader.GetString(15);
                afiliado.numConsultaActual= reader.GetInt64(16);
                afiliado.usuario= reader.GetString(17);

                lista.Add(afiliado);
            }
            reader.Close();
            return lista;
        }
    }
}
