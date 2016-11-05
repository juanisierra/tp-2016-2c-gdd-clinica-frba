namespace ClinicaFrba.Registro_Llegada
{
    partial class SeleccionarBono
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
            this.label_bonos = new System.Windows.Forms.Label();
            this.cb_id_bono = new System.Windows.Forms.ComboBox();
            this.btn_utilizar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_bonos
            // 
            this.label_bonos.AutoSize = true;
            this.label_bonos.Location = new System.Drawing.Point(37, 24);
            this.label_bonos.Name = "label_bonos";
            this.label_bonos.Size = new System.Drawing.Size(129, 17);
            this.label_bonos.TabIndex = 0;
            this.label_bonos.Text = "Bonos Disponibles:";
            // 
            // cb_id_bono
            // 
            this.cb_id_bono.FormattingEnabled = true;
            this.cb_id_bono.Location = new System.Drawing.Point(185, 21);
            this.cb_id_bono.Name = "cb_id_bono";
            this.cb_id_bono.Size = new System.Drawing.Size(149, 24);
            this.cb_id_bono.TabIndex = 1;
            // 
            // btn_utilizar
            // 
            this.btn_utilizar.Location = new System.Drawing.Point(253, 87);
            this.btn_utilizar.Name = "btn_utilizar";
            this.btn_utilizar.Size = new System.Drawing.Size(152, 23);
            this.btn_utilizar.TabIndex = 2;
            this.btn_utilizar.Text = "Utilizar Bono";
            this.btn_utilizar.UseVisualStyleBackColor = true;
            this.btn_utilizar.Click += new System.EventHandler(this.btn_utilizar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(95, 87);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(152, 23);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // SeleccionarBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 137);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_utilizar);
            this.Controls.Add(this.cb_id_bono);
            this.Controls.Add(this.label_bonos);
            this.Name = "SeleccionarBono";
            this.Text = "SeleccionarBono";
            this.Load += new System.EventHandler(this.SeleccionarBono_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_bonos;
        private System.Windows.Forms.ComboBox cb_id_bono;
        private System.Windows.Forms.Button btn_utilizar;
        private System.Windows.Forms.Button btn_cancelar;
    }
}