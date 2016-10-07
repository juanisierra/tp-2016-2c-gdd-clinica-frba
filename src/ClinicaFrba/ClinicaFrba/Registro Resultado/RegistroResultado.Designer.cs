namespace ClinicaFrba.Registro_Resultado
{
    partial class RegistroResultado
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
            this.idturnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaestipuladaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idafiliadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afiliadonombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afiliadoapellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.momentollegadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descespecialidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_turno = new System.Windows.Forms.Label();
            this.dt_dia = new System.Windows.Forms.DateTimePicker();
            this.dt_hora = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_sintomas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_diagnostico = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turno)).BeginInit();
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
            this.idafiliadoDataGridViewTextBoxColumn,
            this.afiliadonombreDataGridViewTextBoxColumn,
            this.afiliadoapellidoDataGridViewTextBoxColumn,
            this.momentollegadaDataGridViewTextBoxColumn,
            this.descespecialidadDataGridViewTextBoxColumn});
            this.dgv_turno.DataSource = this.turnoBindingSource;
            this.dgv_turno.Location = new System.Drawing.Point(12, 47);
            this.dgv_turno.Name = "dgv_turno";
            this.dgv_turno.ReadOnly = true;
            this.dgv_turno.RowTemplate.Height = 24;
            this.dgv_turno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turno.Size = new System.Drawing.Size(976, 169);
            this.dgv_turno.TabIndex = 0;
            this.dgv_turno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_turno_CellContentClick);
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
            // afiliadonombreDataGridViewTextBoxColumn
            // 
            this.afiliadonombreDataGridViewTextBoxColumn.DataPropertyName = "afiliado_nombre";
            this.afiliadonombreDataGridViewTextBoxColumn.HeaderText = "afiliado_nombre";
            this.afiliadonombreDataGridViewTextBoxColumn.Name = "afiliadonombreDataGridViewTextBoxColumn";
            this.afiliadonombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // afiliadoapellidoDataGridViewTextBoxColumn
            // 
            this.afiliadoapellidoDataGridViewTextBoxColumn.DataPropertyName = "afiliado_apellido";
            this.afiliadoapellidoDataGridViewTextBoxColumn.HeaderText = "afiliado_apellido";
            this.afiliadoapellidoDataGridViewTextBoxColumn.Name = "afiliadoapellidoDataGridViewTextBoxColumn";
            this.afiliadoapellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // momentollegadaDataGridViewTextBoxColumn
            // 
            this.momentollegadaDataGridViewTextBoxColumn.DataPropertyName = "momento_llegada";
            this.momentollegadaDataGridViewTextBoxColumn.HeaderText = "momento_llegada";
            this.momentollegadaDataGridViewTextBoxColumn.Name = "momentollegadaDataGridViewTextBoxColumn";
            this.momentollegadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descespecialidadDataGridViewTextBoxColumn
            // 
            this.descespecialidadDataGridViewTextBoxColumn.DataPropertyName = "desc_especialidad";
            this.descespecialidadDataGridViewTextBoxColumn.HeaderText = "desc_especialidad";
            this.descespecialidadDataGridViewTextBoxColumn.Name = "descespecialidadDataGridViewTextBoxColumn";
            this.descespecialidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // turnoBindingSource
            // 
            this.turnoBindingSource.DataSource = typeof(ClinicaFrba.Clases.Turno);
            // 
            // label_turno
            // 
            this.label_turno.AutoSize = true;
            this.label_turno.Location = new System.Drawing.Point(22, 20);
            this.label_turno.Name = "label_turno";
            this.label_turno.Size = new System.Drawing.Size(50, 17);
            this.label_turno.TabIndex = 1;
            this.label_turno.Text = "Turno:";
            // 
            // dt_dia
            // 
            this.dt_dia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_dia.Location = new System.Drawing.Point(25, 257);
            this.dt_dia.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dt_dia.Name = "dt_dia";
            this.dt_dia.Size = new System.Drawing.Size(299, 22);
            this.dt_dia.TabIndex = 2;
            this.dt_dia.ValueChanged += new System.EventHandler(this.dt_dia_ValueChanged);
            // 
            // dt_hora
            // 
            this.dt_hora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dt_hora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_hora.Location = new System.Drawing.Point(336, 257);
            this.dt_hora.Name = "dt_hora";
            this.dt_hora.ShowUpDown = true;
            this.dt_hora.Size = new System.Drawing.Size(100, 22);
            this.dt_hora.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha y Hora de la Atencion";
            // 
            // tb_sintomas
            // 
            this.tb_sintomas.Location = new System.Drawing.Point(25, 309);
            this.tb_sintomas.MaxLength = 200;
            this.tb_sintomas.Multiline = true;
            this.tb_sintomas.Name = "tb_sintomas";
            this.tb_sintomas.Size = new System.Drawing.Size(947, 48);
            this.tb_sintomas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sintomas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Diagnostico";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(425, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_diagnostico
            // 
            this.tb_diagnostico.Location = new System.Drawing.Point(25, 386);
            this.tb_diagnostico.MaxLength = 200;
            this.tb_diagnostico.Multiline = true;
            this.tb_diagnostico.Name = "tb_diagnostico";
            this.tb_diagnostico.Size = new System.Drawing.Size(947, 51);
            this.tb_diagnostico.TabIndex = 4;
            // 
            // RegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 489);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_diagnostico);
            this.Controls.Add(this.tb_sintomas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_hora);
            this.Controls.Add(this.dt_dia);
            this.Controls.Add(this.label_turno);
            this.Controls.Add(this.dgv_turno);
            this.Name = "RegistroResultado";
            this.Text = "Registrar Resultado";
            this.Load += new System.EventHandler(this.RegistroResultado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_turno;
        private System.Windows.Forms.Label label_turno;
        private System.Windows.Forms.DateTimePicker dt_dia;
        private System.Windows.Forms.DateTimePicker dt_hora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sintomas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idturnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaestipuladaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idafiliadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliadonombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afiliadoapellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn momentollegadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descespecialidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource turnoBindingSource;
        private System.Windows.Forms.TextBox tb_diagnostico;
    }
}