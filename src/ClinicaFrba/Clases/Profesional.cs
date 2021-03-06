﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.Clases
{
    public class Profesional
    { public String nombre {set;get;}
    public String apellido { set; get; }
    public String direccion { set; get; }
    public String mail { set; get; }
    public String usuario { set; get; }
    public Int64 matricula { set; get; }
    public Int64 telefono { set; get; }
    public Decimal numero_doc { set; get; }
    public tipo_doc tipo_doc {set;get;}
    public DateTime fecha_nac {set;get;}
    public List<Especialidad> especialidades { set; get; }
    public static List<Profesional> profesionales(SqlConnection conexion)
    {
        SqlCommand traerProfesionales = new SqlCommand("SELECT matricula,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,usuario FROM ELIMINAR_CAR.Profesional", conexion);
        List<Profesional> profesionales = new List<Profesional>();
        SqlDataReader reader = traerProfesionales.ExecuteReader();
        while (reader.Read())
        {
            Profesional p = new Profesional();
            p.matricula = reader.GetInt64(0);
            p.tipo_doc = (tipo_doc) reader.GetInt32(1);
            p.numero_doc = reader.GetDecimal(2);
            p.nombre = reader.GetString(3);
            p.apellido = reader.GetString(4);
            p.direccion = reader.GetString(5);
            p.telefono = reader.GetInt64(6);
            p.mail = reader.GetString(7);
            p.fecha_nac = reader.GetDateTime(8);
            p.usuario = reader.GetString(9);
            profesionales.Add(p);
        }
        reader.Close();
        profesionales.ForEach(prof =>
        {
           prof.especialidades= Especialidad.especialidadesPorProfesional(prof.matricula);
        });
        return profesionales;
    }
    public static Profesional traerProfesionalPorMatricula(Int64 matricula)
    {
        SqlCommand traerProfesionales = new SqlCommand("SELECT matricula,tipo_doc,numero_doc,nombre,apellido,direccion,telefono,mail,fecha_nac,usuario FROM ELIMINAR_CAR.Profesional WHERE matricula=@matricula", DBConnector.ObtenerConexion());
        traerProfesionales.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
        List<Profesional> profesionales = new List<Profesional>();
        SqlDataReader reader = traerProfesionales.ExecuteReader();
        while (reader.Read())
        {
            Profesional p = new Profesional();
            p.matricula = reader.GetInt64(0);
            p.tipo_doc = (tipo_doc)reader.GetInt32(1);
            p.numero_doc = reader.GetDecimal(2);
            p.nombre = reader.GetString(3);
            p.apellido = reader.GetString(4);
            p.direccion = reader.GetString(5);
            p.telefono = reader.GetInt64(6);
            p.mail = reader.GetString(7);
            p.fecha_nac = reader.GetDateTime(8);
            p.usuario = reader.GetString(9);
            profesionales.Add(p);
        }
        reader.Close();
        profesionales.ForEach(prof =>
        {
            prof.especialidades = Especialidad.especialidadesPorProfesional(prof.matricula);
        });
        return profesionales.First();
    }
        public static Boolean tieneAgenda(Int64 matricula)
     {
         SqlCommand traerAgendasDiarias = new SqlCommand(string.Format("SELECT id_agenda FROM ELIMINAR_CAR.Agenda_Diaria WHERE matricula={0}",matricula.ToString()), DBConnector.ObtenerConexion());
         SqlDataReader reader = traerAgendasDiarias.ExecuteReader();
         List<Int64> agendas = new List<Int64>();
         while (reader.Read())agendas.Add(reader.GetInt64(0));
         reader.Close();
         SqlCommand traerFranja = new SqlCommand(string.Format("SELECT id_rango FROM ELIMINAR_CAR.Rango_Atencion WHERE matricula={0}", matricula.ToString()), DBConnector.ObtenerConexion());
         SqlDataReader reader2 = traerFranja.ExecuteReader();
         while (reader2.Read()) agendas.Add(reader2.GetInt64(0));
         reader2.Close();
         return (agendas.Count() > 0);
     }
        public static Int64 matriculaPorUsuario(String id_usuario) //Devuelve -1 si no tiene
        {        SqlCommand traerIdProfesional = new SqlCommand();
                traerIdProfesional.CommandType = CommandType.StoredProcedure;
                traerIdProfesional.Connection = DBConnector.ObtenerConexion();
                traerIdProfesional.CommandText = "ELIMINAR_CAR.matricula_por_usuario";
                traerIdProfesional.Parameters.Add(new SqlParameter("@usuario", id_usuario));
                SqlParameter matricula = new SqlParameter();
                matricula.ParameterName = "@matricula";
                matricula.DbType = DbType.Int64;
                matricula.Direction = ParameterDirection.Output;
                traerIdProfesional.Parameters.Add(matricula);
                traerIdProfesional.ExecuteNonQuery();
                if (traerIdProfesional.Parameters["@matricula"].Value != DBNull.Value)
                {
                    return (Int64)traerIdProfesional.Parameters["@matricula"].Value;
                }
                else
                {
                    return -1;
                }
        }
        public Boolean tieneEspecialidad(int id_especialidad)
        {
            return especialidades.Any(esp => esp.id_especialidad== id_especialidad);
        }
        public List<DayOfWeek> diasQueTrabajaNormalmente(int id_especialidad,Rango_Atencion rango) // Sin sacarle los dias cancelados
        {
            List<Agenda_Diaria>  agenda = Agenda_Diaria.getAgendaProfesional(this.matricula, id_especialidad,rango.id_rango);
            return  agenda.Select(a => a.dia).ToList<DayOfWeek>();
        }
    }
}
