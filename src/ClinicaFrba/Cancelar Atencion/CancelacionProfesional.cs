using ClinicaFrba.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class CancelacionProfesional : Form
    {
        private string id_usuario { set; get; }
        private int id_rol { set; get; }
        private Int64 matricula { set; get; }
        public List<Rango_Atencion> rangos { set; get; }
        public List<DateTime> dias { set; get; }
        public CancelacionProfesional(string id_usuario, int id_rol)
        {
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.id_rol = id_rol;
            dias = new List<DateTime>();

        }

        private void CancelacionProfesional_Load(object sender, EventArgs e)
        {
            matricula = Profesional.matriculaPorUsuario(id_usuario);
            if (matricula == -1)
            {
                MessageBox.Show("Error, el profesional con el que ingresó no cuenta con numero de matricula.", "Clinica-FRBA Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (Rango_Atencion.rangosPorProfesional(matricula).Count == 0)
            {
                MessageBox.Show("Error, el profesional no tiene establecida una agenda.", "Clinica-FRBA Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                List<Rango_Atencion> rangos = Rango_Atencion.rangosPorProfesional(matricula);
                rangos.ForEach(rango => dias.AddRange(Rango_Atencion.generarDiasRango(rango)));
                dias.RemoveAll(dia => dia.Date <= DateTime.Today);
                actualizarDias();
                if (dias.Count==0)
                {
                    cb_anio_desde.Enabled = false;
                    cb_mes_desde.Enabled = false;
                    cb_dia_desde.Enabled = false;
                    cb_anio_hasta.Enabled = false;
                    cb_mes_hasta.Enabled = false;
                    cb_dia_hasta.Enabled = false;
                    btn_cancelar.Enabled = false;
                    tb_motivo.Enabled = false;
                    MessageBox.Show("No hay ninguna franja para cancelar.", "Clinica-FRBA ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            actualizarDesde();
        }
        private void actualizarDias()
        {
            List<DateTime> diasCancelados = new List<DateTime>();
            Cancelacion_Profesional.cancelacionesPorProfesional(matricula).ForEach(canc => diasCancelados.AddRange(canc.diasCancelados()));
            dias.RemoveAll(dia => diasCancelados.Contains(dia));
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Errores errores = new Errores();
            if ((DateTime)cb_dia_desde.SelectedItem > (DateTime)cb_dia_hasta.SelectedItem) errores.agregarError("La fecha final de la franja debe ser anterior a la inicial.");
            if (tb_motivo.TextLength == 0) errores.agregarError("Debe escribir un motivo de cancelacion");
            if (errores.huboError())MessageBox.Show(errores.stringErrores(),"Clinica-FRBA ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                SqlCommand cancelar = new SqlCommand("ELIMINAR_CAR.cancelarTurnoProfesional", DBConnector.ObtenerConexion());
                cancelar.CommandType = CommandType.StoredProcedure;
                cancelar.Parameters.Add("@matricula", SqlDbType.BigInt).Value = matricula;
                cancelar.Parameters.Add("@fecha_desde", SqlDbType.Date).Value = (DateTime)cb_dia_desde.SelectedItem;
                cancelar.Parameters.Add("@fecha_hasta", SqlDbType.Date).Value = (DateTime)cb_dia_hasta.SelectedItem;
                cancelar.Parameters.Add("@motivo", SqlDbType.VarChar).Value = tb_motivo.Text;
                cancelar.ExecuteNonQuery();
                MessageBox.Show("Franja Cancelada Correctamente", "Clinica-FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            }
        private void actualizarDesde()
        {
            List<int> anios = new List<int>();
            anios.AddRange(dias.Select(dia => dia.Year).Distinct());
            cb_anio_desde.DataSource = anios;
        }

        private void cb_anio_desde_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<meses> mesesConEnum = new List<meses>();
            dias.FindAll(elem => elem.Year == (int)cb_anio_desde.SelectedItem).GroupBy(elem => elem.Month).Select(it => it.First()).ToList<DateTime>().ForEach(elem => mesesConEnum.Add((meses)elem.Month - 1));
            cb_mes_desde.DataSource = mesesConEnum;
        }

        private void cb_mes_desde_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DateTime> diasDesde = new List<DateTime>();
            dias.FindAll(elem => elem.Year == (int)cb_anio_desde.SelectedItem && elem.Month == (int)cb_mes_desde.SelectedItem + 1).ForEach(fecha => diasDesde.Add(fecha));
            cb_dia_desde.DataSource = diasDesde;
        }

        private void cb_dia_desde_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarHasta();
        }

        private void actualizarHasta()
        {
            List<int> anios = new List<int>();
            anios.AddRange(dias.FindAll(d => d.Year >= (int)cb_anio_desde.SelectedItem).Select(dia => dia.Year).Distinct());
            cb_anio_hasta.DataSource = anios;

        }

        private void cb_anio_hasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<meses> mesesConEnum = new List<meses>();
            dias.FindAll(elem => elem.Year == (int)cb_anio_hasta.SelectedItem && elem.Month>=(int) cb_mes_desde.SelectedItem+1).GroupBy(elem => elem.Month).Select(it => it.First()).ToList<DateTime>().ForEach(elem => mesesConEnum.Add((meses)elem.Month - 1));
            cb_mes_hasta.DataSource = mesesConEnum;
        }

        private void cb_mes_hasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DateTime> diasHasta = new List<DateTime>();
            dias.FindAll(elem => elem.Year == (int)cb_anio_hasta.SelectedItem && elem.Month == (int)cb_mes_hasta.SelectedItem + 1 && elem >= (DateTime)cb_dia_desde.SelectedItem).ForEach(fecha => diasHasta.Add(fecha));
            cb_dia_hasta.DataSource = diasHasta;
        }

    }
}
