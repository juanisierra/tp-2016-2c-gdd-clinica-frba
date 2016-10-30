namespace ClinicaFrba.Pedir_Turno
{
    partial class PedirTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_hora = new System.Windows.Forms.ComboBox();
            this.label_nombre_profesional = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.label_especialidad = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.cb_anio = new System.Windows.Forms.ComboBox();
            this.cb_mes = new System.Windows.Forms.ComboBox();
            this.cb_dia_mes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cb_hora
            // 
            this.cb_hora.FormattingEnabled = true;
            this.cb_hora.Location = new System.Drawing.Point(142, 127);
            this.cb_hora.Name = "cb_hora";
            this.cb_hora.Size = new System.Drawing.Size(404, 24);
            this.cb_hora.TabIndex = 0;
            // 
            // label_nombre_profesional
            // 
            this.label_nombre_profesional.AutoSize = true;
            this.label_nombre_profesional.Location = new System.Drawing.Point(73, 9);
            this.label_nombre_profesional.Name = "label_nombre_profesional";
            this.label_nombre_profesional.Size = new System.Drawing.Size(165, 17);
            this.label_nombre_profesional.TabIndex = 1;
            this.label_nombre_profesional.Text = "Turno con el Dr. Ejemplo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hora:";
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(370, 188);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(165, 23);
            this.btn_aceptar.TabIndex = 3;
            this.btn_aceptar.Text = "Confirmar Turno";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // label_especialidad
            // 
            this.label_especialidad.AutoSize = true;
            this.label_especialidad.Location = new System.Drawing.Point(73, 39);
            this.label_especialidad.Name = "label_especialidad";
            this.label_especialidad.Size = new System.Drawing.Size(96, 17);
            this.label_especialidad.TabIndex = 4;
            this.label_especialidad.Text = "Especialidad: ";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(154, 188);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(165, 23);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // cb_anio
            // 
            this.cb_anio.FormattingEnabled = true;
            this.cb_anio.Location = new System.Drawing.Point(142, 84);
            this.cb_anio.Name = "cb_anio";
            this.cb_anio.Size = new System.Drawing.Size(121, 24);
            this.cb_anio.TabIndex = 5;
            this.cb_anio.SelectedIndexChanged += new System.EventHandler(this.cb_anio_SelectedIndexChanged);
            // 
            // cb_mes
            // 
            this.cb_mes.FormattingEnabled = true;
            this.cb_mes.Location = new System.Drawing.Point(278, 84);
            this.cb_mes.Name = "cb_mes";
            this.cb_mes.Size = new System.Drawing.Size(121, 24);
            this.cb_mes.TabIndex = 5;
            this.cb_mes.SelectedIndexChanged += new System.EventHandler(this.cb_mes_SelectedIndexChanged);
            // 
            // cb_dia_mes
            // 
            this.cb_dia_mes.DisplayMember = "Day";
            this.cb_dia_mes.FormattingEnabled = true;
            this.cb_dia_mes.Location = new System.Drawing.Point(425, 84);
            this.cb_dia_mes.Name = "cb_dia_mes";
            this.cb_dia_mes.Size = new System.Drawing.Size(121, 24);
            this.cb_dia_mes.TabIndex = 5;
            this.cb_dia_mes.SelectedIndexChanged += new System.EventHandler(this.cb_dia_mes_SelectedIndexChanged);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 264);
            this.Controls.Add(this.cb_dia_mes);
            this.Controls.Add(this.cb_mes);
            this.Controls.Add(this.cb_anio);
            this.Controls.Add(this.label_especialidad);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_nombre_profesional);
            this.Controls.Add(this.cb_hora);
            this.Name = "PedirTurno";
            this.Text = "Pedido de Turno";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_hora;
        private System.Windows.Forms.Label label_nombre_profesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Label label_especialidad;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.ComboBox cb_anio;
        private System.Windows.Forms.ComboBox cb_mes;
        private System.Windows.Forms.ComboBox cb_dia_mes;
    }
}