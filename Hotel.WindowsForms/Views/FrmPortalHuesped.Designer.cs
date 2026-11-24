namespace Hotel.WindowsForms.Views
{
    partial class FrmPortalHuesped
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
            tabHuesped = new TabControl();
            tabExplorar = new TabPage();
            pnlReservaResumen = new Panel();
            btnConfirmarReserva = new Button();
            txtObsReserva = new TextBox();
            cboMetodo = new ComboBox();
            lblMetodo = new Label();
            chkPagarAnticipo = new CheckBox();
            lblCotizacionHuesped = new Label();
            lblTituloResumen = new Label();
            flpSuites = new FlowLayoutPanel();
            pnlFiltroFechas = new Panel();
            btnBuscarSuites = new Button();
            numHuespedes = new NumericUpDown();
            lblHuespedes = new Label();
            dtpSalida = new DateTimePicker();
            lblSalida = new Label();
            dtpEntrada = new DateTimePicker();
            lblEntrada = new Label();
            tabMisReservas = new TabPage();
            pnlMiFolio = new Panel();
            dgvMisPagos = new DataGridView();
            lblMiFolio = new Label();
            dgvMisReservas = new DataGridView();
            tabHuesped.SuspendLayout();
            tabExplorar.SuspendLayout();
            pnlReservaResumen.SuspendLayout();
            pnlFiltroFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHuespedes).BeginInit();
            tabMisReservas.SuspendLayout();
            pnlMiFolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMisPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMisReservas).BeginInit();
            SuspendLayout();
            // 
            // tabHuesped
            // 
            tabHuesped.Controls.Add(tabExplorar);
            tabHuesped.Controls.Add(tabMisReservas);
            tabHuesped.Dock = DockStyle.Fill;
            tabHuesped.Font = new Font("Segoe UI", 9.5F);
            tabHuesped.Location = new Point(0, 0);
            tabHuesped.Name = "tabHuesped";
            tabHuesped.SelectedIndex = 0;
            tabHuesped.Size = new Size(1024, 638);
            tabHuesped.TabIndex = 0;
            // 
            // tabExplorar
            // 
            tabExplorar.BackColor = Color.FromArgb(247, 245, 240);
            tabExplorar.Controls.Add(pnlReservaResumen);
            tabExplorar.Controls.Add(flpSuites);
            tabExplorar.Controls.Add(pnlFiltroFechas);
            tabExplorar.Location = new Point(4, 25);
            tabExplorar.Name = "tabExplorar";
            tabExplorar.Padding = new Padding(10);
            tabExplorar.Size = new Size(1016, 609);
            tabExplorar.TabIndex = 0;
            tabExplorar.Text = "Explorar Suites y Reservar";
            // 
            // pnlReservaResumen
            // 
            pnlReservaResumen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlReservaResumen.BackColor = Color.White;
            pnlReservaResumen.BorderStyle = BorderStyle.FixedSingle;
            pnlReservaResumen.Controls.Add(btnConfirmarReserva);
            pnlReservaResumen.Controls.Add(txtObsReserva);
            pnlReservaResumen.Controls.Add(cboMetodo);
            pnlReservaResumen.Controls.Add(lblMetodo);
            pnlReservaResumen.Controls.Add(chkPagarAnticipo);
            pnlReservaResumen.Controls.Add(lblCotizacionHuesped);
            pnlReservaResumen.Controls.Add(lblTituloResumen);
            pnlReservaResumen.Location = new Point(662, 68);
            pnlReservaResumen.Name = "pnlReservaResumen";
            pnlReservaResumen.Size = new Size(342, 530);
            pnlReservaResumen.TabIndex = 2;
            // 
            // btnConfirmarReserva
            // 
            btnConfirmarReserva.BackColor = Color.FromArgb(200, 157, 84);
            btnConfirmarReserva.FlatAppearance.BorderSize = 0;
            btnConfirmarReserva.FlatStyle = FlatStyle.Flat;
            btnConfirmarReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmarReserva.ForeColor = Color.FromArgb(15, 30, 54);
            btnConfirmarReserva.Location = new Point(16, 404);
            btnConfirmarReserva.Name = "btnConfirmarReserva";
            btnConfirmarReserva.Size = new Size(308, 44);
            btnConfirmarReserva.TabIndex = 6;
            btnConfirmarReserva.Text = "Reservar Habitacion Ahora";
            btnConfirmarReserva.UseVisualStyleBackColor = false;
            btnConfirmarReserva.Click += btnConfirmarReserva_Click;
            // 
            // txtObsReserva
            // 
            txtObsReserva.Location = new Point(16, 336);
            txtObsReserva.Multiline = true;
            txtObsReserva.Name = "txtObsReserva";
            txtObsReserva.PlaceholderText = "Preferencias o comentarios de llegada";
            txtObsReserva.Size = new Size(308, 52);
            txtObsReserva.TabIndex = 5;
            // 
            // cboMetodo
            // 
            cboMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodo.FormattingEnabled = true;
            cboMetodo.Items.AddRange(new object[] { "TarjetaCredito", "TarjetaDebito", "TransferenciaBancaria" });
            cboMetodo.Location = new Point(110, 294);
            cboMetodo.Name = "cboMetodo";
            cboMetodo.Size = new Size(214, 24);
            cboMetodo.TabIndex = 4;
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Location = new Point(16, 297);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(86, 17);
            lblMetodo.TabIndex = 3;
            lblMetodo.Text = "Forma pago:";
            // 
            // chkPagarAnticipo
            // 
            chkPagarAnticipo.AutoSize = true;
            chkPagarAnticipo.Checked = true;
            chkPagarAnticipo.CheckState = CheckState.Checked;
            chkPagarAnticipo.Location = new Point(16, 258);
            chkPagarAnticipo.Name = "chkPagarAnticipo";
            chkPagarAnticipo.Size = new Size(258, 21);
            chkPagarAnticipo.TabIndex = 2;
            chkPagarAnticipo.Text = "Pagar anticipo (30%) para confirmar";
            chkPagarAnticipo.UseVisualStyleBackColor = true;
            // 
            // lblCotizacionHuesped
            // 
            lblCotizacionHuesped.BackColor = Color.FromArgb(247, 245, 240);
            lblCotizacionHuesped.BorderStyle = BorderStyle.FixedSingle;
            lblCotizacionHuesped.Font = new Font("Consolas", 9F);
            lblCotizacionHuesped.Location = new Point(16, 54);
            lblCotizacionHuesped.Name = "lblCotizacionHuesped";
            lblCotizacionHuesped.Padding = new Padding(8);
            lblCotizacionHuesped.Size = new Size(308, 190);
            lblCotizacionHuesped.TabIndex = 1;
            lblCotizacionHuesped.Text = "Seleccione una suite del catalogo para ver el desglose de tarifa e impuestos.";
            // 
            // lblTituloResumen
            // 
            lblTituloResumen.AutoSize = true;
            lblTituloResumen.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lblTituloResumen.ForeColor = Color.FromArgb(15, 30, 54);
            lblTituloResumen.Location = new Point(16, 16);
            lblTituloResumen.Name = "lblTituloResumen";
            lblTituloResumen.Size = new Size(197, 19);
            lblTituloResumen.TabIndex = 0;
            lblTituloResumen.Text = "Resumen de tu Estadia";
            // 
            // flpSuites
            // 
            flpSuites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpSuites.AutoScroll = true;
            flpSuites.Location = new Point(10, 68);
            flpSuites.Name = "flpSuites";
            flpSuites.Padding = new Padding(4);
            flpSuites.Size = new Size(642, 530);
            flpSuites.TabIndex = 1;
            // 
            // pnlFiltroFechas
            // 
            pnlFiltroFechas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltroFechas.BackColor = Color.FromArgb(15, 30, 54);
            pnlFiltroFechas.Controls.Add(btnBuscarSuites);
            pnlFiltroFechas.Controls.Add(numHuespedes);
            pnlFiltroFechas.Controls.Add(lblHuespedes);
            pnlFiltroFechas.Controls.Add(dtpSalida);
            pnlFiltroFechas.Controls.Add(lblSalida);
            pnlFiltroFechas.Controls.Add(dtpEntrada);
            pnlFiltroFechas.Controls.Add(lblEntrada);
            pnlFiltroFechas.Location = new Point(10, 10);
            pnlFiltroFechas.Name = "pnlFiltroFechas";
            pnlFiltroFechas.Size = new Size(994, 50);
            pnlFiltroFechas.TabIndex = 0;
            // 
            // btnBuscarSuites
            // 
            btnBuscarSuites.BackColor = Color.FromArgb(200, 157, 84);
            btnBuscarSuites.FlatAppearance.BorderSize = 0;
            btnBuscarSuites.FlatStyle = FlatStyle.Flat;
            btnBuscarSuites.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBuscarSuites.ForeColor = Color.FromArgb(15, 30, 54);
            btnBuscarSuites.Location = new Point(564, 9);
            btnBuscarSuites.Name = "btnBuscarSuites";
            btnBuscarSuites.Size = new Size(184, 32);
            btnBuscarSuites.TabIndex = 6;
            btnBuscarSuites.Text = "Ver Suites Disponibles";
            btnBuscarSuites.UseVisualStyleBackColor = false;
            btnBuscarSuites.Click += btnBuscarSuites_Click;
            // 
            // numHuespedes
            // 
            numHuespedes.Location = new Point(474, 13);
            numHuespedes.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numHuespedes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHuespedes.Name = "numHuespedes";
            numHuespedes.Size = new Size(68, 24);
            numHuespedes.TabIndex = 5;
            numHuespedes.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblHuespedes
            // 
            lblHuespedes.AutoSize = true;
            lblHuespedes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHuespedes.ForeColor = Color.White;
            lblHuespedes.Location = new Point(390, 16);
            lblHuespedes.Name = "lblHuespedes";
            lblHuespedes.Size = new Size(78, 15);
            lblHuespedes.TabIndex = 4;
            lblHuespedes.Text = "Huespedes:";
            // 
            // dtpSalida
            // 
            dtpSalida.Format = DateTimePickerFormat.Short;
            dtpSalida.Location = new Point(260, 13);
            dtpSalida.Name = "dtpSalida";
            dtpSalida.Size = new Size(116, 24);
            dtpSalida.TabIndex = 3;
            // 
            // lblSalida
            // 
            lblSalida.AutoSize = true;
            lblSalida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSalida.ForeColor = Color.White;
            lblSalida.Location = new Point(210, 16);
            lblSalida.Name = "lblSalida";
            lblSalida.Size = new Size(46, 15);
            lblSalida.TabIndex = 2;
            lblSalida.Text = "Salida:";
            // 
            // dtpEntrada
            // 
            dtpEntrada.Format = DateTimePickerFormat.Short;
            dtpEntrada.Location = new Point(80, 13);
            dtpEntrada.Name = "dtpEntrada";
            dtpEntrada.Size = new Size(116, 24);
            dtpEntrada.TabIndex = 1;
            // 
            // lblEntrada
            // 
            lblEntrada.AutoSize = true;
            lblEntrada.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEntrada.ForeColor = Color.White;
            lblEntrada.Location = new Point(16, 16);
            lblEntrada.Name = "lblEntrada";
            lblEntrada.Size = new Size(58, 15);
            lblEntrada.TabIndex = 0;
            lblEntrada.Text = "Entrada:";
            // 
            // tabMisReservas
            // 
            tabMisReservas.BackColor = Color.FromArgb(247, 245, 240);
            tabMisReservas.Controls.Add(pnlMiFolio);
            tabMisReservas.Controls.Add(dgvMisReservas);
            tabMisReservas.Location = new Point(4, 25);
            tabMisReservas.Name = "tabMisReservas";
            tabMisReservas.Padding = new Padding(10);
            tabMisReservas.Size = new Size(1016, 609);
            tabMisReservas.TabIndex = 1;
            tabMisReservas.Text = "Mis Reservaciones y Mi Folio";
            // 
            // pnlMiFolio
            // 
            pnlMiFolio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMiFolio.BackColor = Color.White;
            pnlMiFolio.BorderStyle = BorderStyle.FixedSingle;
            pnlMiFolio.Controls.Add(dgvMisPagos);
            pnlMiFolio.Controls.Add(lblMiFolio);
            pnlMiFolio.Location = new Point(10, 326);
            pnlMiFolio.Name = "pnlMiFolio";
            pnlMiFolio.Size = new Size(996, 272);
            pnlMiFolio.TabIndex = 1;
            // 
            // dgvMisPagos
            // 
            dgvMisPagos.AllowUserToAddRows = false;
            dgvMisPagos.AllowUserToDeleteRows = false;
            dgvMisPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMisPagos.BackgroundColor = Color.White;
            dgvMisPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisPagos.Dock = DockStyle.Fill;
            dgvMisPagos.Location = new Point(0, 68);
            dgvMisPagos.MultiSelect = false;
            dgvMisPagos.Name = "dgvMisPagos";
            dgvMisPagos.ReadOnly = true;
            dgvMisPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMisPagos.Size = new Size(994, 202);
            dgvMisPagos.TabIndex = 1;
            // 
            // lblMiFolio
            // 
            lblMiFolio.Dock = DockStyle.Top;
            lblMiFolio.Font = new Font("Consolas", 9.5F);
            lblMiFolio.Location = new Point(0, 0);
            lblMiFolio.Name = "lblMiFolio";
            lblMiFolio.Padding = new Padding(10);
            lblMiFolio.Size = new Size(994, 68);
            lblMiFolio.TabIndex = 0;
            lblMiFolio.Text = "Seleccione una de sus reservaciones para ver su estado de cuenta y pagos.";
            // 
            // dgvMisReservas
            // 
            dgvMisReservas.AllowUserToAddRows = false;
            dgvMisReservas.AllowUserToDeleteRows = false;
            dgvMisReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMisReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMisReservas.BackgroundColor = Color.White;
            dgvMisReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisReservas.Location = new Point(10, 10);
            dgvMisReservas.MultiSelect = false;
            dgvMisReservas.Name = "dgvMisReservas";
            dgvMisReservas.ReadOnly = true;
            dgvMisReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMisReservas.Size = new Size(996, 306);
            dgvMisReservas.TabIndex = 0;
            dgvMisReservas.CellClick += dgvMisReservas_CellClick;
            // 
            // FrmPortalHuesped
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 240);
            ClientSize = new Size(1024, 638);
            Controls.Add(tabHuesped);
            Name = "FrmPortalHuesped";
            Text = "Portal del Huesped - Reservas y Estadia";
            FormClosed += FrmPortalHuesped_FormClosed;
            Load += FrmPortalHuesped_Load;
            tabHuesped.ResumeLayout(false);
            tabExplorar.ResumeLayout(false);
            pnlReservaResumen.ResumeLayout(false);
            pnlReservaResumen.PerformLayout();
            pnlFiltroFechas.ResumeLayout(false);
            pnlFiltroFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHuespedes).EndInit();
            tabMisReservas.ResumeLayout(false);
            pnlMiFolio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMisPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMisReservas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabHuesped;
        private TabPage tabExplorar;
        private Panel pnlReservaResumen;
        private Button btnConfirmarReserva;
        private TextBox txtObsReserva;
        private ComboBox cboMetodo;
        private Label lblMetodo;
        private CheckBox chkPagarAnticipo;
        private Label lblCotizacionHuesped;
        private Label lblTituloResumen;
        private FlowLayoutPanel flpSuites;
        private Panel pnlFiltroFechas;
        private Button btnBuscarSuites;
        private NumericUpDown numHuespedes;
        private Label lblHuespedes;
        private DateTimePicker dtpSalida;
        private Label lblSalida;
        private DateTimePicker dtpEntrada;
        private Label lblEntrada;
        private TabPage tabMisReservas;
        private Panel pnlMiFolio;
        private DataGridView dgvMisPagos;
        private Label lblMiFolio;
        private DataGridView dgvMisReservas;
    }
}
