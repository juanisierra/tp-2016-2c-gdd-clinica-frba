namespace ClinicaFrba.AbmRol
{
    partial class ABMRol
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaRoles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listaFun = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_crear = new System.Windows.Forms.RadioButton();
            this.btn_modif = new System.Windows.Forms.RadioButton();
            this.btn_quitar = new System.Windows.Forms.RadioButton();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cb_habilitar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaRoles)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaFun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaRoles);
            this.groupBox1.Location = new System.Drawing.Point(18, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 331);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Roles";
            // 
            // listaRoles
            // 
            this.listaRoles.AllowUserToAddRows = false;
            this.listaRoles.AllowUserToDeleteRows = false;
            this.listaRoles.AllowUserToResizeRows = false;
            this.listaRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaRoles.Location = new System.Drawing.Point(6, 21);
            this.listaRoles.MultiSelect = false;
            this.listaRoles.Name = "listaRoles";
            this.listaRoles.ReadOnly = true;
            this.listaRoles.RowHeadersVisible = false;
            this.listaRoles.RowTemplate.Height = 24;
            this.listaRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaRoles.Size = new System.Drawing.Size(357, 304);
            this.listaRoles.TabIndex = 0;
            this.listaRoles.SelectionChanged += new System.EventHandler(this.listaRoles_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seleccione una acción:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listaFun);
            this.groupBox2.Location = new System.Drawing.Point(429, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(344, 246);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Funcionalidades";
            // 
            // listaFun
            // 
            this.listaFun.AllowUserToAddRows = false;
            this.listaFun.AllowUserToDeleteRows = false;
            this.listaFun.AllowUserToResizeRows = false;
            this.listaFun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaFun.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            this.listaFun.Location = new System.Drawing.Point(7, 25);
            this.listaFun.MultiSelect = false;
            this.listaFun.Name = "listaFun";
            this.listaFun.RowHeadersVisible = false;
            this.listaFun.RowTemplate.Height = 24;
            this.listaFun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaFun.Size = new System.Drawing.Size(326, 214);
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
            // tb_nombre
            // 
            this.tb_nombre.Location = new System.Drawing.Point(91, 61);
            this.tb_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.tb_nombre.MaxLength = 20;
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(290, 22);
            this.tb_nombre.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre:";
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(428, 398);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(110, 28);
            this.btn_limpiar.TabIndex = 14;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(651, 398);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(110, 28);
            this.btn_aceptar.TabIndex = 13;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_crear
            // 
            this.btn_crear.AutoSize = true;
            this.btn_crear.Checked = true;
            this.btn_crear.Location = new System.Drawing.Point(436, 60);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(64, 21);
            this.btn_crear.TabIndex = 15;
            this.btn_crear.TabStop = true;
            this.btn_crear.Text = "Crear";
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.CheckedChanged += new System.EventHandler(this.btn_crear_CheckedChanged);
            // 
            // btn_modif
            // 
            this.btn_modif.AutoSize = true;
            this.btn_modif.Location = new System.Drawing.Point(561, 60);
            this.btn_modif.Name = "btn_modif";
            this.btn_modif.Size = new System.Drawing.Size(86, 21);
            this.btn_modif.TabIndex = 16;
            this.btn_modif.Text = "Modificar";
            this.btn_modif.UseVisualStyleBackColor = true;
            this.btn_modif.CheckedChanged += new System.EventHandler(this.btn_modif_CheckedChanged);
            // 
            // btn_quitar
            // 
            this.btn_quitar.AutoSize = true;
            this.btn_quitar.Location = new System.Drawing.Point(693, 60);
            this.btn_quitar.Name = "btn_quitar";
            this.btn_quitar.Size = new System.Drawing.Size(68, 21);
            this.btn_quitar.TabIndex = 17;
            this.btn_quitar.Text = "Quitar";
            this.btn_quitar.UseVisualStyleBackColor = true;
            this.btn_quitar.CheckedChanged += new System.EventHandler(this.btn_quitar_CheckedChanged);
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(ClinicaFrba.Clases.Rol);
            // 
            // cb_habilitar
            // 
            this.cb_habilitar.AutoSize = true;
            this.cb_habilitar.Location = new System.Drawing.Point(436, 365);
            this.cb_habilitar.Name = "cb_habilitar";
            this.cb_habilitar.Size = new System.Drawing.Size(107, 21);
            this.cb_habilitar.TabIndex = 18;
            this.cb_habilitar.Text = "Habilitar Rol";
            this.cb_habilitar.UseVisualStyleBackColor = true;
            // 
            // ABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 451);
            this.Controls.Add(this.cb_habilitar);
            this.Controls.Add(this.btn_quitar);
            this.Controls.Add(this.btn_modif);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.tb_nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMRol";
            this.Text = "ABMRol";
            this.Load += new System.EventHandler(this.ABMRol_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaRoles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaFun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listaRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView listaFun;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.RadioButton btn_crear;
        private System.Windows.Forms.RadioButton btn_modif;
        private System.Windows.Forms.RadioButton btn_quitar;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.CheckBox cb_habilitar;

    }
}