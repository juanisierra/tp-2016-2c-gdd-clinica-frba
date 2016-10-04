using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Clases
{
    class Especialidad
    {
        public int id_especialidad { set; get; }
        public String descripcion { set; get; }
        public int id_tipo_especialidad { set; get; }

        public List<Especialidad> especialidadesPorProfesional(String matricula_profesional)
        {
            SqlConnection conexion = DBConnector.ObtenerConexion();
            SqlCommand traerEspecialidades = new SqlCommand("SELECT id_especialidad,desc_especialidad,id_tipo_especialidad FROM ELIMINAR_CAR.Especialidad e JOIN ELIMINAR_CAR.Especialidad_por_profesional p on (e.id_especialidad=p.id_especialidad) WHERE p.matricula = {0}", conexion);
            traerEspecialidades.Parameters.Add(matricula_profesional);
            SqlDataReader reader = traerEspecialidades.ExecuteReader();
            List<Especialidad> especialidades = new List<Especialidad>();
            while (reader.Read())
            {
                Especialidad e = new Especialidad();
                e.id_especialidad = reader.GetInt32(0);
                e.descripcion = reader.GetString(1);
                e.id_tipo_especialidad = reader.GetInt32(2);
                especialidades.Add(e);
            }
            reader.Close();
            return especialidades;
        }
    }
}
