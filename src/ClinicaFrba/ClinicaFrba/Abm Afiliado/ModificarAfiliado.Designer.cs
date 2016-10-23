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
            this.idAfi = new System.Windows.Forms.Label();
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
            this.btAgregarFamiliar = new System.Windows.Forms.Button();
            this.nom = new System.Windows.Forms.Label();
            this.ap = new System.Windows.Forms.Label();
            this.tDoc = new System.Windows.Forms.Label();
            this.nDoc = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.tbTDoc = new System.Windows.Forms.TextBox();
            this.tbNDoc = new System.Windows.Forms.TextBox();
            this.tbAp = new System.Windows.Forms.TextBox();
            this.tbFech = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Sexo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // idAfi
            // 
            this.idAfi.AutoSize = true;
            this.idAfi.Location = new System.Drawing.Point(31, 27);
            this.idAfi.Name = "idAfi";
            this.idAfi.Size = new System.Drawing.Size(99, 13);
            this.idAfi.TabIndex = 0;
            this.idAfi.Text = "Afiliado a Modificar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "EstadoCivil:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 226);
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
            this.tbidAfiliado.Size = new System.Drawing.Size(375, 20);
            this.tbidAfiliado.TabIndex = 6;
            // 
            // direc
            // 
            this.direc.Location = new System.Drawing.Point(82, 118);
            this.direc.MaxLength = 100;
            this.direc.Name = "direc";
            this.direc.Size = new System.Drawing.Size(241, 20);
            this.direc.TabIndex = 7;
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(82, 158);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(241, 20);
            this.tel.TabIndex = 8;
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(66, 187);
            this.mail.MaxLength = 60;
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(257, 20);
            this.mail.TabIndex = 10;
            // 
            // estadoCiv
            // 
            this.estadoCiv.FormattingEnabled = true;
            this.estadoCiv.Location = new System.Drawing.Point(397, 150);
            this.estadoCiv.Name = "estadoCiv";
            this.estadoCiv.Size = new System.Drawing.Size(226, 21);
            this.estadoCiv.TabIndex = 12;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Aceptar.Location = new System.Drawing.Point(397, 264);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(183, 32);
            this.button_Aceptar.TabIndex = 13;
            this.button_Aceptar.Text = "Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cantidad Familiares:";
            // 
            // cantFam
            // 
            this.cantFam.Enabled = false;
            this.cantFam.Location = new System.Drawing.Point(436, 187);
            this.cantFam.Name = "cantFam";
            this.cantFam.Size = new System.Drawing.Size(187, 20);
            this.cantFam.TabIndex = 15;
            // 
            // planMed
            // 
            this.planMed.DisplayMember = "desc_plan";
            this.planMed.FormattingEnabled = true;
            this.planMed.Location = new System.Drawing.Point(105, 223);
            this.planMed.Name = "planMed";
            this.planMed.Size = new System.Drawing.Size(218, 21);
            this.planMed.TabIndex = 16;
            // 
            // btAgregarFamiliar
            // 
            this.btAgregarFamiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btAgregarFamiliar.Location = new System.Drawing.Point(468, 218);
            this.btAgregarFamiliar.Name = "btAgregarFamiliar";
            this.btAgregarFamiliar.Size = new System.Drawing.Size(155, 21);
            this.btAgregarFamiliar.TabIndex = 17;
            this.btAgregarFamiliar.Text = "Agregar Familiar";
            this.btAgregarFamiliar.UseVisualStyleBackColor = true;
            this.btAgregarFamiliar.Click += new System.EventHandler(this.btAgregarFamiliar_Click);
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.Location = new System.Drawing.Point(31, 56);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(44, 13);
            this.nom.TabIndex = 18;
            this.nom.Text = "Nombre";
            // 
            // ap
            // 
            this.ap.AutoSize = true;
            this.ap.Location = new System.Drawing.Point(329, 59);
            this.ap.Name = "ap";
            this.ap.Size = new System.Drawing.Size(44, 13);
            this.ap.TabIndex = 19;
            this.ap.Text = "Apellido";
            // 
            // tDoc
            // 
            this.tDoc.AutoSize = true;
            this.tDoc.Location = new System.Drawing.Point(31, 89);
            this.tDoc.Name = "tDoc";
            this.tDoc.Size = new System.Drawing.Size(89, 13);
            this.tDoc.TabIndex = 20;
            this.tDoc.Text = "Tipo Documento:";
            // 
            // nDoc
            // 
            this.nDoc.AutoSize = true;
            this.nDoc.Location = new System.Drawing.Point(329, 86);
            this.nDoc.Name = "nDoc";
            this.nDoc.Size = new System.Drawing.Size(82, 13);
            this.nDoc.TabIndex = 21;
            this.nDoc.Text = "Nro Documento";
            // 
            // tbNom
            // 
            this.tbNom.Enabled = false;
            this.tbNom.Location = new System.Drawing.Point(82, 56);
            this.tbNom.MaxLength = 40;
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(241, 20);
            this.tbNom.TabIndex = 22;
            // 
            // tbTDoc
            // 
            this.tbTDoc.Enabled = false;
            this.tbTDoc.Location = new System.Drawing.Point(126, 86);
            this.tbTDoc.Name = "tbTDoc";
            this.tbTDoc.Size = new System.Drawing.Size(197, 20);
            this.tbTDoc.TabIndex = 23;
            // 
            // tbNDoc
            // 
            this.tbNDoc.Enabled = false;
            this.tbNDoc.Location = new System.Drawing.Point(411, 83);
            this.tbNDoc.MaxLength = 8;
            this.tbNDoc.Name = "tbNDoc";
            this.tbNDoc.Size = new System.Drawing.Size(212, 20);
            this.tbNDoc.TabIndex = 24;
            // 
            // tbAp
            // 
            this.tbAp.Enabled = false;
            this.tbAp.Location = new System.Drawing.Point(379, 56);
            this.tbAp.MaxLength = 40;
            this.tbAp.Name = "tbAp";
            this.tbAp.Size = new System.Drawing.Size(244, 20);
            this.tbAp.TabIndex = 25;
            // 
            // tbFech
            // 
            this.tbFech.Enabled = false;
            this.tbFech.Location = new System.Drawing.Point(428, 112);
            this.tbFech.Name = "tbFech";
            this.tbFech.Size = new System.Drawing.Size(195, 20);
            this.tbFech.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(329, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Fecha Nacimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Sexo";
            // 
            // Sexo
            // 
            this.Sexo.FormattingEnabled = true;
            this.Sexo.Location = new System.Drawing.Point(76, 254);
            this.Sexo.Name = "Sexo";
            this.Sexo.Size = new System.Drawing.Size(246, 21);
            this.Sexo.TabIndex = 29;
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 395);
            this.Controls.Add(this.Sexo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbFech);
            this.Controls.Add(this.tbAp);
            this.Controls.Add(this.tbNDoc);
            this.Controls.Add(this.tbTDoc);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.nDoc);
            this.Controls.Add(this.tDoc);
            this.Controls.Add(this.ap);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.btAgregarFamiliar);
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
            this.Controls.Add(this.idAfi);
            this.Name = "ModificarAfiliado";
            this.Text = "ModificarAfiliado";
            this.Load += new System.EventHandler(this.ModificarAfiliado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idAfi;
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
        private System.Windows.Forms.Button btAgregarFamiliar;
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Label ap;
        private System.Windows.Forms.Label tDoc;
        private System.Windows.Forms.Label nDoc;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.TextBox tbTDoc;
        private System.Windows.Forms.TextBox tbNDoc;
        private System.Windows.Forms.TextBox tbAp;
        private System.Windows.Forms.TextBox tbFech;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Sexo;
    }
}