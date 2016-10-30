namespace ClinicaFrba.Compra_Bono
{
    partial class SeleccionarAfiliado
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
            this.txt_idAfiliado = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_tipoDoc = new System.Windows.Forms.ComboBox();
            this.cb_plan = new System.Windows.Forms.ComboBox();
            this.btn_filtrar = new System.Windows.Forms.Button();
            this.dgv_afiliado = new System.Windows.Forms.DataGridView();
            this.idAfiliadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoCivilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descPlanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afiliadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.btn_borrar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_afiliado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afiliadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_idAfiliado
            // 
            this.txt_idAfiliado.Location = new System.Drawing.Point(81, 58);
            this.txt_idAfiliado.Name = "txt_idAfiliado";
            this.txt_idAfiliado.Size = new System.Drawing.Size(150, 22);
            this.txt_idAfiliado.TabIndex = 0;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(382, 60);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(150, 22);
            this.txt_nombre.TabIndex = 0;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(672, 58);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(150, 22);
            this.txt_apellido.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id Afiliado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(674, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Apellido";
            // 
            // txt_nDoc
            // 
            this.txt_nDoc.Location = new System.Drawing.Point(382, 115);
            this.txt_nDoc.Name = "txt_nDoc";
            this.txt_nDoc.Size = new System.Drawing.Size(150, 22);
            this.txt_nDoc.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nro Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tipo Documento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Plan";
            // 
            // cb_tipoDoc
            // 
            this.cb_tipoDoc.FormattingEnabled = true;
            this.cb_tipoDoc.Location = new System.Drawing.Point(81, 113);
            this.cb_tipoDoc.Name = "cb_tipoDoc";
            this.cb_tipoDoc.Size = new System.Drawing.Size(150, 24);
            this.cb_tipoDoc.TabIndex = 2;
            // 
            // cb_plan
            // 
            this.cb_plan.DisplayMember = "desc_plan";
            this.cb_plan.FormattingEnabled = true;
            this.cb_plan.Location = new System.Drawing.Point(672, 113);
            this.cb_plan.Name = "cb_plan";
            this.cb_plan.Size = new System.Drawing.Size(150, 24);
            this.cb_plan.TabIndex = 2;
            // 
            // btn_filtrar
            // 
            this.btn_filtrar.Location = new System.Drawing.Point(852, 60);
            this.btn_filtrar.Name = "btn_filtrar";
            this.btn_filtrar.Size = new System.Drawing.Size(117, 31);
            this.btn_filtrar.TabIndex = 3;
            this.btn_filtrar.Text = "Filtrar";
            this.btn_filtrar.UseVisualStyleBackColor = true;
            this.btn_filtrar.Click += new System.EventHandler(this.btn_filtrar_Click);
            // 
            // dgv_afiliado
            // 
            this.dgv_afiliado.AllowUserToAddRows = false;
            this.dgv_afiliado.AllowUserToDeleteRows = false;
            this.dgv_afiliado.AutoGenerateColumns = false;
            this.dgv_afiliado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_afiliado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAfiliadoDataGridViewTextBoxColumn,
            this.tipoDocDataGridViewTextBoxColumn,
            this.nroDocDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.fechaNacDataGridViewTextBoxColumn,
            this.estadoCivilDataGridViewTextBoxColumn,
            this.sexoDataGridViewTextBoxColumn,
            this.descPlanDataGridViewTextBoxColumn});
            this.dgv_afiliado.DataSource = this.afiliadoBindingSource;
            this.dgv_afiliado.Location = new System.Drawing.Point(28, 171);
            this.dgv_afiliado.MultiSelect = false;
            this.dgv_afiliado.Name = "dgv_afiliado";
            this.dgv_afiliado.ReadOnly = true;
            this.dgv_afiliado.RowTemplate.Height = 24;
            this.dgv_afiliado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_afiliado.Size = new System.Drawing.Size(952, 218);
            this.dgv_afiliado.TabIndex = 4;
            // 
            // idAfiliadoDataGridViewTextBoxColumn
            // 
            this.idAfiliadoDataGridViewTextBoxColumn.DataPropertyName = "idAfiliado";
            this.idAfiliadoDataGridViewTextBoxColumn.HeaderText = "idAfiliado";
            this.idAfiliadoDataGridViewTextBoxColumn.Name = "idAfiliadoDataGridViewTextBoxColumn";
            this.idAfiliadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoDocDataGridViewTextBoxColumn
            // 
            this.tipoDocDataGridViewTextBoxColumn.DataPropertyName = "tipoDoc";
            this.tipoDocDataGridViewTextBoxColumn.HeaderText = "tipoDoc";
            this.tipoDocDataGridViewTextBoxColumn.Name = "tipoDocDataGridViewTextBoxColumn";
            this.tipoDocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nroDocDataGridViewTextBoxColumn
            // 
            this.nroDocDataGridViewTextBoxColumn.DataPropertyName = "nroDoc";
            this.nroDocDataGridViewTextBoxColumn.HeaderText = "nroDoc";
            this.nroDocDataGridViewTextBoxColumn.Name = "nroDocDataGridViewTextBoxColumn";
            this.nroDocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            this.apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "mail";
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            this.mailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaNacDataGridViewTextBoxColumn
            // 
            this.fechaNacDataGridViewTextBoxColumn.DataPropertyName = "fechaNac";
            this.fechaNacDataGridViewTextBoxColumn.HeaderText = "fechaNac";
            this.fechaNacDataGridViewTextBoxColumn.Name = "fechaNacDataGridViewTextBoxColumn";
            this.fechaNacDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoCivilDataGridViewTextBoxColumn
            // 
            this.estadoCivilDataGridViewTextBoxColumn.DataPropertyName = "estadoCivil";
            this.estadoCivilDataGridViewTextBoxColumn.HeaderText = "estadoCivil";
            this.estadoCivilDataGridViewTextBoxColumn.Name = "estadoCivilDataGridViewTextBoxColumn";
            this.estadoCivilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sexoDataGridViewTextBoxColumn
            // 
            this.sexoDataGridViewTextBoxColumn.DataPropertyName = "sexo";
            this.sexoDataGridViewTextBoxColumn.HeaderText = "sexo";
            this.sexoDataGridViewTextBoxColumn.Name = "sexoDataGridViewTextBoxColumn";
            this.sexoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descPlanDataGridViewTextBoxColumn
            // 
            this.descPlanDataGridViewTextBoxColumn.DataPropertyName = "descPlan";
            this.descPlanDataGridViewTextBoxColumn.HeaderText = "descPlan";
            this.descPlanDataGridViewTextBoxColumn.Name = "descPlanDataGridViewTextBoxColumn";
            this.descPlanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // afiliadoBindingSource
            // 
            this.afiliadoBindingSource.DataSource = typeof(ClinicaFrba.Clases.Afiliado);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.Location = new System.Drawing.Point(502, 414);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(127, 31);
            this.btn_seleccionar.TabIndex = 3;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.UseVisualStyleBackColor = true;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // btn_borrar
            // 
            this.btn_borrar.Location = new System.Drawing.Point(852, 109);
            this.btn_borrar.Name = "btn_borrar";
            this.btn_borrar.Size = new System.Drawing.Size(117, 31);
            this.btn_borrar.TabIndex = 3;
            this.btn_borrar.Text = "Borrar Filtros";
            this.btn_borrar.UseVisualStyleBackColor = true;
            this.btn_borrar.Click += new System.EventHandler(this.btn_borrar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(362, 414);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(127, 31);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // SeleccionarAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 457);
            this.Controls.Add(this.dgv_afiliado);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.btn_borrar);
            this.Controls.Add(this.btn_filtrar);
            this.Controls.Add(this.cb_plan);
            this.Controls.Add(this.cb_tipoDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.txt_nDoc);
            this.Controls.Add(this.txt_idAfiliado);
            this.Name = "SeleccionarAfiliado";
            this.Text = "SeleccionarAfiliado";
            this.Load += new System.EventHandler(this.SeleccionarAfiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_afiliado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afiliadoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_idAfiliado;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_tipoDoc;
        private System.Windows.Forms.ComboBox cb_plan;
        private System.Windows.Forms.Button btn_filtrar;
        private System.Windows.Forms.DataGridView dgv_afiliado;
        private System.Windows.Forms.BindingSource afiliadoBindingSource;
        private System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAfiliadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoCivilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descPlanDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn_borrar;
        private System.Windows.Forms.Button btn_cancelar;
    }
}