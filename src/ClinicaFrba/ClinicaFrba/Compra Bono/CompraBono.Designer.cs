namespace ClinicaFrba.Compra_Bono
{
    partial class CompraBonos
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
            this.txtAfiliado = new System.Windows.Forms.TextBox();
            this.lblAfiliado = new System.Windows.Forms.Label();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPrecioU = new System.Windows.Forms.Label();
            this.txtPrecioU = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblBono = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtgAfiliados = new System.Windows.Forms.DataGridView();
            this.btnComprar = new System.Windows.Forms.Button();
            this.lblCantidadCompra = new System.Windows.Forms.Label();
            this.lblFiltroId = new System.Windows.Forms.Label();
            this.blFiltroNroDoc = new System.Windows.Forms.Label();
            this.lblFiltroApellido = new System.Windows.Forms.Label();
            this.lblFiltroPlan = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.txtFiltroPlan = new System.Windows.Forms.TextBox();
            this.txtFiltroDoc = new System.Windows.Forms.MaskedTextBox();
            this.txtFiltroId = new System.Windows.Forms.MaskedTextBox();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltroApellido = new System.Windows.Forms.TextBox();
            this.lblInfoPrecio = new System.Windows.Forms.Label();
            this.lblPrecioF = new System.Windows.Forms.Label();
            this.txtCantCompra = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAfiliados)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAfiliado
            // 
            this.txtAfiliado.Enabled = false;
            this.txtAfiliado.Location = new System.Drawing.Point(15, 39);
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.Size = new System.Drawing.Size(100, 20);
            this.txtAfiliado.TabIndex = 0;
            // 
            // lblAfiliado
            // 
            this.lblAfiliado.AutoSize = true;
            this.lblAfiliado.Location = new System.Drawing.Point(16, 23);
            this.lblAfiliado.Name = "lblAfiliado";
            this.lblAfiliado.Size = new System.Drawing.Size(64, 13);
            this.lblAfiliado.TabIndex = 1;
            this.lblAfiliado.Text = "Nro. Afiliado";
            // 
            // txtPlan
            // 
            this.txtPlan.Enabled = false;
            this.txtPlan.Location = new System.Drawing.Point(149, 39);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(100, 20);
            this.txtPlan.TabIndex = 2;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(149, 23);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 3;
            this.lblPlan.Text = "Plan";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPrecioU);
            this.groupBox1.Controls.Add(this.txtPrecioU);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.lblBono);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.lblNroDoc);
            this.groupBox1.Controls.Add(this.txtTipoDoc);
            this.groupBox1.Controls.Add(this.lblTipoDoc);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.txtPlan);
            this.groupBox1.Controls.Add(this.lblPlan);
            this.groupBox1.Controls.Add(this.lblApellido);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtAfiliado);
            this.groupBox1.Controls.Add(this.lblAfiliado);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 164);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Afiliado";
            // 
            // lblPrecioU
            // 
            this.lblPrecioU.AutoSize = true;
            this.lblPrecioU.Location = new System.Drawing.Point(285, 71);
            this.lblPrecioU.Name = "lblPrecioU";
            this.lblPrecioU.Size = new System.Drawing.Size(76, 13);
            this.lblPrecioU.TabIndex = 15;
            this.lblPrecioU.Text = "Precio Unitario";
            // 
            // txtPrecioU
            // 
            this.txtPrecioU.Enabled = false;
            this.txtPrecioU.Location = new System.Drawing.Point(282, 88);
            this.txtPrecioU.Name = "txtPrecioU";
            this.txtPrecioU.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrecioU.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioU.TabIndex = 14;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(282, 39);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 12;
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(282, 23);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(88, 13);
            this.lblBono.TabIndex = 13;
            this.lblBono.Text = "Bonos adquiridos";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(149, 138);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(100, 20);
            this.txtNroDoc.TabIndex = 10;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(150, 122);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(85, 13);
            this.lblNroDoc.TabIndex = 11;
            this.lblNroDoc.Text = "Nro. Documento";
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Enabled = false;
            this.txtTipoDoc.Location = new System.Drawing.Point(15, 138);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(100, 20);
            this.txtTipoDoc.TabIndex = 8;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(16, 122);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(86, 13);
            this.lblTipoDoc.TabIndex = 9;
            this.lblTipoDoc.Text = "Tipo Documento";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(149, 88);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(150, 72);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(15, 88);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(16, 72);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre";
            // 
            // dtgAfiliados
            // 
            this.dtgAfiliados.AllowUserToAddRows = false;
            this.dtgAfiliados.AllowUserToDeleteRows = false;
            this.dtgAfiliados.AllowUserToResizeRows = false;
            this.dtgAfiliados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAfiliados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgAfiliados.Location = new System.Drawing.Point(16, 354);
            this.dtgAfiliados.Name = "dtgAfiliados";
            this.dtgAfiliados.ReadOnly = true;
            this.dtgAfiliados.RowHeadersVisible = false;
            this.dtgAfiliados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAfiliados.Size = new System.Drawing.Size(521, 300);
            this.dtgAfiliados.TabIndex = 5;
            this.dtgAfiliados.SelectionChanged += new System.EventHandler(this.dtgAfiliados_SelectionChanged);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(441, 85);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(89, 48);
            this.btnComprar.TabIndex = 6;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // lblCantidadCompra
            // 
            this.lblCantidadCompra.AutoSize = true;
            this.lblCantidadCompra.Location = new System.Drawing.Point(438, 35);
            this.lblCantidadCompra.Name = "lblCantidadCompra";
            this.lblCantidadCompra.Size = new System.Drawing.Size(99, 13);
            this.lblCantidadCompra.TabIndex = 8;
            this.lblCantidadCompra.Text = "Cantidad a comprar";
            // 
            // lblFiltroId
            // 
            this.lblFiltroId.AutoSize = true;
            this.lblFiltroId.Location = new System.Drawing.Point(19, 24);
            this.lblFiltroId.Name = "lblFiltroId";
            this.lblFiltroId.Size = new System.Drawing.Size(64, 13);
            this.lblFiltroId.TabIndex = 9;
            this.lblFiltroId.Text = "Nro. Afiliado";
            // 
            // blFiltroNroDoc
            // 
            this.blFiltroNroDoc.AutoSize = true;
            this.blFiltroNroDoc.Location = new System.Drawing.Point(150, 24);
            this.blFiltroNroDoc.Name = "blFiltroNroDoc";
            this.blFiltroNroDoc.Size = new System.Drawing.Size(85, 13);
            this.blFiltroNroDoc.TabIndex = 10;
            this.blFiltroNroDoc.Text = "Nro. Documento";
            // 
            // lblFiltroApellido
            // 
            this.lblFiltroApellido.AutoSize = true;
            this.lblFiltroApellido.Location = new System.Drawing.Point(149, 77);
            this.lblFiltroApellido.Name = "lblFiltroApellido";
            this.lblFiltroApellido.Size = new System.Drawing.Size(44, 13);
            this.lblFiltroApellido.TabIndex = 14;
            this.lblFiltroApellido.Text = "Apellido";
            // 
            // lblFiltroPlan
            // 
            this.lblFiltroPlan.AutoSize = true;
            this.lblFiltroPlan.Location = new System.Drawing.Point(285, 26);
            this.lblFiltroPlan.Name = "lblFiltroPlan";
            this.lblFiltroPlan.Size = new System.Drawing.Size(28, 13);
            this.lblFiltroPlan.TabIndex = 15;
            this.lblFiltroPlan.Text = "Plan";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.txtFiltroPlan);
            this.gbFiltros.Controls.Add(this.txtFiltroDoc);
            this.gbFiltros.Controls.Add(this.txtFiltroId);
            this.gbFiltros.Controls.Add(this.chkFiltro);
            this.gbFiltros.Controls.Add(this.txtFiltroNombre);
            this.gbFiltros.Controls.Add(this.lblFiltroNombre);
            this.gbFiltros.Controls.Add(this.btnFiltrar);
            this.gbFiltros.Controls.Add(this.lblFiltroId);
            this.gbFiltros.Controls.Add(this.lblFiltroPlan);
            this.gbFiltros.Controls.Add(this.blFiltroNroDoc);
            this.gbFiltros.Controls.Add(this.lblFiltroApellido);
            this.gbFiltros.Controls.Add(this.txtFiltroApellido);
            this.gbFiltros.Location = new System.Drawing.Point(16, 194);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(521, 142);
            this.gbFiltros.TabIndex = 17;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // txtFiltroPlan
            // 
            this.txtFiltroPlan.Location = new System.Drawing.Point(282, 42);
            this.txtFiltroPlan.Name = "txtFiltroPlan";
            this.txtFiltroPlan.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroPlan.TabIndex = 26;
            // 
            // txtFiltroDoc
            // 
            this.txtFiltroDoc.Location = new System.Drawing.Point(149, 42);
            this.txtFiltroDoc.Mask = "9999999999";
            this.txtFiltroDoc.Name = "txtFiltroDoc";
            this.txtFiltroDoc.PromptChar = ' ';
            this.txtFiltroDoc.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroDoc.TabIndex = 24;
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.HideSelection = false;
            this.txtFiltroId.Location = new System.Drawing.Point(15, 42);
            this.txtFiltroId.Mask = "99999999999999999999";
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.PromptChar = ' ';
            this.txtFiltroId.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroId.TabIndex = 23;
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.Location = new System.Drawing.Point(411, 44);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(103, 17);
            this.chkFiltro.TabIndex = 22;
            this.chkFiltro.Text = "Filtrado absoluto";
            this.chkFiltro.UseVisualStyleBackColor = true;
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(15, 94);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroNombre.TabIndex = 21;
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Location = new System.Drawing.Point(12, 78);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(44, 13);
            this.lblFiltroNombre.TabIndex = 20;
            this.lblFiltroNombre.Text = "Nombre";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(411, 83);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(103, 31);
            this.btnFiltrar.TabIndex = 17;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(149, 94);
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(100, 20);
            this.txtFiltroApellido.TabIndex = 13;
            // 
            // lblInfoPrecio
            // 
            this.lblInfoPrecio.AutoSize = true;
            this.lblInfoPrecio.Location = new System.Drawing.Point(438, 150);
            this.lblInfoPrecio.Name = "lblInfoPrecio";
            this.lblInfoPrecio.Size = new System.Drawing.Size(74, 13);
            this.lblInfoPrecio.TabIndex = 18;
            this.lblInfoPrecio.Text = "Precio Final: $";
            // 
            // lblPrecioF
            // 
            this.lblPrecioF.AutoSize = true;
            this.lblPrecioF.Location = new System.Drawing.Point(512, 150);
            this.lblPrecioF.Name = "lblPrecioF";
            this.lblPrecioF.Size = new System.Drawing.Size(0, 13);
            this.lblPrecioF.TabIndex = 19;
            // 
            // txtCantCompra
            // 
            this.txtCantCompra.Location = new System.Drawing.Point(441, 51);
            this.txtCantCompra.Mask = "99999";
            this.txtCantCompra.Name = "txtCantCompra";
            this.txtCantCompra.PromptChar = ' ';
            this.txtCantCompra.Size = new System.Drawing.Size(89, 20);
            this.txtCantCompra.TabIndex = 20;
            this.txtCantCompra.TextChanged += new System.EventHandler(this.txtCantCompra_TextChanged);
            // 
            // CompraBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 666);
            this.Controls.Add(this.txtCantCompra);
            this.Controls.Add(this.lblPrecioF);
            this.Controls.Add(this.lblInfoPrecio);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.lblCantidadCompra);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dtgAfiliados);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CompraBonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra de Bonos";
            this.Load += new System.EventHandler(this.CompraBonos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAfiliados)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAfiliado;
        private System.Windows.Forms.Label lblAfiliado;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgAfiliados;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.TextBox txtTipoDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCantidadCompra;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.Label lblFiltroId;
        private System.Windows.Forms.Label blFiltroNroDoc;
        private System.Windows.Forms.Label lblFiltroApellido;
        private System.Windows.Forms.Label lblFiltroPlan;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.CheckBox chkFiltro;
        private System.Windows.Forms.Label lblPrecioU;
        private System.Windows.Forms.TextBox txtPrecioU;
        private System.Windows.Forms.Label lblInfoPrecio;
        private System.Windows.Forms.Label lblPrecioF;
        private System.Windows.Forms.MaskedTextBox txtFiltroDoc;
        private System.Windows.Forms.MaskedTextBox txtFiltroId;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.TextBox txtFiltroApellido;
        private System.Windows.Forms.TextBox txtFiltroPlan;
        private System.Windows.Forms.MaskedTextBox txtCantCompra;
    }
}