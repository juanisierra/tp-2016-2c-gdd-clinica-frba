﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Clases;
using ClinicaFrba.Abm_Especialidades_Medicas;

namespace ClinicaFrba.Abm_Profesional
{
    public partial class SeleccionarProfesionalPorEspecialidad : Form
    {
        List<Profesional> profesionales;
        List<Profesional> profesionalesFiltrado; //Profesionales de la especialidad que se quiere
        List<Especialidad> todasLasEspecialidades;
        public Boolean fueCerradoPorUsuario = false;   //Vale true si la cierran con la X
        public SeleccionarProfesionalPorEspecialidad()
        {
            InitializeComponent();
            profesionales  = Profesional.profesionales(DBConnector.ObtenerConexion());
            profesionalesFiltrado = new List<Profesional>();
             this.FormClosing += SeleccionarProfesional_Closing;
             fueCerradoPorUsuario = false;
             todasLasEspecialidades = new List<Especialidad>();
            Especialidad e = new Especialidad();
            e.id_especialidad=-1;
            e.descripcion = "Todas las especialidades";
            todasLasEspecialidades.Add(e);
            todasLasEspecialidades.AddRange(Especialidad.todasLasEspecialidades().OrderBy(elem => elem.descripcion));
             cb_especialidad.DataSource = todasLasEspecialidades;
             profesionalesFiltrado.Clear();
             profesionalesFiltrado.AddRange(profesionales); //Por defecto muestra todos
             dgv_profesional.DataSource = profesionalesFiltrado;
        }

        private void dgv_profesional_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (dgv_profesional.CurrentRow.DataBoundItem != null)
            {
                this.Close();
                this.fueCerradoPorUsuario = false;
            }
            }
           
 
        

        private void SeleccionarProfesional_Load(object sender, EventArgs e)
        {

        }
        private void SeleccionarProfesional_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) fueCerradoPorUsuario = true;

            }

        private void cb_especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {   
            dgv_profesional.DataSource = null;
            profesionalesFiltrado.Clear();
            if (((Especialidad)cb_especialidad.SelectedItem).id_especialidad == -1) //Listar todas
            {
                profesionalesFiltrado.AddRange(profesionales);
            }
            else
            {
                profesionalesFiltrado.AddRange(profesionales.FindAll(prof => prof.tieneEspecialidad(((Especialidad)cb_especialidad.SelectedItem).id_especialidad)));
            }
                dgv_profesional.DataSource = profesionalesFiltrado;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fueCerradoPorUsuario = true;
        }
    }
}
