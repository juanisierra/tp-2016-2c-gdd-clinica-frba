namespace ClinicaFrba.Abm_Afiliado
{
    partial class ModificarAfiliado
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbidAfiliado = new System.Windows.Forms.TextBox();
            this.direc = new System.Windows.Forms.TextBox();
            this.tel = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.TextBox();
            this.estadoCiv = new System.Windows.Forms.ComboBox();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cantFam = new System.Windows.Forms.TextBox();
            this.planMed = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Afiliado a Modificar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "EstadoCivil:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Plan Médico:";
            // 
            // tbidAfiliado
            // 
            this.tbidAfiliado.Enabled = false;
            this.tbidAfiliado.Location = new System.Drawing.Point(139, 28);
            this.tbidAfiliado.Name = "tbidAfiliado";
            this.tbidAfiliado.Size = new System.Drawing.Size(113, 20);
            this.tbidAfiliado.TabIndex = 6;
            // 
            // direc
            // 
            this.direc.Location = new System.Drawing.Point(92, 80);
            this.direc.MaxLength = 100;
            this.direc.Name = "direc";
            this.direc.Size = new System.Drawing.Size(147, 20);
            this.direc.TabIndex = 7;
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(92, 107);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(147, 20);
            this.tel.TabIndex = 8;
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(66, 133);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(173, 20);
            this.mail.TabIndex = 10;
            // 
            // estadoCiv
            // 
            this.estadoCiv.FormattingEnabled = true;
            this.estadoCiv.Location = new System.Drawing.Point(104, 164);
            this.estadoCiv.Name = "estadoCiv";
            this.estadoCiv.Size = new System.Drawing.Size(134, 21);
            this.estadoCiv.TabIndex = 12;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(67, 253);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(171, 27);
            this.button_Aceptar.TabIndex = 13;
            this.button_Aceptar.Text = "Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cantidad Familiares:";
            // 
            // cantFam
            // 
            this.cantFam.Location = new System.Drawing.Point(135, 217);
            this.cantFam.Name = "cantFam";
            this.cantFam.Size = new System.Drawing.Size(104, 20);
            this.cantFam.TabIndex = 15;
            // 
            // planMed
            // 
            this.planMed.FormattingEnabled = true;
            this.planMed.Location = new System.Drawing.Point(104, 190);
            this.planMed.Name = "planMed";
            this.planMed.Size = new System.Drawing.Size(134, 21);
            this.planMed.TabIndex = 16;
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 292);
            this.Controls.Add(this.planMed);
            this.Controls.Add(this.cantFam);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.estadoCiv);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.direc);
            this.Controls.Add(this.tbidAfiliado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificarAfiliado";
            this.Text = "ModificarAfiliado";
            this.Load += new System.EventHandler(this.ModificarAfiliado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbidAfiliado;
        private System.Windows.Forms.TextBox direc;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.ComboBox estadoCiv;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cantFam;
        private System.Windows.Forms.ComboBox planMed;
    }
}