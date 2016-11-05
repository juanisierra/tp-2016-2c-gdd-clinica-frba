using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClinicaFrba.AbmRol;
 using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Listados;
using ClinicaFrba.Abm_Afiliado;
namespace ClinicaFrba
{
    public class Funcionalidad
    {
        public int id_funcionalidad { get; set; }
        public string descripcion { get; set; }
        public static Dictionary<int, Type> Formularios { get; set; }  //Une cada id de funcionalidad con un formulario    
        
        public static List<Funcionalidad> funcionalidadesPorRol(int id_rol)
        {   
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand traerFuncionalidades = new SqlCommand(string.Format("SELECT f.id_funcionalidad,f.descripcion FROM ELIMINAR_CAR.Funcionalidades_por_rol r JOIN ELIMINAR_CAR.Funcionalidad f on (r.id_funcionalidad=f.id_funcionalidad) WHERE r.id_rol={0}", id_rol), conexion);
            SqlDataReader reader = traerFuncionalidades.ExecuteReader();
            List<Funcionalidad> lista = new List<Funcionalidad>();
            while (reader.Read())
            {
                Funcionalidad f = new Funcionalidad();
                f.id_funcionalidad = reader.GetInt16(0);
                f.descripcion = reader.GetString(1);
                lista.Add(f);
            }
            reader.Close();
            return lista;
        }

        public static List<Funcionalidad> todasLasFuncionalidades()
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand funcionalidades = new SqlCommand(string.Format("SELECT id_funcionalidad, descripcion FROM ELIMINAR_CAR.Funcionalidad"), conexion);
            SqlDataReader lector = funcionalidades.ExecuteReader();

            List<Funcionalidad> lista = new List<Funcionalidad>();

            while (lector.Read())
            {
                Funcionalidad func = new Funcionalidad();
                func.id_funcionalidad = lector.GetInt16(0);
                func.descripcion = lector.GetString(1);
                lista.Add(func);
            }
            lector.Close();
            return lista;
        }

        public static System.Windows.Forms.Form formularioPorID(int id_funcionalidad,String id_usuario, int id_rol)
        {
            switch (id_funcionalidad)
            {
                case 1:
                    return new ABMRol(id_usuario);
                break;
                case 3:
                return new ABMAfiliado(id_usuario,id_rol);
                break;
                case 7:
                 return new AltaAgenda(id_usuario,id_rol);
                 break;
                case 8:
                    return new CompraBonos(id_usuario, id_rol);
                    break;
                case 9 :
                    return new Pedir_Turno.PedirTurno(id_usuario, id_rol);
                    break;
                case 10:
                    return new Registro_Llegada.RegistroLlegada(id_usuario, id_rol);
                    break;
                case 11:
                    return new Registro_Resultado.RegistroResultado(id_usuario, id_rol);
                    break;
                case 12:
                    if(id_rol==1) return new Cancelar_Atencion.CancelacionAfiliado(id_usuario,id_rol);
                    else return new Cancelar_Atencion.CancelacionProfesional(id_usuario, id_rol);
                    break;
                case 13:
                    return new Elegir_listado();
                    break;
                default:
                    return new Utils.FormularioNoImplementado();
                    break;
            }
            return null;
        }

}

}
