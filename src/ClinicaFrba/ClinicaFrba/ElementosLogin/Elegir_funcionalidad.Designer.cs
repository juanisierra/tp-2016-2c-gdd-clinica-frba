namespace ClinicaFrba.ElementosLogin
{
    partial class Elegir_funcionalidad
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
            this.cb_funcionalidad = new System.Windows.Forms.ComboBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_funcionalidad
            // 
            this.cb_funcionalidad.DisplayMember = "descripcion";
            this.cb_funcionalidad.FormattingEnabled = true;
            this.cb_funcionalidad.Location = new System.Drawing.Point(79, 50);
            this.cb_funcionalidad.Name = "cb_funcionalidad";
            this.cb_funcionalidad.Size = new System.Drawing.Size(314, 24);
            this.cb_funcionalidad.TabIndex = 0;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(195, 106);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 1;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // Elegir_funcionalidad
            // 
            this.AcceptButton = this.btn_aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 141);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.cb_funcionalidad);
            this.Name = "Elegir_funcionalidad";
            this.Text = "Elegir_funcionalidad";
            this.Load += new System.EventHandler(this.Elegir_funcionalidad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_funcionalidad;
        private System.Windows.Forms.Button btn_aceptar;
    }
}