using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.Clases
{
    public class Afiliado
    {
        public Int64 idAfiliado { get; set; }
        public tipo_doc tipoDoc { get; set; }
        public Decimal nroDoc { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public long telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
        public estado_civil estadoCivil { get; set; }
        public sexo sexo { get; set; }
        public int idPlan { get; set; }
        public string descPlan { get; set; }
        public long idFamilia { get; set; }
        public int familiaresACargo { get; set; }
        public bool activo { get; set; }
        public DateTime fechaBaja { get; set; }
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
                afiliado.tipoDoc= (tipo_doc)reader.GetInt32(1);
                afiliado.nroDoc= reader.GetDecimal(2);
                afiliado.nombre= reader.GetString(3);
                afiliado.apellido= reader.GetString(4);
                afiliado.direccion= reader.GetString(5);
                afiliado.telefono= reader.GetInt64(6);
                afiliado.mail= reader.GetString(7);
                afiliado.fechaNac = reader.GetDateTime(8);
                afiliado.estadoCivil= (estado_civil) reader.GetInt32(9);
                if (reader.IsDBNull(10))
                    afiliado.sexo = sexo.NoEspecificado;
                else
                    afiliado.sexo = (sexo) reader.GetInt32(10);
                afiliado.idPlan= reader.GetInt32(11);
                afiliado.idFamilia= reader.GetInt64(12);
                afiliado.familiaresACargo= reader.GetInt32(13);
                afiliado.activo= reader.GetBoolean(14);
                if (reader.IsDBNull(15)) ;
                else   afiliado.fechaBaja = reader.GetDateTime(15);
                afiliado.numConsultaActual= reader.GetInt64(16);
                afiliado.usuario= reader.GetString(17);

                lista.Add(afiliado);
            }
            reader.Close();
            return lista;
        }
        public static List<Afiliado> listarAfiliadosConFiltro(String nombre,String apellido,int numeroDoc,int tipoDoc,int id_plan,Int64 id_afiliado)
        {
            String stringAfiliados = "SELECT id_afiliado,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil,sexo,p.id_plan,id_familia,familiares_a_cargo,activo,fecha_baja,num_consulta_actual,usuario,p.desc_plan FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p on (a.id_plan=p.id_plan) WHERE ";
            if (nombre != "") stringAfiliados = stringAfiliados + string.Format(" nombre like '%{0}%' AND ", nombre);
            if (apellido != "") stringAfiliados = stringAfiliados + string.Format(" apellido like '%{0}%' AND ", apellido);
            if (numeroDoc != -1) stringAfiliados = stringAfiliados + string.Format(" numero_doc like '{0}%' AND ", numeroDoc);
            if (tipoDoc != -1) stringAfiliados = stringAfiliados + string.Format(" tipo_doc ={0} AND ", tipoDoc);
            if (id_plan != -1) stringAfiliados = stringAfiliados + string.Format(" p.id_plan ={0} AND ", id_plan);
            if (id_afiliado != -1) stringAfiliados = stringAfiliados + string.Format(" id_afiliado like '{0}%' AND ", id_afiliado);
            stringAfiliados = stringAfiliados + "activo=1";
            SqlCommand traerAfiliados = new SqlCommand(stringAfiliados, DBConnector.ObtenerConexion());         
            SqlDataReader reader = traerAfiliados.ExecuteReader();
            List<Afiliado> lista = new List<Afiliado>();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                afiliado.idAfiliado = reader.GetInt64(0);
                afiliado.tipoDoc= (tipo_doc) reader.GetInt32(1);
                afiliado.nroDoc= reader.GetDecimal(2);
                afiliado.nombre= reader.GetString(3);
                afiliado.apellido= reader.GetString(4);
                afiliado.direccion= reader.GetString(5);
                afiliado.telefono= reader.GetInt64(6);
                afiliado.mail= reader.GetString(7);
                afiliado.fechaNac = reader.GetDateTime(8);
                afiliado.estadoCivil= (estado_civil) reader.GetInt32(9);
                if (reader.IsDBNull(10))
                    afiliado.sexo = sexo.NoEspecificado;
                else
                    afiliado.sexo = (sexo) reader.GetInt32(10);
                afiliado.idPlan= reader.GetInt32(11);
                afiliado.idFamilia= reader.GetInt64(12);
                afiliado.familiaresACargo= reader.GetInt32(13);
                afiliado.activo= reader.GetBoolean(14);
                if (reader.IsDBNull(15)) ;
                else   afiliado.fechaBaja = reader.GetDateTime(15);
                afiliado.numConsultaActual= reader.GetInt64(16);
                afiliado.usuario= reader.GetString(17);
                afiliado.descPlan = reader.GetString(18);
                lista.Add(afiliado);
            }
            reader.Close();
            return lista;
            
        }
        
        public static Int64 getIdAfiliadoPorUsuario(String id_usuario) //Retorna -1 si no tiene
        {
            SqlCommand traerIdUsuario = new SqlCommand();
            traerIdUsuario.CommandType = CommandType.StoredProcedure;
            traerIdUsuario.Connection = DBConnector.ObtenerConexion();
            traerIdUsuario.CommandText = "ELIMINAR_CAR.afiliado_por_usuario";
            traerIdUsuario.Parameters.Add(new SqlParameter("@usuario", id_usuario));
            SqlParameter afiliado = new SqlParameter();
            afiliado.ParameterName = "@afiliado";
            afiliado.DbType = DbType.Int64;
            afiliado.Direction = ParameterDirection.Output;
            traerIdUsuario.Parameters.Add(afiliado);
            traerIdUsuario.ExecuteNonQuery();
            if (traerIdUsuario.Parameters["@afiliado"].SqlValue != DBNull.Value)
            {
                return (Int64)traerIdUsuario.Parameters["@afiliado"].Value;
            }
            else
            {
                return -1;
            }
        }
        public static Afiliado getAfiliadoPorID(Int64 id_afiliado)
        {
            SqlCommand traerAfiliados = new SqlCommand("SELECT id_afiliado,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,estado_civil,sexo,id_plan,id_familia,familiares_a_cargo,activo,fecha_baja,num_consulta_actual,usuario FROM ELIMINAR_CAR.Afiliado WHERE id_afiliado=@id_afiliado", DBConnector.ObtenerConexion());
            traerAfiliados.Parameters.Add(new SqlParameter("@id_afiliado",SqlDbType.BigInt)).Value = id_afiliado;            
            SqlDataReader reader = traerAfiliados.ExecuteReader();
            List<Afiliado> lista = new List<Afiliado>();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                afiliado.idAfiliado = reader.GetInt64(0);
                afiliado.tipoDoc= (tipo_doc) reader.GetInt32(1);
                afiliado.nroDoc= reader.GetDecimal(2);
                afiliado.nombre= reader.GetString(3);
                afiliado.apellido= reader.GetString(4);
                afiliado.direccion= reader.GetString(5);
                afiliado.telefono= reader.GetInt64(6);
                afiliado.mail= reader.GetString(7);
                afiliado.fechaNac = reader.GetDateTime(8);
                afiliado.estadoCivil= (estado_civil) reader.GetInt32(9);
                if (reader.IsDBNull(10))
                    afiliado.sexo = sexo.NoEspecificado;
                else
                    afiliado.sexo = (sexo) reader.GetInt32(10);
                afiliado.idPlan= reader.GetInt32(11);
                afiliado.idFamilia= reader.GetInt64(12);
                afiliado.familiaresACargo= reader.GetInt32(13);
                afiliado.activo= reader.GetBoolean(14);
                if (reader.IsDBNull(15)) ;
                else   afiliado.fechaBaja = reader.GetDateTime(15);
                afiliado.numConsultaActual= reader.GetInt64(16);
                afiliado.usuario= reader.GetString(17);

                lista.Add(afiliado);
            }
            reader.Close();
            return lista.First();
            
        }

        public static List<Afiliado> listarAfiliadosCompraBonos(SqlCommand comando)
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();
            //SqlCommand afiliados = new SqlCommand(string.Format("SELECT id_afiliado, nombre, apellido, tipo_doc, numero_doc, fecha_nac, direccion, telefono, desc_plan, a.id_plan, num_consulta_actual, activo, fecha_baja FROM ELIMINAR_CAR.Afiliado a JOIN ELIMINAR_CAR.Planes p ON (a.id_plan=p.id_plan)"), conexion);
            List<Afiliado> lista = new List<Afiliado>();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                afiliado.idAfiliado = reader.GetInt64(0);
                afiliado.nombre = reader.GetString(1);
                afiliado.apellido = reader.GetString(2);
                afiliado.tipoDoc = (tipo_doc)reader.GetInt32(3);
                afiliado.nroDoc = reader.GetDecimal(4);
                afiliado.fechaNac = reader.GetDateTime(5);
                afiliado.direccion = reader.GetString(6);
                afiliado.telefono = reader.GetInt64(7);
                afiliado.descPlan = reader.GetString(8);
                afiliado.idPlan = reader.GetInt32(9);
                afiliado.numConsultaActual = reader.GetInt64(10);
                afiliado.activo= reader.GetBoolean(11);
                if (!reader.IsDBNull(12))
                    afiliado.fechaBaja = reader.GetDateTime(12);

                lista.Add(afiliado);
            }
            reader.Close();
            return lista;
        }
    }
}
