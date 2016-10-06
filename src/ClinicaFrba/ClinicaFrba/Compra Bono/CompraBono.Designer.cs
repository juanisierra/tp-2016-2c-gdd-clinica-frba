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
            this.txtCantCompra = new System.Windows.Forms.TextBox();
            this.lblCantidadCompra = new System.Windows.Forms.Label();
            this.lblFiltroId = new System.Windows.Forms.Label();
            this.blFiltroNroDoc = new System.Windows.Forms.Label();
            this.txtFiltroId = new System.Windows.Forms.TextBox();
            this.txtFiltroDoc = new System.Windows.Forms.TextBox();
            this.txtFiltroApellido = new System.Windows.Forms.TextBox();
            this.lblFiltroApellido = new System.Windows.Forms.Label();
            this.lblFiltroPlan = new System.Windows.Forms.Label();
            this.txtFiltroPlan = new System.Windows.Forms.TextBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.chkFiltro = new System.Windows.Forms.CheckBox();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblInfoPrecio = new System.Windows.Forms.Label();
            this.lblPrecioF = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAfiliados)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAfiliado
            // 
            this.txtAfiliado.Enabled = false;
            this.txtAfiliado.Location = new System.Drawing.Point(20, 48);
            this.txtAfiliado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAfiliado.Name = "txtAfiliado";
            this.txtAfiliado.Size = new System.Drawing.Size(132, 22);
            this.txtAfiliado.TabIndex = 0;
            // 
            // lblAfiliado
            // 
            this.lblAfiliado.AutoSize = true;
            this.lblAfiliado.Location = new System.Drawing.Point(21, 28);
            this.lblAfiliado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAfiliado.Name = "lblAfiliado";
            this.lblAfiliado.Size = new System.Drawing.Size(85, 17);
            this.lblAfiliado.TabIndex = 1;
            this.lblAfiliado.Text = "Nro. Afiliado";
            // 
            // txtPlan
            // 
            this.txtPlan.Enabled = false;
            this.txtPlan.Location = new System.Drawing.Point(199, 48);
            this.txtPlan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(132, 22);
            this.txtPlan.TabIndex = 2;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(199, 28);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(36, 17);
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
            this.groupBox1.Location = new System.Drawing.Point(21, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(524, 202);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Afiliado";
            // 
            // lblPrecioU
            // 
            this.lblPrecioU.AutoSize = true;
            this.lblPrecioU.Location = new System.Drawing.Point(380, 87);
            this.lblPrecioU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioU.Name = "lblPrecioU";
            this.lblPrecioU.Size = new System.Drawing.Size(101, 17);
            this.lblPrecioU.TabIndex = 15;
            this.lblPrecioU.Text = "Precio Unitario";
            // 
            // txtPrecioU
            // 
            this.txtPrecioU.Enabled = false;
            this.txtPrecioU.Location = new System.Drawing.Point(376, 108);
            this.txtPrecioU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecioU.Name = "txtPrecioU";
            this.txtPrecioU.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrecioU.Size = new System.Drawing.Size(132, 22);
            this.txtPrecioU.TabIndex = 14;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(376, 48);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(132, 22);
            this.txtCantidad.TabIndex = 12;
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(376, 28);
            this.lblBono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(118, 17);
            this.lblBono.TabIndex = 13;
            this.lblBono.Text = "Bonos adquiridos";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Enabled = false;
            this.txtNroDoc.Location = new System.Drawing.Point(199, 170);
            this.txtNroDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(132, 22);
            this.txtNroDoc.TabIndex = 10;
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(200, 150);
            this.lblNroDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(111, 17);
            this.lblNroDoc.TabIndex = 11;
            this.lblNroDoc.Text = "Nro. Documento";
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Enabled = false;
            this.txtTipoDoc.Location = new System.Drawing.Point(20, 170);
            this.txtTipoDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(132, 22);
            this.txtTipoDoc.TabIndex = 8;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(21, 150);
            this.lblTipoDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(112, 17);
            this.lblTipoDoc.TabIndex = 9;
            this.lblTipoDoc.Text = "Tipo Documento";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(199, 108);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(132, 22);
            this.txtApellido.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(200, 89);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(20, 108);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 22);
            this.txtNombre.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 89);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
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
            this.dtgAfiliados.Location = new System.Drawing.Point(21, 436);
            this.dtgAfiliados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgAfiliados.Name = "dtgAfiliados";
            this.dtgAfiliados.ReadOnly = true;
            this.dtgAfiliados.RowHeadersVisible = false;
            this.dtgAfiliados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAfiliados.Size = new System.Drawing.Size(695, 369);
            this.dtgAfiliados.TabIndex = 5;
            this.dtgAfiliados.SelectionChanged += new System.EventHandler(this.dtgAfiliados_SelectionChanged);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(588, 105);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(119, 59);
            this.btnComprar.TabIndex = 6;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // txtCantCompra
            // 
            this.txtCantCompra.Location = new System.Drawing.Point(588, 63);
            this.txtCantCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantCompra.Name = "txtCantCompra";
            this.txtCantCompra.Size = new System.Drawing.Size(117, 22);
            this.txtCantCompra.TabIndex = 7;
            // 
            // lblCantidadCompra
            // 
            this.lblCantidadCompra.AutoSize = true;
            this.lblCantidadCompra.Location = new System.Drawing.Point(584, 43);
            this.lblCantidadCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadCompra.Name = "lblCantidadCompra";
            this.lblCantidadCompra.Size = new System.Drawing.Size(132, 17);
            this.lblCantidadCompra.TabIndex = 8;
            this.lblCantidadCompra.Text = "Cantidad a comprar";
            // 
            // lblFiltroId
            // 
            this.lblFiltroId.AutoSize = true;
            this.lblFiltroId.Location = new System.Drawing.Point(25, 30);
            this.lblFiltroId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroId.Name = "lblFiltroId";
            this.lblFiltroId.Size = new System.Drawing.Size(85, 17);
            this.lblFiltroId.TabIndex = 9;
            this.lblFiltroId.Text = "Nro. Afiliado";
            // 
            // blFiltroNroDoc
            // 
            this.blFiltroNroDoc.AutoSize = true;
            this.blFiltroNroDoc.Location = new System.Drawing.Point(200, 30);
            this.blFiltroNroDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blFiltroNroDoc.Name = "blFiltroNroDoc";
            this.blFiltroNroDoc.Size = new System.Drawing.Size(111, 17);
            this.blFiltroNroDoc.TabIndex = 10;
            this.blFiltroNroDoc.Text = "Nro. Documento";
            // 
            // txtFiltroId
            // 
            this.txtFiltroId.Location = new System.Drawing.Point(20, 50);
            this.txtFiltroId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroId.Name = "txtFiltroId";
            this.txtFiltroId.Size = new System.Drawing.Size(132, 22);
            this.txtFiltroId.TabIndex = 11;
            // 
            // txtFiltroDoc
            // 
            this.txtFiltroDoc.Location = new System.Drawing.Point(199, 50);
            this.txtFiltroDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroDoc.Name = "txtFiltroDoc";
            this.txtFiltroDoc.Size = new System.Drawing.Size(132, 22);
            this.txtFiltroDoc.TabIndex = 12;
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(199, 116);
            this.txtFiltroApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(132, 22);
            this.txtFiltroApellido.TabIndex = 13;
            // 
            // lblFiltroApellido
            // 
            this.lblFiltroApellido.AutoSize = true;
            this.lblFiltroApellido.Location = new System.Drawing.Point(199, 95);
            this.lblFiltroApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroApellido.Name = "lblFiltroApellido";
            this.lblFiltroApellido.Size = new System.Drawing.Size(58, 17);
            this.lblFiltroApellido.TabIndex = 14;
            this.lblFiltroApellido.Text = "Apellido";
            // 
            // lblFiltroPlan
            // 
            this.lblFiltroPlan.AutoSize = true;
            this.lblFiltroPlan.Location = new System.Drawing.Point(372, 31);
            this.lblFiltroPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroPlan.Name = "lblFiltroPlan";
            this.lblFiltroPlan.Size = new System.Drawing.Size(36, 17);
            this.lblFiltroPlan.TabIndex = 15;
            this.lblFiltroPlan.Text = "Plan";
            // 
            // txtFiltroPlan
            // 
            this.txtFiltroPlan.Location = new System.Drawing.Point(376, 50);
            this.txtFiltroPlan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroPlan.Name = "txtFiltroPlan";
            this.txtFiltroPlan.Size = new System.Drawing.Size(132, 22);
            this.txtFiltroPlan.TabIndex = 16;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.chkFiltro);
            this.gbFiltros.Controls.Add(this.txtFiltroNombre);
            this.gbFiltros.Controls.Add(this.lblFiltroNombre);
            this.gbFiltros.Controls.Add(this.btnFiltrar);
            this.gbFiltros.Controls.Add(this.txtFiltroPlan);
            this.gbFiltros.Controls.Add(this.lblFiltroId);
            this.gbFiltros.Controls.Add(this.lblFiltroPlan);
            this.gbFiltros.Controls.Add(this.blFiltroNroDoc);
            this.gbFiltros.Controls.Add(this.lblFiltroApellido);
            this.gbFiltros.Controls.Add(this.txtFiltroId);
            this.gbFiltros.Controls.Add(this.txtFiltroApellido);
            this.gbFiltros.Controls.Add(this.txtFiltroDoc);
            this.gbFiltros.Location = new System.Drawing.Point(21, 239);
            this.gbFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFiltros.Size = new System.Drawing.Size(695, 175);
            this.gbFiltros.TabIndex = 17;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // chkFiltro
            // 
            this.chkFiltro.AutoSize = true;
            this.chkFiltro.Location = new System.Drawing.Point(548, 54);
            this.chkFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFiltro.Name = "chkFiltro";
            this.chkFiltro.Size = new System.Drawing.Size(135, 21);
            this.chkFiltro.TabIndex = 22;
            this.chkFiltro.Text = "Filtrado absoluto";
            this.chkFiltro.UseVisualStyleBackColor = true;
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(20, 116);
            this.txtFiltroNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(132, 22);
            this.txtFiltroNombre.TabIndex = 21;
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Location = new System.Drawing.Point(16, 96);
            this.lblFiltroNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(58, 17);
            this.lblFiltroNombre.TabIndex = 20;
            this.lblFiltroNombre.Text = "Nombre";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(548, 102);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(137, 38);
            this.btnFiltrar.TabIndex = 17;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblInfoPrecio
            // 
            this.lblInfoPrecio.AutoSize = true;
            this.lblInfoPrecio.Location = new System.Drawing.Point(584, 185);
            this.lblInfoPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoPrecio.Name = "lblInfoPrecio";
            this.lblInfoPrecio.Size = new System.Drawing.Size(98, 17);
            this.lblInfoPrecio.TabIndex = 18;
            this.lblInfoPrecio.Text = "Precio Final: $";
            // 
            // lblPrecioF
            // 
            this.lblPrecioF.AutoSize = true;
            this.lblPrecioF.Location = new System.Drawing.Point(683, 185);
            this.lblPrecioF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioF.Name = "lblPrecioF";
            this.lblPrecioF.Size = new System.Drawing.Size(0, 17);
            this.lblPrecioF.TabIndex = 19;
            // 
            // CompraBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 820);
            this.Controls.Add(this.lblPrecioF);
            this.Controls.Add(this.lblInfoPrecio);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.txtCantCompra);
            this.Controls.Add(this.lblCantidadCompra);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dtgAfiliados);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CompraBonos";
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
        private System.Windows.Forms.TextBox txtCantCompra;
        private System.Windows.Forms.Label lblCantidadCompra;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.Label lblFiltroId;
        private System.Windows.Forms.Label blFiltroNroDoc;
        private System.Windows.Forms.TextBox txtFiltroId;
        private System.Windows.Forms.TextBox txtFiltroDoc;
        private System.Windows.Forms.TextBox txtFiltroApellido;
        private System.Windows.Forms.Label lblFiltroApellido;
        private System.Windows.Forms.Label lblFiltroPlan;
        private System.Windows.Forms.TextBox txtFiltroPlan;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.CheckBox chkFiltro;
        private System.Windows.Forms.Label lblPrecioU;
        private System.Windows.Forms.TextBox txtPrecioU;
        private System.Windows.Forms.Label lblInfoPrecio;
        private System.Windows.Forms.Label lblPrecioF;
    }
}