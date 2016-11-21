using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Abm_Profesional;
using ClinicaFrba.Clases;
using System.Data.SqlClient;
using ClinicaFrba.Utils;
namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class AltaAgenda : Form
    {
        public string id_usuario { set; get; }
        public int id_rol { set; get; }
        public Profesional profesional { set; get; }
        public List<Agenda_Diaria> agendas { set; get; }
        public AltaAgenda(String id_usuario,int id_rol)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
            agendas = new List<Agenda_Diaria>();
            cb_dia.DataSource = Dia.crearDias();
            dgv_agenda.DataSource = new List<Agenda_Diaria>();
        }
        
        public void AltaAgenda_Load(object sender, EventArgs e)
        {
            franja_inicio.Value = Fechas.getCurrentDateTime().Date;
            franja_fin.Value = Fechas.getCurrentDateTime().Date;
            if (id_rol == 3) ///Es profesional
            {      Int64 matricula = Profesional.matriculaPorUsuario(id_usuario);
                 if(matricula!=-1)   {
                   profesional = Profesional.traerProfesionalPorMatricula(matricula);
                }
                else //NO hay matricula en un profesional
                {
                    MessageBox.Show("Error, el usuario con el que se ingresó tiene rol de Profesional pero no tiene matricula","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else if (id_rol == 2 || id_rol == 4)
            {
                SeleccionarProfesional formulario = new SeleccionarProfesional();
                formulario.ShowDialog();
                Boolean cerradoPorusuario = false;
                profesional = (Profesional)((DataGridView)formulario.Controls["dgv_profesional"]).CurrentRow.DataBoundItem;
                if (formulario.fueCerradoPorUsuario == true) cerradoPorusuario = true;
  
                if (formulario.fueCerradoPorUsuario == true) this.Close();
                formulario.Close();
            }
            else
            {
                MessageBox.Show("El usuario actual no deberia tener acceso a esta funcionalidad.", "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            List<Especialidad> especialidades = Especialidad.especialidadesPorProfesional(profesional.matricula);
            label_agenda.Text = "Agenda de: " + profesional.nombre+" " + profesional.apellido;
            l_especialidad.Items.AddRange(especialidades.ToArray());
            
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            
            Rango_Atencion rango = new Rango_Atencion();
            rango.matricula = profesional.matricula;
            rango.fecha_desde = franja_inicio.Value.Date;
            rango.fecha_hasta = franja_fin.Value.Date;
            Errores errores = new Errores();
            if (rango.fecha_desde.Year < 2016 || rango.fecha_hasta.Year < 2016)
            {
                errores.agregarError("No se permiten registrar agendas anteriores a 2016");
            }
            if(!rango.esValido())
            {
                errores.agregarError("La fecha de inicio de la franja debe ser anterior a la de fin.");
            }
            if(rango.fecha_desde< ClinicaFrba.Utils.Fechas.getCurrentDateTime().Date || rango.fecha_hasta<ClinicaFrba.Utils.Fechas.getCurrentDateTime().Date)
            {
                errores.agregarError("Las fechas de inicio y fin de la franja deben ser posteriores o iguales al dia de hoy.");
            }
            if(agendas.Any(elem => !elem.esValida()))
            {
                errores.agregarError("La hora de fin del turno no puede ser anterior a la de inicio.");
            }
            if (agendas.Sum(elem => elem.horasDiarias()) > 48)
            {
                errores.agregarError("Esta prohibido trabajar mas de 48hs semanales. Por favor disminuya sus horas diarias.");
            }
            if (agendas.Any(elem =>elem.id_especialidad==null))
              {
                errores.agregarError("La especialidad no puede ser nula.");
             }
            if(agendas.Count==0)
            {
                errores.agregarError("Debe seleccionar por lo menos un dia de la semana.");
            }
            if (Rango_Atencion.SeSolapan(profesional.matricula, rango))
            {
                errores.agregarError("El rango seleccionado no puede solaparse con un rango ya registrado.");
            }
            if(errores.huboError())
            {
                
                MessageBox.Show(errores.stringErrores(), "Clinica-FRBA: ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            } else
             {
                 insert(agendas,rango);
                 MessageBox.Show("Se ha insertado la agenda correctamente.", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.Close();
             }
             
          }

        

        //Checkeos lunes
        private void l_desde_m_ValueChanged(object sender, EventArgs e)
        {
            if (((Dia)cb_dia.SelectedItem).dia == 6)
            {
                if (l_desde_h.Value == 15) l_desde_m.Value = 0;
            }
            else
            {
                if (l_desde_h.Value == 20) l_desde_m.Value = 0;
            }
        }

        private void l_desde_h_ValueChanged(object sender, EventArgs e)
        {
            if (((Dia)cb_dia.SelectedItem).dia == 6)
            {
                if (l_desde_h.Value == 15) l_desde_m.Value = 0;
            }
            else
            {
                if (l_desde_h.Value == 20) l_desde_m.Value = 0;
            }
        }

        private void l_hasta_h_ValueChanged(object sender, EventArgs e)
        {
            if (((Dia)cb_dia.SelectedItem).dia == 6)
            {
                if (l_hasta_h.Value == 15) l_hasta_m.Value = 0;
            }
            else
            {
                if (l_hasta_h.Value == 20) l_hasta_m.Value = 0;
            }
        }

        private void l_hasta_m_ValueChanged(object sender, EventArgs e)
        {
            if (((Dia)cb_dia.SelectedItem).dia == 6)
            {
                if (l_hasta_h.Value == 15) l_hasta_m.Value = 0;
            }
            else
            {
                if (l_hasta_h.Value == 20) l_hasta_m.Value = 0;
            }
        }
            


        private void insert(List<Agenda_Diaria> agenda,Rango_Atencion rango)
        {
            /*SqlCommand insertarRango = new SqlCommand("INSERT INTO ELIMINAR_CAR.Rango_Atencion (matricula,fecha_desde,fecha_hasta) VALUES (@matricula,@fecha_desde,@fecha_hasta)", DBConnector.ObtenerConexion());
            insertarRango.Parameters.Add("@matricula", SqlDbType.BigInt).Value = rango.matricula;
            insertarRango.Parameters.Add("@fecha_desde", SqlDbType.DateTime).Value = rango.fecha_desde;
            insertarRango.Parameters.Add("@fecha_hasta", SqlDbType.DateTime).Value = rango.fecha_hasta;*/
            SqlCommand insertarRango = new SqlCommand("ELIMINAR_CAR.Registrar_Rango", DBConnector.ObtenerConexion());
            insertarRango.CommandType = CommandType.StoredProcedure;
            insertarRango.Parameters.Add(new SqlParameter("@matricula", rango.matricula));
            insertarRango.Parameters.Add(new SqlParameter("@fecha_desde", rango.fecha_desde));
            insertarRango.Parameters.Add(new SqlParameter("@fecha_hasta", rango.fecha_hasta));
            Int64 id_rango = -1;
            insertarRango.Parameters.Add(new SqlParameter("@id_rango", id_rango));
            insertarRango.Parameters["@id_rango"].Direction = ParameterDirection.Output;
            
            insertarRango.ExecuteNonQuery();
            id_rango = (Int64)insertarRango.Parameters["@id_rango"].Value;
             agenda.ForEach(elem => {
               SqlCommand insertar = new SqlCommand("INSERT INTO ELIMINAR_CAR.Agenda_Diaria (dia,matricula,hora_desde,hora_hasta,id_especialidad,id_rango) VALUES (@dia,@matricula,@hora_desde,@hora_hasta,@id_especialidad,@id_rango)",DBConnector.ObtenerConexion());
               insertar.Parameters.Add("@dia", SqlDbType.Int).Value = (int) elem.dia;
               insertar.Parameters.Add("@matricula", SqlDbType.BigInt).Value = elem.matricula;
               //string format = "yyyy-MM-dd HH:MM:ss";
               insertar.Parameters.Add("@hora_desde", SqlDbType.Time).Value = elem.hora_desde;
               insertar.Parameters.Add("@hora_hasta", SqlDbType.Time).Value = elem.hora_hasta;
               insertar.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = elem.id_especialidad;
               insertar.Parameters.Add("@id_rango", SqlDbType.Int).Value = id_rango;
               insertar.ExecuteNonQuery();
             });
             
         }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {   Agenda_Diaria nueva = new Agenda_Diaria();
            Errores error = new Errores();
            if(cb_dia.SelectedValue==null) error.agregarError("Debe seleccionar un dia.");
            if (l_especialidad.SelectedItem == null) error.agregarError("La especialidad no puede ser nula.");
            if (!error.huboError())
            {
                nueva = new Agenda_Diaria(((Dia)cb_dia.SelectedItem).dia, profesional.matricula, (int)l_desde_h.Value, (int)l_desde_m.Value, (int)l_hasta_h.Value, (int)l_hasta_m.Value, ((Especialidad)l_especialidad.SelectedItem).id_especialidad);
                if (!nueva.esValida()) error.agregarError("La hora de fin debe ser posterior a la de inicio.");
                if (agendas.Sum(elem => elem.horasDiarias())+nueva.horasDiarias() > 48)
                {
                    error.agregarError("Esta prohibido trabajar mas de 48hs semanales. Si quiere agregar mas horas debe eliminar algunas.");
                }
                if (Agenda_Diaria.seSuperponen(agendas, nueva))
                {
                    error.agregarError("No puede elegir rangos que se superpongan en el mismo dia.");
                }
                if (agendas.Any(elem => elem.dia == nueva.dia && elem.id_especialidad == nueva.id_especialidad))
                {
                    error.agregarError("No se puede trabajar dos veces con la misma especialidad en el mismo dia.");
                }
            }
            if (!error.huboError()) 
            {
                 
                agendas.Add(nueva);
                actualizarAgenda();
            }
            else
            {
                MessageBox.Show(error.stringErrores(),"Clinica-FRBA ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }

        private void cb_dia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Dia)cb_dia.SelectedItem).dia == 6)
            {
                l_desde_h.Maximum = 15;
                l_hasta_h.Maximum = 15;
            }
            else
            {
                l_desde_h.Maximum = 20;
                l_hasta_h.Maximum = 20;
            }
        }
        private void dgv_agenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                agendas.Remove((Agenda_Diaria)senderGrid.CurrentRow.DataBoundItem);
                actualizarAgenda();
            }
        }
        public void actualizarAgenda()
        {
            List<Agenda_Diaria> a = new List<Agenda_Diaria>();
            a.AddRange(agendas);
            dgv_agenda.DataSource = a;
        }


    }
}
