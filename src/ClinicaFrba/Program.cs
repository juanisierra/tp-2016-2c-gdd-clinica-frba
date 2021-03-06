﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Clases;
using ClinicaFrba.Abm_Profesional;

namespace ClinicaFrba
{
    static class Program
    { 
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnector.ObtenerConexion();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            DBConnector.ObtenerConexion().Close();
            }
        }
    }

