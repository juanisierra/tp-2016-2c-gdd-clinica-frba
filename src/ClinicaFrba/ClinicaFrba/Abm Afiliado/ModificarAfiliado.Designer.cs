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
            this.idAfi.Location = new System.Drawing.Point(41, 33);
            this.idAfi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idAfi.Name = "idAfi";
            this.idAfi.Size = new System.Drawing.Size(131, 17);
            this.idAfi.TabIndex = 0;
            this.idAfi.Text = "Afiliado a Modificar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "EstadoCivil:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mail:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Plan Médico:";
            // 
            // tbidAfiliado
            // 
            this.tbidAfiliado.Enabled = false;
            this.tbidAfiliado.Location = new System.Drawing.Point(185, 34);
            this.tbidAfiliado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbidAfiliado.Name = "tbidAfiliado";
            this.tbidAfiliado.Size = new System.Drawing.Size(499, 22);
            this.tbidAfiliado.TabIndex = 6;
            // 
            // direc
            // 
            this.direc.Location = new System.Drawing.Point(109, 145);
            this.direc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.direc.MaxLength = 100;
            this.direc.Name = "direc";
            this.direc.Size = new System.Drawing.Size(320, 22);
            this.direc.TabIndex = 7;
            // 
            // tel
            // 
            this.tel.Location = new System.Drawing.Point(109, 194);
            this.tel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(320, 22);
            this.tel.TabIndex = 8;
            this.tel.TextChanged += new System.EventHandler(this.tel_TextChanged);
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(88, 230);
            this.mail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mail.MaxLength = 60;
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(341, 22);
            this.mail.TabIndex = 10;
            // 
            // estadoCiv
            // 
            this.estadoCiv.FormattingEnabled = true;
            this.estadoCiv.Location = new System.Drawing.Point(529, 185);
            this.estadoCiv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.estadoCiv.Name = "estadoCiv";
            this.estadoCiv.Size = new System.Drawing.Size(300, 24);
            this.estadoCiv.TabIndex = 12;
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Aceptar.Location = new System.Drawing.Point(529, 325);
            this.button_Aceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(244, 39);
            this.button_Aceptar.TabIndex = 13;
            this.button_Aceptar.Text = "Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(439, 239);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cantidad Familiares:";
            // 
            // cantFam
            // 
            this.cantFam.Enabled = false;
            this.cantFam.Location = new System.Drawing.Point(581, 230);
            this.cantFam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cantFam.Name = "cantFam";
            this.cantFam.Size = new System.Drawing.Size(248, 22);
            this.cantFam.TabIndex = 15;
            // 
            // planMed
            // 
            this.planMed.DisplayMember = "desc_plan";
            this.planMed.FormattingEnabled = true;
            this.planMed.Location = new System.Drawing.Point(140, 274);
            this.planMed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.planMed.Name = "planMed";
            this.planMed.Size = new System.Drawing.Size(289, 24);
            this.planMed.TabIndex = 16;
            // 
            // btAgregarFamiliar
            // 
            this.btAgregarFamiliar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btAgregarFamiliar.Location = new System.Drawing.Point(624, 268);
            this.btAgregarFamiliar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAgregarFamiliar.Name = "btAgregarFamiliar";
            this.btAgregarFamiliar.Size = new System.Drawing.Size(207, 26);
            this.btAgregarFamiliar.TabIndex = 17;
            this.btAgregarFamiliar.Text = "Agregar Familiar";
            this.btAgregarFamiliar.UseVisualStyleBackColor = true;
            this.btAgregarFamiliar.Click += new System.EventHandler(this.btAgregarFamiliar_Click);
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.Location = new System.Drawing.Point(41, 69);
            this.nom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(58, 17);
            this.nom.TabIndex = 18;
            this.nom.Text = "Nombre";
            // 
            // ap
            // 
            this.ap.AutoSize = true;
            this.ap.Location = new System.Drawing.Point(439, 73);
            this.ap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ap.Name = "ap";
            this.ap.Size = new System.Drawing.Size(58, 17);
            this.ap.TabIndex = 19;
            this.ap.Text = "Apellido";
            // 
            // tDoc
            // 
            this.tDoc.AutoSize = true;
            this.tDoc.Location = new System.Drawing.Point(41, 110);
            this.tDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tDoc.Name = "tDoc";
            this.tDoc.Size = new System.Drawing.Size(116, 17);
            this.tDoc.TabIndex = 20;
            this.tDoc.Text = "Tipo Documento:";
            // 
            // nDoc
            // 
            this.nDoc.AutoSize = true;
            this.nDoc.Location = new System.Drawing.Point(439, 106);
            this.nDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nDoc.Name = "nDoc";
            this.nDoc.Size = new System.Drawing.Size(107, 17);
            this.nDoc.TabIndex = 21;
            this.nDoc.Text = "Nro Documento";
            // 
            // tbNom
            // 
            this.tbNom.Enabled = false;
            this.tbNom.Location = new System.Drawing.Point(109, 69);
            this.tbNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNom.MaxLength = 40;
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(320, 22);
            this.tbNom.TabIndex = 22;
            // 
            // tbTDoc
            // 
            this.tbTDoc.Enabled = false;
            this.tbTDoc.Location = new System.Drawing.Point(168, 106);
            this.tbTDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTDoc.Name = "tbTDoc";
            this.tbTDoc.Size = new System.Drawing.Size(261, 22);
            this.tbTDoc.TabIndex = 23;
            // 
            // tbNDoc
            // 
            this.tbNDoc.Enabled = false;
            this.tbNDoc.Location = new System.Drawing.Point(548, 102);
            this.tbNDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNDoc.MaxLength = 8;
            this.tbNDoc.Name = "tbNDoc";
            this.tbNDoc.Size = new System.Drawing.Size(281, 22);
            this.tbNDoc.TabIndex = 24;
            // 
            // tbAp
            // 
            this.tbAp.Enabled = false;
            this.tbAp.Location = new System.Drawing.Point(505, 69);
            this.tbAp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAp.MaxLength = 40;
            this.tbAp.Name = "tbAp";
            this.tbAp.Size = new System.Drawing.Size(324, 22);
            this.tbAp.TabIndex = 25;
            // 
            // tbFech
            // 
            this.tbFech.Enabled = false;
            this.tbFech.Location = new System.Drawing.Point(571, 138);
            this.tbFech.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFech.Name = "tbFech";
            this.tbFech.Size = new System.Drawing.Size(259, 22);
            this.tbFech.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(439, 142);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Fecha Nacimiento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 315);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Sexo";
            // 
            // Sexo
            // 
            this.Sexo.FormattingEnabled = true;
            this.Sexo.Location = new System.Drawing.Point(101, 313);
            this.Sexo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Sexo.Name = "Sexo";
            this.Sexo.Size = new System.Drawing.Size(327, 24);
            this.Sexo.TabIndex = 29;
            // 
            // ModificarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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