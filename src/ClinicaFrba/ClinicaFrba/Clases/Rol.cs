using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Clases
{
    class Rol
    {
       public int id_rol { get; set; }
       public String Nombre { get; set; }
       public Boolean habilitado { get; set; }
        public static List<Rol> rolesDeUsuario(String id_usuario)
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand traerRoles = new SqlCommand(string.Format("SELECT r.id_rol,r.habilitado,r.nombre_rol FROM ELIMINAR_CAR.Roles_por_usuarios u JOIN ELIMINAR_CAR.Rol r on (u.id_rol=r.id_rol) WHERE id_usuario='{0}' AND habilitado=1", id_usuario), conexion);
            SqlDataReader reader = traerRoles.ExecuteReader();
            List<Rol> lista = new List<Rol>();
            while (reader.Read())
            {
                Rol r = new Rol();
                r.id_rol = reader.GetInt16(0);
                r.habilitado = reader.GetBoolean(1);
                r.Nombre = reader.GetString(2);
                lista.Add(r);
            }
            reader.Close();
            return lista;
        }
    }
}
