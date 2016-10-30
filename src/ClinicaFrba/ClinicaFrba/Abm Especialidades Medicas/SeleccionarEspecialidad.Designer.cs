namespace ClinicaFrba.Abm_Especialidades_Medicas
{
    partial class SeleccionarEspecialidad
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
            this.cb_especialidad = new System.Windows.Forms.ComboBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_especialidad
            // 
            this.cb_especialidad.DisplayMember = "descripcion";
            this.cb_especialidad.FormattingEnabled = true;
            this.cb_especialidad.Location = new System.Drawing.Point(67, 59);
            this.cb_especialidad.Name = "cb_especialidad";
            this.cb_especialidad.Size = new System.Drawing.Size(272, 24);
            this.cb_especialidad.TabIndex = 0;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(226, 99);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 1;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(95, 99);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 1;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // SeleccionarEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 155);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.cb_especialidad);
            this.Name = "SeleccionarEspecialidad";
            this.Text = "SeleccionarEspecialidad";
            this.Load += new System.EventHandler(this.SeleccionarEspecialidad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_especialidad;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_cancelar;
    }
}