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
            this.cb_dia = new System.Windows.Forms.ComboBox();
            this.cb_hora = new System.Windows.Forms.ComboBox();
            this.label_nombre_profesional = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_dia
            // 
            this.cb_dia.FormattingEnabled = true;
            this.cb_dia.Location = new System.Drawing.Point(142, 81);
            this.cb_dia.Name = "cb_dia";
            this.cb_dia.Size = new System.Drawing.Size(404, 24);
            this.cb_dia.TabIndex = 0;
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
            this.label_nombre_profesional.Location = new System.Drawing.Point(73, 28);
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
            this.btn_aceptar.Location = new System.Drawing.Point(259, 189);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(165, 23);
            this.btn_aceptar.TabIndex = 3;
            this.btn_aceptar.Text = "Confirmar Turno";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 264);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_nombre_profesional);
            this.Controls.Add(this.cb_hora);
            this.Controls.Add(this.cb_dia);
            this.Name = "PedirTurno";
            this.Text = "Pedido de Turno";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_dia;
        private System.Windows.Forms.ComboBox cb_hora;
        private System.Windows.Forms.Label label_nombre_profesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_aceptar;
    }
}