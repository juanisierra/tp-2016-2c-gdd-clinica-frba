﻿namespace ClinicaFrba.Listados
{
    partial class ListadoCancelaciones
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
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listaFun = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_cancelaciones = new System.Windows.Forms.ComboBox();
            this.cb_anio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_semestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_mes = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaFun)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(516, 95);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(83, 31);
            this.btn_aceptar.TabIndex = 6;
            this.btn_aceptar.Text = "Filtrar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listaFun);
            this.groupBox1.Location = new System.Drawing.Point(21, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 223);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado";
            // 
            // listaFun
            // 
            this.listaFun.AllowUserToAddRows = false;
            this.listaFun.AllowUserToDeleteRows = false;
            this.listaFun.AllowUserToResizeRows = false;
            this.listaFun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaFun.Location = new System.Drawing.Point(10, 23);
            this.listaFun.MultiSelect = false;
            this.listaFun.Name = "listaFun";
            this.listaFun.ReadOnly = true;
            this.listaFun.RowHeadersVisible = false;
            this.listaFun.RowTemplate.Height = 24;
            this.listaFun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaFun.Size = new System.Drawing.Size(579, 194);
            this.listaFun.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cancelaciones:";
            // 
            // cb_cancelaciones
            // 
            this.cb_cancelaciones.FormattingEnabled = true;
            this.cb_cancelaciones.Location = new System.Drawing.Point(138, 20);
            this.cb_cancelaciones.Name = "cb_cancelaciones";
            this.cb_cancelaciones.Size = new System.Drawing.Size(182, 24);
            this.cb_cancelaciones.TabIndex = 7;
            // 
            // cb_anio
            // 
            this.cb_anio.FormattingEnabled = true;
            this.cb_anio.Location = new System.Drawing.Point(73, 57);
            this.cb_anio.Name = "cb_anio";
            this.cb_anio.Size = new System.Drawing.Size(121, 24);
            this.cb_anio.TabIndex = 9;
            this.cb_anio.SelectedIndexChanged += new System.EventHandler(this.cb_anio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Año:";
            // 
            // cb_semestre
            // 
            this.cb_semestre.FormattingEnabled = true;
            this.cb_semestre.Location = new System.Drawing.Point(297, 57);
            this.cb_semestre.Name = "cb_semestre";
            this.cb_semestre.Size = new System.Drawing.Size(121, 24);
            this.cb_semestre.TabIndex = 11;
            this.cb_semestre.SelectedIndexChanged += new System.EventHandler(this.cb_semestre_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Semestre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mes:";
            // 
            // cb_mes
            // 
            this.cb_mes.FormattingEnabled = true;
            this.cb_mes.Location = new System.Drawing.Point(489, 57);
            this.cb_mes.Name = "cb_mes";
            this.cb_mes.Size = new System.Drawing.Size(121, 24);
            this.cb_mes.TabIndex = 19;
            // 
            // ListadoCancelaciones
            // 
            this.AcceptButton = this.btn_aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 393);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_mes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_semestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_anio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_cancelaciones);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoCancelaciones";
            this.Text = "Especialidades con mas Cancelaciones";
            this.Load += new System.EventHandler(this.ListadoCancelaciones_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaFun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView listaFun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_cancelaciones;
        private System.Windows.Forms.ComboBox cb_anio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_semestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_mes;
    }
}