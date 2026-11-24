namespace Hotel.WindowsForms.Views
{
    partial class FrmNuevaReservacion
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
            tabReservaciones = new TabControl();
            tabAsistente = new TabPage();
            pnlDerecho = new Panel();
            btnCrearReserva = new Button();
            grpAnticipo = new GroupBox();
            txtReferencia = new TextBox();
            cboMetodoPago = new ComboBox();
            numAnticipo = new NumericUpDown();
            lblRef = new Label();
            lblMetodo = new Label();
            lblMontoAnt = new Label();
            chkConfirmarAnticipo = new CheckBox();
            txtObservaciones = new TextBox();
            txtAcompanantes = new TextBox();
            lblCotizacion = new Label();
            btnRefrescarCli = new Button();
            cboClientes = new ComboBox();
            lblPaso3 = new Label();
            pnlIzquierdo = new Panel();
            dgvDisponibles = new DataGridView();
            pnlFiltros = new Panel();
            btnBuscarDisp = new Button();
            cboTipo = new ComboBox();
            lblTipo = new Label();
            numHuespedes = new NumericUpDown();
            lblHuespedes = new Label();
            grpSalida = new GroupBox();
            calSalida = new MonthCalendar();
            grpEntrada = new GroupBox();
            calEntrada = new MonthCalendar();
            tabMatriz = new TabPage();
            dgvMatriz = new DataGridView();
            pnlMatrizTop = new Panel();
            btnCargarMatriz = new Button();
            dtpMatrizHasta = new DateTimePicker();
            lblHasta = new Label();
            dtpMatrizDesde = new DateTimePicker();
            lblDesde = new Label();
            tabReservaciones.SuspendLayout();
            tabAsistente.SuspendLayout();
            pnlDerecho.SuspendLayout();
            grpAnticipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnticipo).BeginInit();
            pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDisponibles).BeginInit();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHuespedes).BeginInit();
            grpSalida.SuspendLayout();
            grpEntrada.SuspendLayout();
            tabMatriz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).BeginInit();
            pnlMatrizTop.SuspendLayout();
            SuspendLayout();
            // 
            // tabReservaciones
            // 
            tabReservaciones.Controls.Add(tabAsistente);
            tabReservaciones.Controls.Add(tabMatriz);
            tabReservaciones.Dock = DockStyle.Fill;
            tabReservaciones.Location = new Point(0, 0);
            tabReservaciones.Name = "tabReservaciones";
            tabReservaciones.SelectedIndex = 0;
            tabReservaciones.Size = new Size(1024, 638);
            tabReservaciones.TabIndex = 0;
            // 
            // tabAsistente
            // 
            tabAsistente.BackColor = Color.FromArgb(243, 246, 250);
            tabAsistente.Controls.Add(pnlDerecho);
            tabAsistente.Controls.Add(pnlIzquierdo);
            tabAsistente.Location = new Point(4, 24);
            tabAsistente.Name = "tabAsistente";
            tabAsistente.Padding = new Padding(6);
            tabAsistente.Size = new Size(1016, 610);
            tabAsistente.TabIndex = 0;
            tabAsistente.Text = "Asistente de Nueva Reservacion";
            // 
            // pnlDerecho
            // 
            pnlDerecho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlDerecho.BackColor = Color.White;
            pnlDerecho.BorderStyle = BorderStyle.FixedSingle;
            pnlDerecho.Controls.Add(btnCrearReserva);
            pnlDerecho.Controls.Add(grpAnticipo);
            pnlDerecho.Controls.Add(txtObservaciones);
            pnlDerecho.Controls.Add(txtAcompanantes);
            pnlDerecho.Controls.Add(lblCotizacion);
            pnlDerecho.Controls.Add(btnRefrescarCli);
            pnlDerecho.Controls.Add(cboClientes);
            pnlDerecho.Controls.Add(lblPaso3);
            pnlDerecho.Location = new Point(628, 8);
            pnlDerecho.Name = "pnlDerecho";
            pnlDerecho.Size = new Size(380, 594);
            pnlDerecho.TabIndex = 1;
            // 
            // btnCrearReserva
            // 
            btnCrearReserva.BackColor = Color.FromArgb(22, 163, 74);
            btnCrearReserva.FlatAppearance.BorderSize = 0;
            btnCrearReserva.FlatStyle = FlatStyle.Flat;
            btnCrearReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrearReserva.ForeColor = Color.White;
            btnCrearReserva.Location = new Point(14, 520);
            btnCrearReserva.Name = "btnCrearReserva";
            btnCrearReserva.Size = new Size(350, 42);
            btnCrearReserva.TabIndex = 7;
            btnCrearReserva.Text = "Crear Reservacion";
            btnCrearReserva.UseVisualStyleBackColor = false;
            btnCrearReserva.Click += btnCrearReserva_Click;
            // 
            // grpAnticipo
            // 
            grpAnticipo.Controls.Add(txtReferencia);
            grpAnticipo.Controls.Add(cboMetodoPago);
            grpAnticipo.Controls.Add(numAnticipo);
            grpAnticipo.Controls.Add(lblRef);
            grpAnticipo.Controls.Add(lblMetodo);
            grpAnticipo.Controls.Add(lblMontoAnt);
            grpAnticipo.Controls.Add(chkConfirmarAnticipo);
            grpAnticipo.Location = new Point(14, 360);
            grpAnticipo.Name = "grpAnticipo";
            grpAnticipo.Size = new Size(350, 148);
            grpAnticipo.TabIndex = 6;
            grpAnticipo.TabStop = false;
            grpAnticipo.Text = "Pago de Anticipo (30% minimo para confirmar)";
            // 
            // txtReferencia
            // 
            txtReferencia.Location = new Point(122, 114);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.PlaceholderText = "No. aprobacion / transferencia";
            txtReferencia.Size = new Size(214, 23);
            txtReferencia.TabIndex = 6;
            // 
            // cboMetodoPago
            // 
            cboMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodoPago.FormattingEnabled = true;
            cboMetodoPago.Items.AddRange(new object[] { "TarjetaCredito", "TarjetaDebito", "Efectivo", "TransferenciaBancaria" });
            cboMetodoPago.Location = new Point(122, 84);
            cboMetodoPago.Name = "cboMetodoPago";
            cboMetodoPago.Size = new Size(214, 23);
            cboMetodoPago.TabIndex = 5;
            // 
            // numAnticipo
            // 
            numAnticipo.DecimalPlaces = 2;
            numAnticipo.Location = new Point(122, 54);
            numAnticipo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numAnticipo.Name = "numAnticipo";
            numAnticipo.Size = new Size(214, 23);
            numAnticipo.TabIndex = 4;
            // 
            // lblRef
            // 
            lblRef.AutoSize = true;
            lblRef.Location = new Point(12, 117);
            lblRef.Name = "lblRef";
            lblRef.Size = new Size(65, 15);
            lblRef.TabIndex = 3;
            lblRef.Text = "Referencia:";
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Location = new Point(12, 87);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(52, 15);
            lblMetodo.TabIndex = 2;
            lblMetodo.Text = "Metodo:";
            // 
            // lblMontoAnt
            // 
            lblMontoAnt.AutoSize = true;
            lblMontoAnt.Location = new Point(12, 56);
            lblMontoAnt.Name = "lblMontoAnt";
            lblMontoAnt.Size = new Size(94, 15);
            lblMontoAnt.TabIndex = 1;
            lblMontoAnt.Text = "Monto Anticipo:";
            // 
            // chkConfirmarAnticipo
            // 
            chkConfirmarAnticipo.AutoSize = true;
            chkConfirmarAnticipo.Checked = true;
            chkConfirmarAnticipo.CheckState = CheckState.Checked;
            chkConfirmarAnticipo.Location = new Point(12, 24);
            chkConfirmarAnticipo.Name = "chkConfirmarAnticipo";
            chkConfirmarAnticipo.Size = new Size(292, 19);
            chkConfirmarAnticipo.TabIndex = 0;
            chkConfirmarAnticipo.Text = "Registrar anticipo y confirmar inmediatamente";
            chkConfirmarAnticipo.UseVisualStyleBackColor = true;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(14, 302);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Observaciones / solicitudes";
            txtObservaciones.Size = new Size(350, 48);
            txtObservaciones.TabIndex = 5;
            // 
            // txtAcompanantes
            // 
            txtAcompanantes.Location = new Point(14, 270);
            txtAcompanantes.Name = "txtAcompanantes";
            txtAcompanantes.PlaceholderText = "Acompanantes (opcional)";
            txtAcompanantes.Size = new Size(350, 23);
            txtAcompanantes.TabIndex = 4;
            // 
            // lblCotizacion
            // 
            lblCotizacion.BackColor = Color.FromArgb(248, 250, 252);
            lblCotizacion.BorderStyle = BorderStyle.FixedSingle;
            lblCotizacion.Font = new Font("Consolas", 9F);
            lblCotizacion.Location = new Point(14, 86);
            lblCotizacion.Name = "lblCotizacion";
            lblCotizacion.Padding = new Padding(8);
            lblCotizacion.Size = new Size(350, 174);
            lblCotizacion.TabIndex = 3;
            lblCotizacion.Text = "Seleccione fechas y una habitacion disponible para cotizar.";
            // 
            // btnRefrescarCli
            // 
            btnRefrescarCli.BackColor = Color.FromArgb(100, 116, 139);
            btnRefrescarCli.FlatAppearance.BorderSize = 0;
            btnRefrescarCli.FlatStyle = FlatStyle.Flat;
            btnRefrescarCli.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRefrescarCli.ForeColor = Color.White;
            btnRefrescarCli.Location = new Point(288, 50);
            btnRefrescarCli.Name = "btnRefrescarCli";
            btnRefrescarCli.Size = new Size(76, 26);
            btnRefrescarCli.TabIndex = 2;
            btnRefrescarCli.Text = "Recargar";
            btnRefrescarCli.UseVisualStyleBackColor = false;
            btnRefrescarCli.Click += btnRefrescarCli_Click;
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(14, 51);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(266, 23);
            cboClientes.TabIndex = 1;
            cboClientes.SelectedIndexChanged += cboClientes_SelectedIndexChanged;
            // 
            // lblPaso3
            // 
            lblPaso3.AutoSize = true;
            lblPaso3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPaso3.ForeColor = Color.FromArgb(30, 41, 59);
            lblPaso3.Location = new Point(14, 16);
            lblPaso3.Name = "lblPaso3";
            lblPaso3.Size = new Size(232, 20);
            lblPaso3.TabIndex = 0;
            lblPaso3.Text = "2. Cliente y Cotizacion en Vivo";
            // 
            // pnlIzquierdo
            // 
            pnlIzquierdo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlIzquierdo.BackColor = Color.White;
            pnlIzquierdo.BorderStyle = BorderStyle.FixedSingle;
            pnlIzquierdo.Controls.Add(dgvDisponibles);
            pnlIzquierdo.Controls.Add(pnlFiltros);
            pnlIzquierdo.Controls.Add(grpSalida);
            pnlIzquierdo.Controls.Add(grpEntrada);
            pnlIzquierdo.Location = new Point(8, 8);
            pnlIzquierdo.Name = "pnlIzquierdo";
            pnlIzquierdo.Size = new Size(612, 594);
            pnlIzquierdo.TabIndex = 0;
            // 
            // dgvDisponibles
            // 
            dgvDisponibles.AllowUserToAddRows = false;
            dgvDisponibles.AllowUserToDeleteRows = false;
            dgvDisponibles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDisponibles.BackgroundColor = Color.White;
            dgvDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisponibles.Location = new Point(12, 256);
            dgvDisponibles.MultiSelect = false;
            dgvDisponibles.Name = "dgvDisponibles";
            dgvDisponibles.ReadOnly = true;
            dgvDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDisponibles.Size = new Size(586, 326);
            dgvDisponibles.TabIndex = 3;
            dgvDisponibles.CellClick += dgvDisponibles_CellClick;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(btnBuscarDisp);
            pnlFiltros.Controls.Add(cboTipo);
            pnlFiltros.Controls.Add(lblTipo);
            pnlFiltros.Controls.Add(numHuespedes);
            pnlFiltros.Controls.Add(lblHuespedes);
            pnlFiltros.Location = new Point(12, 208);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(586, 42);
            pnlFiltros.TabIndex = 2;
            // 
            // btnBuscarDisp
            // 
            btnBuscarDisp.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscarDisp.FlatAppearance.BorderSize = 0;
            btnBuscarDisp.FlatStyle = FlatStyle.Flat;
            btnBuscarDisp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarDisp.ForeColor = Color.White;
            btnBuscarDisp.Location = new Point(440, 6);
            btnBuscarDisp.Name = "btnBuscarDisp";
            btnBuscarDisp.Size = new Size(134, 30);
            btnBuscarDisp.TabIndex = 4;
            btnBuscarDisp.Text = "Buscar Libres";
            btnBuscarDisp.UseVisualStyleBackColor = false;
            btnBuscarDisp.Click += btnBuscarDisp_Click;
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(226, 9);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(200, 23);
            cboTipo.TabIndex = 3;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(184, 12);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo:";
            // 
            // numHuespedes
            // 
            numHuespedes.Location = new Point(88, 9);
            numHuespedes.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numHuespedes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHuespedes.Name = "numHuespedes";
            numHuespedes.Size = new Size(72, 23);
            numHuespedes.TabIndex = 1;
            numHuespedes.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblHuespedes
            // 
            lblHuespedes.AutoSize = true;
            lblHuespedes.Location = new Point(8, 12);
            lblHuespedes.Name = "lblHuespedes";
            lblHuespedes.Size = new Size(74, 15);
            lblHuespedes.TabIndex = 0;
            lblHuespedes.Text = "Huespedes:";
            // 
            // grpSalida
            // 
            grpSalida.Controls.Add(calSalida);
            grpSalida.Location = new Point(282, 10);
            grpSalida.Name = "grpSalida";
            grpSalida.Size = new Size(256, 192);
            grpSalida.TabIndex = 1;
            grpSalida.TabStop = false;
            grpSalida.Text = "Fecha Salida";
            // 
            // calSalida
            // 
            calSalida.Location = new Point(12, 22);
            calSalida.MaxSelectionCount = 1;
            calSalida.Name = "calSalida";
            calSalida.TabIndex = 0;
            // 
            // grpEntrada
            // 
            grpEntrada.Controls.Add(calEntrada);
            grpEntrada.Location = new Point(12, 10);
            grpEntrada.Name = "grpEntrada";
            grpEntrada.Size = new Size(256, 192);
            grpEntrada.TabIndex = 0;
            grpEntrada.TabStop = false;
            grpEntrada.Text = "1. Fecha Entrada";
            // 
            // calEntrada
            // 
            calEntrada.Location = new Point(12, 22);
            calEntrada.MaxSelectionCount = 1;
            calEntrada.Name = "calEntrada";
            calEntrada.TabIndex = 0;
            // 
            // tabMatriz
            // 
            tabMatriz.BackColor = Color.FromArgb(243, 246, 250);
            tabMatriz.Controls.Add(dgvMatriz);
            tabMatriz.Controls.Add(pnlMatrizTop);
            tabMatriz.Location = new Point(4, 24);
            tabMatriz.Name = "tabMatriz";
            tabMatriz.Padding = new Padding(6);
            tabMatriz.Size = new Size(1016, 610);
            tabMatriz.TabIndex = 1;
            tabMatriz.Text = "Matriz Visual de Ocupacion";
            // 
            // dgvMatriz
            // 
            dgvMatriz.AllowUserToAddRows = false;
            dgvMatriz.AllowUserToDeleteRows = false;
            dgvMatriz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMatriz.BackgroundColor = Color.White;
            dgvMatriz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatriz.Dock = DockStyle.Fill;
            dgvMatriz.Location = new Point(6, 54);
            dgvMatriz.MultiSelect = false;
            dgvMatriz.Name = "dgvMatriz";
            dgvMatriz.ReadOnly = true;
            dgvMatriz.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriz.Size = new Size(1004, 550);
            dgvMatriz.TabIndex = 1;
            // 
            // pnlMatrizTop
            // 
            pnlMatrizTop.BackColor = Color.White;
            pnlMatrizTop.Controls.Add(btnCargarMatriz);
            pnlMatrizTop.Controls.Add(dtpMatrizHasta);
            pnlMatrizTop.Controls.Add(lblHasta);
            pnlMatrizTop.Controls.Add(dtpMatrizDesde);
            pnlMatrizTop.Controls.Add(lblDesde);
            pnlMatrizTop.Dock = DockStyle.Top;
            pnlMatrizTop.Location = new Point(6, 6);
            pnlMatrizTop.Name = "pnlMatrizTop";
            pnlMatrizTop.Size = new Size(1004, 48);
            pnlMatrizTop.TabIndex = 0;
            // 
            // btnCargarMatriz
            // 
            btnCargarMatriz.BackColor = Color.FromArgb(37, 99, 235);
            btnCargarMatriz.FlatAppearance.BorderSize = 0;
            btnCargarMatriz.FlatStyle = FlatStyle.Flat;
            btnCargarMatriz.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCargarMatriz.ForeColor = Color.White;
            btnCargarMatriz.Location = new Point(366, 9);
            btnCargarMatriz.Name = "btnCargarMatriz";
            btnCargarMatriz.Size = new Size(135, 30);
            btnCargarMatriz.TabIndex = 4;
            btnCargarMatriz.Text = "Consultar Matriz";
            btnCargarMatriz.UseVisualStyleBackColor = false;
            btnCargarMatriz.Click += btnCargarMatriz_Click;
            // 
            // dtpMatrizHasta
            // 
            dtpMatrizHasta.Format = DateTimePickerFormat.Short;
            dtpMatrizHasta.Location = new Point(236, 12);
            dtpMatrizHasta.Name = "dtpMatrizHasta";
            dtpMatrizHasta.Size = new Size(116, 23);
            dtpMatrizHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(190, 15);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpMatrizDesde
            // 
            dtpMatrizDesde.Format = DateTimePickerFormat.Short;
            dtpMatrizDesde.Location = new Point(62, 12);
            dtpMatrizDesde.Name = "dtpMatrizDesde";
            dtpMatrizDesde.Size = new Size(116, 23);
            dtpMatrizDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(14, 15);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // FrmNuevaReservacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(tabReservaciones);
            Name = "FrmNuevaReservacion";
            Text = "Nueva Reservacion y Matriz de Ocupacion";
            FormClosed += FrmNuevaReservacion_FormClosed;
            Load += FrmNuevaReservacion_Load;
            tabReservaciones.ResumeLayout(false);
            tabAsistente.ResumeLayout(false);
            pnlDerecho.ResumeLayout(false);
            pnlDerecho.PerformLayout();
            grpAnticipo.ResumeLayout(false);
            grpAnticipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnticipo).EndInit();
            pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDisponibles).EndInit();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHuespedes).EndInit();
            grpSalida.ResumeLayout(false);
            grpEntrada.ResumeLayout(false);
            tabMatriz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMatriz).EndInit();
            pnlMatrizTop.ResumeLayout(false);
            pnlMatrizTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabReservaciones;
        private TabPage tabAsistente;
        private Panel pnlDerecho;
        private Button btnCrearReserva;
        private GroupBox grpAnticipo;
        private TextBox txtReferencia;
        private ComboBox cboMetodoPago;
        private NumericUpDown numAnticipo;
        private Label lblRef;
        private Label lblMetodo;
        private Label lblMontoAnt;
        private CheckBox chkConfirmarAnticipo;
        private TextBox txtObservaciones;
        private TextBox txtAcompanantes;
        private Label lblCotizacion;
        private Button btnRefrescarCli;
        private ComboBox cboClientes;
        private Label lblPaso3;
        private Panel pnlIzquierdo;
        private DataGridView dgvDisponibles;
        private Panel pnlFiltros;
        private Button btnBuscarDisp;
        private ComboBox cboTipo;
        private Label lblTipo;
        private NumericUpDown numHuespedes;
        private Label lblHuespedes;
        private GroupBox grpSalida;
        private MonthCalendar calSalida;
        private GroupBox grpEntrada;
        private MonthCalendar calEntrada;
        private TabPage tabMatriz;
        private DataGridView dgvMatriz;
        private Panel pnlMatrizTop;
        private Button btnCargarMatriz;
        private DateTimePicker dtpMatrizHasta;
        private Label lblHasta;
        private DateTimePicker dtpMatrizDesde;
        private Label lblDesde;
    }
}
