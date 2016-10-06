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
            this.btn_aceptar.Location = new System.Drawing.Point(168, 114);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 1;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // SeleccionarEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 194);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.cb_especialidad);
            this.Name = "SeleccionarEspecialidad";
            this.Text = "SeleccionarEspecialidad";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_especialidad;
        private System.Windows.Forms.Button btn_aceptar;
    }
}