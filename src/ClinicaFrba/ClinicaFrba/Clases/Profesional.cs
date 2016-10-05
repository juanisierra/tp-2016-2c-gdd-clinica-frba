﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaFrba.Clases
{
    class Profesional
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
        return profesionales;
    }
    }
}
