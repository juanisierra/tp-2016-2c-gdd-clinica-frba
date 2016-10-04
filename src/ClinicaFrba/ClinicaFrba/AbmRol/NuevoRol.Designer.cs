namespace ClinicaFrba.AbmRol
{
    partial class NuevoRol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaFun = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.cb_habilitar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaFun)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaFun);
            this.groupBox1.Location = new System.Drawing.Point(17, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // listaFun
            // 
            this.listaFun.AllowUserToAddRows = false;
            this.listaFun.AllowUserToDeleteRows = false;
            this.listaFun.AllowUserToResizeRows = false;
            this.listaFun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaFun.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            this.listaFun.Location = new System.Drawing.Point(5, 20);
            this.listaFun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listaFun.Name = "listaFun";
            this.listaFun.RowHeadersVisible = false;
            this.listaFun.RowTemplate.Height = 24;
            this.listaFun.Size = new System.Drawing.Size(244, 145);
            this.listaFun.TabIndex = 0;
            // 
            // Check
            // 
            this.Check.FalseValue = "false";
            this.Check.HeaderText = " ";
            this.Check.Name = "Check";
            this.Check.TrueValue = "true";
            this.Check.Width = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // tb_nombre
            // 
            this.tb_nombre.Location = new System.Drawing.Point(71, 14);
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(197, 20);
            this.tb_nombre.TabIndex = 2;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(184, 275);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(82, 23);
            this.btn_aceptar.TabIndex = 3;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(17, 275);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(82, 23);
            this.btn_limpiar.TabIndex = 4;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // cb_habilitar
            // 
            this.cb_habilitar.AutoSize = true;
            this.cb_habilitar.Location = new System.Drawing.Point(17, 234);
            this.cb_habilitar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_habilitar.Name = "cb_habilitar";
            this.cb_habilitar.Size = new System.Drawing.Size(64, 17);
            this.cb_habilitar.TabIndex = 5;
            this.cb_habilitar.Text = "Habilitar";
            this.cb_habilitar.UseVisualStyleBackColor = true;
            // 
            // NuevoRol
            // 
            this.AcceptButton = this.btn_aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 309);
            this.Controls.Add(this.cb_habilitar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.tb_nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "NuevoRol";
            this.Text = "Crear Rol";
            this.Load += new System.EventHandler(this.NuevoRol_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaFun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.DataGridView listaFun;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.CheckBox cb_habilitar;
    }
}