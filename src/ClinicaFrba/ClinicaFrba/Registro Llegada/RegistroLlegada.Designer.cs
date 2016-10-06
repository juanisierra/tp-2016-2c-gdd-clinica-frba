namespace ClinicaFrba.Registro_Llegada
{
    partial class RegistroLlegada
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
            this.dgv_turno = new System.Windows.Forms.DataGridView();
            this.afiliado_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afiliado_apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idturnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaestipuladaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idafiliadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matriculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.turnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_seleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_turno
            // 
            this.dgv_turno.AutoGenerateColumns = false;
            this.dgv_turno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_turno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idturnoDataGridViewTextBoxColumn,
            this.fechaestipuladaDataGridViewTextBoxColumn,
            this.afiliado_nombre,
            this.afiliado_apellido,
            this.idafiliadoDataGridViewTextBoxColumn,
            this.desc_especialidad,
            this.matriculaDataGridViewTextBoxColumn});
            this.dgv_turno.DataSource = this.turnoBindingSource1;
            this.dgv_turno.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_turno.Location = new System.Drawing.Point(22, 54);
            this.dgv_turno.MultiSelect = false;
            this.dgv_turno.Name = "dgv_turno";
            this.dgv_turno.ReadOnly = true;
            this.dgv_turno.RowTemplate.Height = 24;
            this.dgv_turno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turno.Size = new System.Drawing.Size(881, 280);
            this.dgv_turno.TabIndex = 0;
            // 
            // afiliado_nombre
            // 
            this.afiliado_nombre.DataPropertyName = "afiliado_nombre";
            this.afiliado_nombre.HeaderText = "afiliado_nombre";
            this.afiliado_nombre.Name = "afiliado_nombre";
            this.afiliado_nombre.ReadOnly = true;
            // 
            // afiliado_apellido
            // 
            this.afiliado_apellido.DataPropertyName = "afiliado_apellido";
            this.afiliado_apellido.HeaderText = "afiliado_apellido";
            this.afiliado_apellido.Name = "afiliado_apellido";
            this.afiliado_apellido.ReadOnly = true;
            // 
            // desc_especialidad
            // 
            this.desc_especialidad.DataPropertyName = "desc_especialidad";
            this.desc_especialidad.HeaderText = "desc_especialidad";
            this.desc_especialidad.Name = "desc_especialidad";
            this.desc_especialidad.ReadOnly = true;
            // 
            // idturnoDataGridViewTextBoxColumn
            // 
            this.idturnoDataGridViewTextBoxColumn.DataPropertyName = "id_turno";
            this.idturnoDataGridViewTextBoxColumn.HeaderText = "id_turno";
            this.idturnoDataGridViewTextBoxColumn.Name = "idturnoDataGridViewTextBoxColumn";
            this.idturnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaestipuladaDataGridViewTextBoxColumn
            // 
            this.fechaestipuladaDataGridViewTextBoxColumn.DataPropertyName = "fecha_estipulada";
            this.fechaestipuladaDataGridViewTextBoxColumn.HeaderText = "fecha_estipulada";
            this.fechaestipuladaDataGridViewTextBoxColumn.Name = "fechaestipuladaDataGridViewTextBoxColumn";
            this.fechaestipuladaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idafiliadoDataGridViewTextBoxColumn
            // 
            this.idafiliadoDataGridViewTextBoxColumn.DataPropertyName = "id_afiliado";
            this.idafiliadoDataGridViewTextBoxColumn.HeaderText = "id_afiliado";
            this.idafiliadoDataGridViewTextBoxColumn.Name = "idafiliadoDataGridViewTextBoxColumn";
            this.idafiliadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // matriculaDataGridViewTextBoxColumn
            // 
            this.matriculaDataGridViewTextBoxColumn.DataPropertyName = "matricula";
            this.matriculaDataGridViewTextBoxColumn.HeaderText = "matricula";
            this.matriculaDataGridViewTextBoxColumn.Name = "matriculaDataGridViewTextBoxColumn";
            this.matriculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoBindingSource1
            // 
            this.turnoBindingSource1.DataSource = typeof(ClinicaFrba.Clases.Turno);
            // 
            // turnoBindingSource
            // 
            this.turnoBindingSource.DataSource = typeof(ClinicaFrba.Clases.Turno);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.Location = new System.Drawing.Point(689, 374);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(114, 23);
            this.btn_seleccionar.TabIndex = 1;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.UseVisualStyleBackColor = true;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 443);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.dgv_turno);
            this.Name = "RegistroLlegada";
            this.Text = "Registro de Llegada";
            this.Load += new System.EventHandler(this.RegistroLlegada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_turno;
        private System.Windows.Forms.BindingSource turnoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idturnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaestipuladaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliado_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliado_apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idafiliadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource turnoBindingSource1;
        private System.Windows.Forms.Button btn_seleccionar;
    }
}