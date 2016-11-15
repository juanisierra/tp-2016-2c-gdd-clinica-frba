namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelacionProfesional
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.tb_motivo = new System.Windows.Forms.TextBox();
            this.motivo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_anio_desde = new System.Windows.Forms.ComboBox();
            this.cb_mes_desde = new System.Windows.Forms.ComboBox();
            this.cb_dia_desde = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_anio_hasta = new System.Windows.Forms.ComboBox();
            this.cb_mes_hasta = new System.Windows.Forms.ComboBox();
            this.cb_dia_hasta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Franja a cancelar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hasta";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(184, 310);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(176, 33);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar Franja";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // tb_motivo
            // 
            this.tb_motivo.Location = new System.Drawing.Point(16, 206);
            this.tb_motivo.MaxLength = 200;
            this.tb_motivo.Multiline = true;
            this.tb_motivo.Name = "tb_motivo";
            this.tb_motivo.Size = new System.Drawing.Size(520, 93);
            this.tb_motivo.TabIndex = 4;
            // 
            // motivo
            // 
            this.motivo.AutoSize = true;
            this.motivo.Location = new System.Drawing.Point(16, 184);
            this.motivo.Name = "motivo";
            this.motivo.Size = new System.Drawing.Size(53, 17);
            this.motivo.TabIndex = 5;
            this.motivo.Text = "Motivo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Año";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dia";
            // 
            // cb_anio_desde
            // 
            this.cb_anio_desde.FormattingEnabled = true;
            this.cb_anio_desde.Location = new System.Drawing.Point(19, 78);
            this.cb_anio_desde.Name = "cb_anio_desde";
            this.cb_anio_desde.Size = new System.Drawing.Size(121, 24);
            this.cb_anio_desde.TabIndex = 7;
            this.cb_anio_desde.SelectedIndexChanged += new System.EventHandler(this.cb_anio_desde_SelectedIndexChanged);
            // 
            // cb_mes_desde
            // 
            this.cb_mes_desde.FormattingEnabled = true;
            this.cb_mes_desde.Location = new System.Drawing.Point(146, 78);
            this.cb_mes_desde.Name = "cb_mes_desde";
            this.cb_mes_desde.Size = new System.Drawing.Size(121, 24);
            this.cb_mes_desde.TabIndex = 7;
            this.cb_mes_desde.SelectedIndexChanged += new System.EventHandler(this.cb_mes_desde_SelectedIndexChanged);
            // 
            // cb_dia_desde
            // 
            this.cb_dia_desde.FormattingEnabled = true;
            this.cb_dia_desde.Location = new System.Drawing.Point(273, 78);
            this.cb_dia_desde.Name = "cb_dia_desde";
            this.cb_dia_desde.Size = new System.Drawing.Size(121, 24);
            this.cb_dia_desde.TabIndex = 7;
            this.cb_dia_desde.SelectedIndexChanged += new System.EventHandler(this.cb_dia_desde_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Año";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Mes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Dia";
            // 
            // cb_anio_hasta
            // 
            this.cb_anio_hasta.FormattingEnabled = true;
            this.cb_anio_hasta.Location = new System.Drawing.Point(24, 158);
            this.cb_anio_hasta.Name = "cb_anio_hasta";
            this.cb_anio_hasta.Size = new System.Drawing.Size(121, 24);
            this.cb_anio_hasta.TabIndex = 7;
            this.cb_anio_hasta.SelectedIndexChanged += new System.EventHandler(this.cb_anio_hasta_SelectedIndexChanged);
            // 
            // cb_mes_hasta
            // 
            this.cb_mes_hasta.FormattingEnabled = true;
            this.cb_mes_hasta.Location = new System.Drawing.Point(151, 158);
            this.cb_mes_hasta.Name = "cb_mes_hasta";
            this.cb_mes_hasta.Size = new System.Drawing.Size(121, 24);
            this.cb_mes_hasta.TabIndex = 7;
            this.cb_mes_hasta.SelectedIndexChanged += new System.EventHandler(this.cb_mes_hasta_SelectedIndexChanged);
            // 
            // cb_dia_hasta
            // 
            this.cb_dia_hasta.FormattingEnabled = true;
            this.cb_dia_hasta.Location = new System.Drawing.Point(278, 158);
            this.cb_dia_hasta.Name = "cb_dia_hasta";
            this.cb_dia_hasta.Size = new System.Drawing.Size(121, 24);
            this.cb_dia_hasta.TabIndex = 7;
            // 
            // CancelacionProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 348);
            this.Controls.Add(this.cb_dia_hasta);
            this.Controls.Add(this.cb_mes_hasta);
            this.Controls.Add(this.cb_dia_desde);
            this.Controls.Add(this.cb_anio_hasta);
            this.Controls.Add(this.cb_mes_desde);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cb_anio_desde);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.motivo);
            this.Controls.Add(this.tb_motivo);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CancelacionProfesional";
            this.Text = "Cancelacion de Franja";
            this.Load += new System.EventHandler(this.CancelacionProfesional_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.TextBox tb_motivo;
        private System.Windows.Forms.Label motivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_anio_desde;
        private System.Windows.Forms.ComboBox cb_mes_desde;
        private System.Windows.Forms.ComboBox cb_dia_desde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_anio_hasta;
        private System.Windows.Forms.ComboBox cb_mes_hasta;
        private System.Windows.Forms.ComboBox cb_dia_hasta;
    }
}