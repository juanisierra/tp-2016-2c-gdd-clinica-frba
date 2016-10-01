using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Clases
{
    class Usuario
    {
       public String id_usuario;
       public Byte[] contrasenia;
       public int intentosFallidos;
       public Boolean habilitado;

       public static Usuario buscarUsuario(String id_usuario,SqlConnection conexion)
       {
           Usuario u = new Usuario();

           SqlCommand comando = new SqlCommand(string.Format("SELECT id_usuario,contrasenia,intentos_fallidos,habilitado FROM ELIMINAR_CAR.Usuario WHERE id_usuario = '{0}' ", id_usuario), conexion);
           SqlDataReader reader = comando.ExecuteReader();
           if (reader.Read())
           {
               u.id_usuario = reader.GetString(0);
               u.contrasenia = (byte[])reader.GetValue(1);
               u.intentosFallidos = reader.GetInt16(2);
               u.habilitado = reader.GetBoolean(3);
               reader.Close();
               return u;
           }
           reader.Close();
           return null;
       }
    }
    
}
