namespace ClinicaFrba.Abm_Profesional
{
    partial class SeleccionarProfesionalPorEspecialidad
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
            this.dgv_profesional = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_especialidad = new System.Windows.Forms.ComboBox();
            this.especialidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.profesionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.seleccionarProfesionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_profesional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesionalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seleccionarProfesionalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_profesional
            // 
            this.dgv_profesional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_profesional.Location = new System.Drawing.Point(26, 51);
            this.dgv_profesional.MultiSelect = false;
            this.dgv_profesional.Name = "dgv_profesional";
            this.dgv_profesional.ReadOnly = true;
            this.dgv_profesional.RowTemplate.Height = 24;
            this.dgv_profesional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_profesional.Size = new System.Drawing.Size(1009, 246);
            this.dgv_profesional.TabIndex = 0;
            this.dgv_profesional.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_profesional_CellContentClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1038, 0);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(813, 365);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(176, 36);
            this.btn_aceptar.TabIndex = 2;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione un profesional";
            // 
            // cb_especialidad
            // 
            this.cb_especialidad.DisplayMember = "descripcion";
            this.cb_especialidad.FormattingEnabled = true;
            this.cb_especialidad.Location = new System.Drawing.Point(499, 12);
            this.cb_especialidad.Name = "cb_especialidad";
            this.cb_especialidad.Size = new System.Drawing.Size(318, 24);
            this.cb_especialidad.Sorted = true;
            this.cb_especialidad.TabIndex = 4;
            this.cb_especialidad.ValueMember = "id_especialidad";
            this.cb_especialidad.SelectedIndexChanged += new System.EventHandler(this.cb_especialidad_SelectedIndexChanged);
            // 
            // especialidadesBindingSource
            // 
            this.especialidadesBindingSource.DataMember = "especialidades";
            this.especialidadesBindingSource.DataSource = this.profesionalBindingSource;
            // 
            // profesionalBindingSource
            // 
            this.profesionalBindingSource.DataSource = typeof(ClinicaFrba.Clases.Profesional);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Especialidad";
            // 
            // seleccionarProfesionalBindingSource
            // 
            this.seleccionarProfesionalBindingSource.DataSource = typeof(ClinicaFrba.Abm_Profesional.SeleccionarProfesional);
            // 
            // SeleccionarProfesionalPorEspecialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 473);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_especialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.dgv_profesional);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SeleccionarProfesionalPorEspecialidad";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.SeleccionarProfesional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_profesional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesionalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seleccionarProfesionalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource profesionalBindingSource;
        private System.Windows.Forms.BindingSource seleccionarProfesionalBindingSource;
        private System.Windows.Forms.DataGridView dgv_profesional;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_especialidad;
        private System.Windows.Forms.BindingSource especialidadesBindingSource;
        private System.Windows.Forms.Label label2;
    }
}