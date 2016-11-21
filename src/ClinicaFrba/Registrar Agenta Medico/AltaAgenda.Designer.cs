namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class AltaAgenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.l_desde_h = new System.Windows.Forms.NumericUpDown();
            this.l_desde_m = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_hasta_m = new System.Windows.Forms.NumericUpDown();
            this.l_hasta_h = new System.Windows.Forms.NumericUpDown();
            this.l_especialidad = new System.Windows.Forms.ComboBox();
            this.label_agenda = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.franja_inicio = new System.Windows.Forms.DateTimePicker();
            this.franja_fin = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.cb_dia = new System.Windows.Forms.ComboBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_agenda = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.diaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horadesdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horahastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEspecialidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agendaDiariaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.agendaDiariaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.agendaDiariaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.l_desde_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_desde_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_hasta_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_hasta_h)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDiariaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDiariaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDiariaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(577, 404);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(83, 34);
            this.btn_aceptar.TabIndex = 1;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // l_desde_h
            // 
            this.l_desde_h.Location = new System.Drawing.Point(388, 70);
            this.l_desde_h.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.l_desde_h.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.l_desde_h.Name = "l_desde_h";
            this.l_desde_h.Size = new System.Drawing.Size(49, 22);
            this.l_desde_h.TabIndex = 2;
            this.l_desde_h.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.l_desde_h.ValueChanged += new System.EventHandler(this.l_desde_h_ValueChanged);
            // 
            // l_desde_m
            // 
            this.l_desde_m.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.l_desde_m.Location = new System.Drawing.Point(459, 70);
            this.l_desde_m.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.l_desde_m.Name = "l_desde_m";
            this.l_desde_m.Size = new System.Drawing.Size(45, 22);
            this.l_desde_m.TabIndex = 2;
            this.l_desde_m.ValueChanged += new System.EventHandler(this.l_desde_m_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "hs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(677, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "hs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(608, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = ":";
            // 
            // l_hasta_m
            // 
            this.l_hasta_m.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.l_hasta_m.Location = new System.Drawing.Point(626, 70);
            this.l_hasta_m.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.l_hasta_m.Name = "l_hasta_m";
            this.l_hasta_m.Size = new System.Drawing.Size(45, 22);
            this.l_hasta_m.TabIndex = 5;
            this.l_hasta_m.ValueChanged += new System.EventHandler(this.l_hasta_m_ValueChanged);
            // 
            // l_hasta_h
            // 
            this.l_hasta_h.Location = new System.Drawing.Point(555, 70);
            this.l_hasta_h.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.l_hasta_h.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.l_hasta_h.Name = "l_hasta_h";
            this.l_hasta_h.Size = new System.Drawing.Size(49, 22);
            this.l_hasta_h.TabIndex = 6;
            this.l_hasta_h.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.l_hasta_h.ValueChanged += new System.EventHandler(this.l_hasta_h_ValueChanged);
            // 
            // l_especialidad
            // 
            this.l_especialidad.DisplayMember = "descripcion";
            this.l_especialidad.FormattingEnabled = true;
            this.l_especialidad.Location = new System.Drawing.Point(150, 70);
            this.l_especialidad.Name = "l_especialidad";
            this.l_especialidad.Size = new System.Drawing.Size(195, 24);
            this.l_especialidad.TabIndex = 10;
            // 
            // label_agenda
            // 
            this.label_agenda.AutoSize = true;
            this.label_agenda.Location = new System.Drawing.Point(28, 9);
            this.label_agenda.Name = "label_agenda";
            this.label_agenda.Size = new System.Drawing.Size(77, 17);
            this.label_agenda.TabIndex = 12;
            this.label_agenda.Text = "Agenda de";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(47, 321);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(97, 17);
            this.label25.TabIndex = 13;
            this.label25.Text = "Franja Desde:";
            // 
            // franja_inicio
            // 
            this.franja_inicio.Location = new System.Drawing.Point(150, 319);
            this.franja_inicio.Name = "franja_inicio";
            this.franja_inicio.Size = new System.Drawing.Size(200, 22);
            this.franja_inicio.TabIndex = 14;
            // 
            // franja_fin
            // 
            this.franja_fin.Location = new System.Drawing.Point(460, 320);
            this.franja_fin.Name = "franja_fin";
            this.franja_fin.Size = new System.Drawing.Size(200, 22);
            this.franja_fin.TabIndex = 14;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(53, 36);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 17);
            this.label26.TabIndex = 15;
            this.label26.Text = "Dia";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(199, 36);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 17);
            this.label27.TabIndex = 15;
            this.label27.Text = "Especialidad";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(426, 36);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 17);
            this.label28.TabIndex = 15;
            this.label28.Text = "Desde";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(594, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 17);
            this.label29.TabIndex = 15;
            this.label29.Text = "Hasta";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(385, 323);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 17);
            this.label30.TabIndex = 13;
            this.label30.Text = "Hasta: ";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(167, 404);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(86, 34);
            this.btn_cancelar.TabIndex = 1;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // cb_dia
            // 
            this.cb_dia.DisplayMember = "nombre";
            this.cb_dia.FormattingEnabled = true;
            this.cb_dia.Location = new System.Drawing.Point(12, 70);
            this.cb_dia.Name = "cb_dia";
            this.cb_dia.Size = new System.Drawing.Size(121, 24);
            this.cb_dia.TabIndex = 16;
            this.cb_dia.SelectedIndexChanged += new System.EventHandler(this.cb_dia_SelectedIndexChanged);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(730, 74);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 17;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "diaPropio";
            this.dataGridViewTextBoxColumn1.HeaderText = "diaPropio";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dgv_agenda
            // 
            this.dgv_agenda.AutoGenerateColumns = false;
            this.dgv_agenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_agenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diaDataGridViewTextBoxColumn,
            this.horadesdeDataGridViewTextBoxColumn,
            this.horahastaDataGridViewTextBoxColumn,
            this.nombreEspecialidadDataGridViewTextBoxColumn,
            this.Eliminar});
            this.dgv_agenda.DataSource = this.agendaDiariaBindingSource;
            this.dgv_agenda.Location = new System.Drawing.Point(31, 141);
            this.dgv_agenda.Name = "dgv_agenda";
            this.dgv_agenda.RowTemplate.Height = 24;
            this.dgv_agenda.Size = new System.Drawing.Size(807, 150);
            this.dgv_agenda.TabIndex = 18;
            this.dgv_agenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_agenda_CellContentClick);
            // 
            // Eliminar
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.NullValue = "Eliminar";
            this.Eliminar.DefaultCellStyle = dataGridViewCellStyle1;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Text = "Eliminar";
            // 
            // diaDataGridViewTextBoxColumn
            // 
            this.diaDataGridViewTextBoxColumn.DataPropertyName = "diaPropio";
            this.diaDataGridViewTextBoxColumn.HeaderText = "dia";
            this.diaDataGridViewTextBoxColumn.Name = "diaDataGridViewTextBoxColumn";
            // 
            // horadesdeDataGridViewTextBoxColumn
            // 
            this.horadesdeDataGridViewTextBoxColumn.DataPropertyName = "hora_desde";
            this.horadesdeDataGridViewTextBoxColumn.HeaderText = "hora_desde";
            this.horadesdeDataGridViewTextBoxColumn.Name = "horadesdeDataGridViewTextBoxColumn";
            // 
            // horahastaDataGridViewTextBoxColumn
            // 
            this.horahastaDataGridViewTextBoxColumn.DataPropertyName = "hora_hasta";
            this.horahastaDataGridViewTextBoxColumn.HeaderText = "hora_hasta";
            this.horahastaDataGridViewTextBoxColumn.Name = "horahastaDataGridViewTextBoxColumn";
            // 
            // nombreEspecialidadDataGridViewTextBoxColumn
            // 
            this.nombreEspecialidadDataGridViewTextBoxColumn.DataPropertyName = "nombreEspecialidad";
            this.nombreEspecialidadDataGridViewTextBoxColumn.HeaderText = "Especialidad";
            this.nombreEspecialidadDataGridViewTextBoxColumn.Name = "nombreEspecialidadDataGridViewTextBoxColumn";
            // 
            // agendaDiariaBindingSource
            // 
            this.agendaDiariaBindingSource.DataSource = typeof(ClinicaFrba.Clases.Agenda_Diaria);
            // 
            // agendaDiariaBindingSource2
            // 
            this.agendaDiariaBindingSource2.DataSource = typeof(ClinicaFrba.Clases.Agenda_Diaria);
            // 
            // especialidadBindingSource
            // 
            this.especialidadBindingSource.DataSource = typeof(ClinicaFrba.Clases.Especialidad);
            // 
            // especialidadBindingSource1
            // 
            this.especialidadBindingSource1.DataSource = typeof(ClinicaFrba.Clases.Especialidad);
            // 
            // agendaDiariaBindingSource1
            // 
            this.agendaDiariaBindingSource1.DataSource = typeof(ClinicaFrba.Clases.Agenda_Diaria);
            // 
            // AltaAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.dgv_agenda);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.cb_dia);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.franja_fin);
            this.Controls.Add(this.franja_inicio);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.label_agenda);
            this.Controls.Add(this.l_especialidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.l_hasta_m);
            this.Controls.Add(this.l_hasta_h);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_desde_m);
            this.Controls.Add(this.l_desde_h);
            this.Name = "AltaAgenda";
            this.Text = "Registro de Agenda";
            this.Load += new System.EventHandler(this.AltaAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.l_desde_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_desde_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_hasta_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_hasta_h)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_agenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDiariaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDiariaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaDiariaBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.NumericUpDown l_desde_h;
        private System.Windows.Forms.NumericUpDown l_desde_m;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown l_hasta_m;
        private System.Windows.Forms.NumericUpDown l_hasta_h;
        private System.Windows.Forms.ComboBox l_especialidad;
        private System.Windows.Forms.BindingSource especialidadBindingSource;
        private System.Windows.Forms.BindingSource especialidadBindingSource1;
        private System.Windows.Forms.BindingSource agendaDiariaBindingSource;
        private System.Windows.Forms.Label label_agenda;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker franja_inicio;
        private System.Windows.Forms.DateTimePicker franja_fin;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.ComboBox cb_dia;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dgv_agenda;
        private System.Windows.Forms.BindingSource agendaDiariaBindingSource2;
        private System.Windows.Forms.BindingSource agendaDiariaBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horadesdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horahastaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreEspecialidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}