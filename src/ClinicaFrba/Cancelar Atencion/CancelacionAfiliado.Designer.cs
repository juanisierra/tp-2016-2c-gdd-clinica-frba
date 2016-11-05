namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelacionAfiliado
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
            this.matriculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesionalnombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesionalapellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descespecialidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_motivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.matriculaDataGridViewTextBoxColumn,
            this.profesionalnombreDataGridViewTextBoxColumn,
            this.profesionalapellidoDataGridViewTextBoxColumn,
            this.descespecialidadDataGridViewTextBoxColumn});
            this.dgv_turno.DataSource = this.turnoBindingSource;
            this.dgv_turno.Location = new System.Drawing.Point(12, 55);
            this.dgv_turno.Name = "dgv_turno";
            this.dgv_turno.ReadOnly = true;
            this.dgv_turno.RowTemplate.Height = 24;
            this.dgv_turno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_turno.Size = new System.Drawing.Size(871, 139);
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
            // matriculaDataGridViewTextBoxColumn
            // 
            this.matriculaDataGridViewTextBoxColumn.DataPropertyName = "matricula";
            this.matriculaDataGridViewTextBoxColumn.HeaderText = "matricula";
            this.matriculaDataGridViewTextBoxColumn.Name = "matriculaDataGridViewTextBoxColumn";
            this.matriculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profesionalnombreDataGridViewTextBoxColumn
            // 
            this.profesionalnombreDataGridViewTextBoxColumn.DataPropertyName = "profesional_nombre";
            this.profesionalnombreDataGridViewTextBoxColumn.HeaderText = "profesional_nombre";
            this.profesionalnombreDataGridViewTextBoxColumn.Name = "profesionalnombreDataGridViewTextBoxColumn";
            this.profesionalnombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profesionalapellidoDataGridViewTextBoxColumn
            // 
            this.profesionalapellidoDataGridViewTextBoxColumn.DataPropertyName = "profesional_apellido";
            this.profesionalapellidoDataGridViewTextBoxColumn.HeaderText = "profesional_apellido";
            this.profesionalapellidoDataGridViewTextBoxColumn.Name = "profesionalapellidoDataGridViewTextBoxColumn";
            this.profesionalapellidoDataGridViewTextBoxColumn.ReadOnly = true;
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
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(358, 306);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(130, 29);
            this.btn_cancelar.TabIndex = 1;
            this.btn_cancelar.Text = "Cancelar Turno";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione un turno para cancelar:";
            // 
            // tb_motivo
            // 
            this.tb_motivo.Location = new System.Drawing.Point(155, 211);
            this.tb_motivo.MaxLength = 200;
            this.tb_motivo.Multiline = true;
            this.tb_motivo.Name = "tb_motivo";
            this.tb_motivo.Size = new System.Drawing.Size(550, 62);
            this.tb_motivo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Motivo Cancelacion:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CancelacionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 347);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_motivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.dgv_turno);
            this.Name = "CancelacionAfiliado";
            this.Text = "CancelacionAfiliado";
            this.Load += new System.EventHandler(this.CancelacionAfiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_turno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn idturnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaestipuladaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesionalnombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesionalapellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descespecialidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource turnoBindingSource;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_motivo;
        private System.Windows.Forms.Label label2;
    }
}