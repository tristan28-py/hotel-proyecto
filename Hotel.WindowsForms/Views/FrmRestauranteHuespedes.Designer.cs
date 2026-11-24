namespace Hotel.WindowsForms.Views
{
    partial class FrmRestauranteHuespedes
    {
        private System.ComponentModel.IContainer components = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            pnlFiltro = new Panel();
            cboCategoria = new ComboBox();
            lblCategoria = new Label();
            flpMenu = new FlowLayoutPanel();
            pnlPedido = new Panel();
            btnEnviarPedido = new Button();
            btnLimpiarCarrito = new Button();
            lblTotalPedido = new Label();
            dgvCarrito = new DataGridView();
            txtInstrucciones = new TextBox();
            txtMesa = new TextBox();
            rdoMesa = new RadioButton();
            rdoRoomService = new RadioButton();
            cboEstadiaActiva = new ComboBox();
            lblHuesped = new Label();
            pnlComandas = new Panel();
            dgvComandas = new DataGridView();
            btnCancelarCmd = new Button();
            btnEntregado = new Button();
            btnCamino = new Button();
            btnCocina = new Button();
            lblComandas = new Label();
            pnlFiltro.SuspendLayout();
            pnlPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            pnlComandas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComandas).BeginInit();
            SuspendLayout();
            // 
            // pnlFiltro
            // 
            pnlFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltro.BackColor = Color.White;
            pnlFiltro.Controls.Add(cboCategoria);
            pnlFiltro.Controls.Add(lblCategoria);
            pnlFiltro.Location = new Point(12, 12);
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.Size = new Size(560, 44);
            pnlFiltro.TabIndex = 0;
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(92, 10);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(220, 23);
            cboCategoria.TabIndex = 1;
            cboCategoria.SelectedIndexChanged += cboCategoria_SelectedIndexChanged;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategoria.Location = new Point(12, 13);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(71, 17);
            lblCategoria.TabIndex = 0;
            lblCategoria.Text = "Categoria:";
            // 
            // flpMenu
            // 
            flpMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpMenu.AutoScroll = true;
            flpMenu.BackColor = Color.FromArgb(243, 246, 250);
            flpMenu.Location = new Point(12, 64);
            flpMenu.Name = "flpMenu";
            flpMenu.Padding = new Padding(4);
            flpMenu.Size = new Size(560, 560);
            flpMenu.TabIndex = 1;
            // 
            // pnlPedido
            // 
            pnlPedido.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPedido.BackColor = Color.White;
            pnlPedido.BorderStyle = BorderStyle.FixedSingle;
            pnlPedido.Controls.Add(btnEnviarPedido);
            pnlPedido.Controls.Add(btnLimpiarCarrito);
            pnlPedido.Controls.Add(lblTotalPedido);
            pnlPedido.Controls.Add(dgvCarrito);
            pnlPedido.Controls.Add(txtInstrucciones);
            pnlPedido.Controls.Add(txtMesa);
            pnlPedido.Controls.Add(rdoMesa);
            pnlPedido.Controls.Add(rdoRoomService);
            pnlPedido.Controls.Add(cboEstadiaActiva);
            pnlPedido.Controls.Add(lblHuesped);
            pnlPedido.Location = new Point(584, 12);
            pnlPedido.Name = "pnlPedido";
            pnlPedido.Size = new Size(428, 340);
            pnlPedido.TabIndex = 2;
            // 
            // btnEnviarPedido
            // 
            btnEnviarPedido.BackColor = Color.FromArgb(22, 163, 74);
            btnEnviarPedido.FlatAppearance.BorderSize = 0;
            btnEnviarPedido.FlatStyle = FlatStyle.Flat;
            btnEnviarPedido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEnviarPedido.ForeColor = Color.White;
            btnEnviarPedido.Location = new Point(242, 294);
            btnEnviarPedido.Name = "btnEnviarPedido";
            btnEnviarPedido.Size = new Size(172, 34);
            btnEnviarPedido.TabIndex = 9;
            btnEnviarPedido.Text = "Cargar a Habitacion";
            btnEnviarPedido.UseVisualStyleBackColor = false;
            btnEnviarPedido.Click += btnEnviarPedido_Click;
            // 
            // btnLimpiarCarrito
            // 
            btnLimpiarCarrito.BackColor = Color.FromArgb(100, 116, 139);
            btnLimpiarCarrito.FlatAppearance.BorderSize = 0;
            btnLimpiarCarrito.FlatStyle = FlatStyle.Flat;
            btnLimpiarCarrito.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarCarrito.ForeColor = Color.White;
            btnLimpiarCarrito.Location = new Point(156, 294);
            btnLimpiarCarrito.Name = "btnLimpiarCarrito";
            btnLimpiarCarrito.Size = new Size(78, 34);
            btnLimpiarCarrito.TabIndex = 8;
            btnLimpiarCarrito.Text = "Vaciar";
            btnLimpiarCarrito.UseVisualStyleBackColor = false;
            btnLimpiarCarrito.Click += btnLimpiarCarrito_Click;
            // 
            // lblTotalPedido
            // 
            lblTotalPedido.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalPedido.Location = new Point(12, 266);
            lblTotalPedido.Name = "lblTotalPedido";
            lblTotalPedido.Size = new Size(402, 22);
            lblTotalPedido.TabIndex = 7;
            lblTotalPedido.Text = "Total: $0.00";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(12, 128);
            dgvCarrito.MultiSelect = false;
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(402, 130);
            dgvCarrito.TabIndex = 6;
            // 
            // txtInstrucciones
            // 
            txtInstrucciones.Location = new Point(12, 98);
            txtInstrucciones.Name = "txtInstrucciones";
            txtInstrucciones.PlaceholderText = "Instrucciones especiales para cocina";
            txtInstrucciones.Size = new Size(402, 23);
            txtInstrucciones.TabIndex = 5;
            // 
            // txtMesa
            // 
            txtMesa.Enabled = false;
            txtMesa.Location = new Point(314, 67);
            txtMesa.Name = "txtMesa";
            txtMesa.PlaceholderText = "Mesa #";
            txtMesa.Size = new Size(100, 23);
            txtMesa.TabIndex = 4;
            // 
            // rdoMesa
            // 
            rdoMesa.AutoSize = true;
            rdoMesa.Location = new Point(206, 68);
            rdoMesa.Name = "rdoMesa";
            rdoMesa.Size = new Size(92, 19);
            rdoMesa.TabIndex = 3;
            rdoMesa.Text = "Mesa Salon";
            rdoMesa.UseVisualStyleBackColor = true;
            // 
            // rdoRoomService
            // 
            rdoRoomService.AutoSize = true;
            rdoRoomService.Checked = true;
            rdoRoomService.Location = new Point(12, 68);
            rdoRoomService.Name = "rdoRoomService";
            rdoRoomService.Size = new Size(146, 19);
            rdoRoomService.TabIndex = 2;
            rdoRoomService.TabStop = true;
            rdoRoomService.Text = "Room Service (+10%)";
            rdoRoomService.UseVisualStyleBackColor = true;
            rdoRoomService.CheckedChanged += rdoRoomService_CheckedChanged;
            // 
            // cboEstadiaActiva
            // 
            cboEstadiaActiva.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadiaActiva.FormattingEnabled = true;
            cboEstadiaActiva.Location = new Point(12, 36);
            cboEstadiaActiva.Name = "cboEstadiaActiva";
            cboEstadiaActiva.Size = new Size(402, 23);
            cboEstadiaActiva.TabIndex = 1;
            // 
            // lblHuesped
            // 
            lblHuesped.AutoSize = true;
            lblHuesped.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblHuesped.Location = new Point(12, 12);
            lblHuesped.Name = "lblHuesped";
            lblHuesped.Size = new Size(256, 17);
            lblHuesped.TabIndex = 0;
            lblHuesped.Text = "Huesped con Estadia Activa (EnCurso):";
            // 
            // pnlComandas
            // 
            pnlComandas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlComandas.BackColor = Color.White;
            pnlComandas.BorderStyle = BorderStyle.FixedSingle;
            pnlComandas.Controls.Add(dgvComandas);
            pnlComandas.Controls.Add(btnCancelarCmd);
            pnlComandas.Controls.Add(btnEntregado);
            pnlComandas.Controls.Add(btnCamino);
            pnlComandas.Controls.Add(btnCocina);
            pnlComandas.Controls.Add(lblComandas);
            pnlComandas.Location = new Point(584, 362);
            pnlComandas.Name = "pnlComandas";
            pnlComandas.Size = new Size(428, 262);
            pnlComandas.TabIndex = 3;
            // 
            // dgvComandas
            // 
            dgvComandas.AllowUserToAddRows = false;
            dgvComandas.AllowUserToDeleteRows = false;
            dgvComandas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvComandas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComandas.BackgroundColor = Color.White;
            dgvComandas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComandas.Location = new Point(10, 66);
            dgvComandas.MultiSelect = false;
            dgvComandas.Name = "dgvComandas";
            dgvComandas.ReadOnly = true;
            dgvComandas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComandas.Size = new Size(406, 184);
            dgvComandas.TabIndex = 5;
            // 
            // btnCancelarCmd
            // 
            btnCancelarCmd.BackColor = Color.FromArgb(220, 38, 38);
            btnCancelarCmd.FlatAppearance.BorderSize = 0;
            btnCancelarCmd.FlatStyle = FlatStyle.Flat;
            btnCancelarCmd.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCancelarCmd.ForeColor = Color.White;
            btnCancelarCmd.Location = new Point(332, 32);
            btnCancelarCmd.Name = "btnCancelarCmd";
            btnCancelarCmd.Size = new Size(84, 28);
            btnCancelarCmd.TabIndex = 4;
            btnCancelarCmd.Text = "Cancelar";
            btnCancelarCmd.UseVisualStyleBackColor = false;
            btnCancelarCmd.Click += btnCancelarCmd_Click;
            // 
            // btnEntregado
            // 
            btnEntregado.BackColor = Color.FromArgb(22, 163, 74);
            btnEntregado.FlatAppearance.BorderSize = 0;
            btnEntregado.FlatStyle = FlatStyle.Flat;
            btnEntregado.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnEntregado.ForeColor = Color.White;
            btnEntregado.Location = new Point(222, 32);
            btnEntregado.Name = "btnEntregado";
            btnEntregado.Size = new Size(102, 28);
            btnEntregado.TabIndex = 3;
            btnEntregado.Text = "Entregado";
            btnEntregado.UseVisualStyleBackColor = false;
            btnEntregado.Click += btnEntregado_Click;
            // 
            // btnCamino
            // 
            btnCamino.BackColor = Color.FromArgb(37, 99, 235);
            btnCamino.FlatAppearance.BorderSize = 0;
            btnCamino.FlatStyle = FlatStyle.Flat;
            btnCamino.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCamino.ForeColor = Color.White;
            btnCamino.Location = new Point(116, 32);
            btnCamino.Name = "btnCamino";
            btnCamino.Size = new Size(98, 28);
            btnCamino.TabIndex = 2;
            btnCamino.Text = "EnCamino";
            btnCamino.UseVisualStyleBackColor = false;
            btnCamino.Click += btnCamino_Click;
            // 
            // btnCocina
            // 
            btnCocina.BackColor = Color.FromArgb(234, 179, 8);
            btnCocina.FlatAppearance.BorderSize = 0;
            btnCocina.FlatStyle = FlatStyle.Flat;
            btnCocina.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCocina.ForeColor = Color.Black;
            btnCocina.Location = new Point(10, 32);
            btnCocina.Name = "btnCocina";
            btnCocina.Size = new Size(98, 28);
            btnCocina.TabIndex = 1;
            btnCocina.Text = "EnCocina";
            btnCocina.UseVisualStyleBackColor = false;
            btnCocina.Click += btnCocina_Click;
            // 
            // lblComandas
            // 
            lblComandas.AutoSize = true;
            lblComandas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblComandas.Location = new Point(10, 8);
            lblComandas.Name = "lblComandas";
            lblComandas.Size = new Size(188, 17);
            lblComandas.TabIndex = 0;
            lblComandas.Text = "Control de Comandas en Vivo";
            // 
            // FrmRestauranteHuespedes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(pnlComandas);
            Controls.Add(pnlPedido);
            Controls.Add(flpMenu);
            Controls.Add(pnlFiltro);
            Name = "FrmRestauranteHuespedes";
            Text = "Restaurante, Room Service y Comandas";
            FormClosed += FrmRestauranteHuespedes_FormClosed;
            Load += FrmRestauranteHuespedes_Load;
            pnlFiltro.ResumeLayout(false);
            pnlFiltro.PerformLayout();
            pnlPedido.ResumeLayout(false);
            pnlPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            pnlComandas.ResumeLayout(false);
            pnlComandas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComandas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFiltro;
        private ComboBox cboCategoria;
        private Label lblCategoria;
        private FlowLayoutPanel flpMenu;
        private Panel pnlPedido;
        private Button btnEnviarPedido;
        private Button btnLimpiarCarrito;
        private Label lblTotalPedido;
        private DataGridView dgvCarrito;
        private TextBox txtInstrucciones;
        private TextBox txtMesa;
        private RadioButton rdoMesa;
        private RadioButton rdoRoomService;
        private ComboBox cboEstadiaActiva;
        private Label lblHuesped;
        private Panel pnlComandas;
        private DataGridView dgvComandas;
        private Button btnCancelarCmd;
        private Button btnEntregado;
        private Button btnCamino;
        private Button btnCocina;
        private Label lblComandas;
    }
}
