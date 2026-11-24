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
            pnlBuscador = new Panel();
            flpBuscador = new FlowLayoutPanel();
            lblEntrada = new Label();
            dtpEntrada = new DateTimePicker();
            lblSalida = new Label();
            dtpSalida = new DateTimePicker();
            lblNoches = new Label();
            lblHuespedes = new Label();
            numHuespedes = new NumericUpDown();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            btnBuscarDisp = new Button();
            tabMatriz = new TabPage();
            dgvMatriz = new DataGridView();
            pnlMatrizTop = new FlowLayoutPanel();
            lblDesde = new Label();
            dtpMatrizDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpMatrizHasta = new DateTimePicker();
            btnCargarMatriz = new Button();
            tabReservaciones.SuspendLayout();
            tabAsistente.SuspendLayout();
            pnlDerecho.SuspendLayout();
            grpAnticipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnticipo).BeginInit();
            pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDisponibles).BeginInit();
            pnlBuscador.SuspendLayout();
            flpBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHuespedes).BeginInit();
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
            tabReservaciones.Font = new Font("Segoe UI", 9.5F);
            tabReservaciones.Location = new Point(0, 0);
            tabReservaciones.Name = "tabReservaciones";
            tabReservaciones.SelectedIndex = 0;
            tabReservaciones.Size = new Size(1074, 690);
            tabReservaciones.TabIndex = 0;
            // 
            // tabAsistente
            // 
            tabAsistente.BackColor = Color.FromArgb(247, 245, 240);
            tabAsistente.Controls.Add(pnlDerecho);
            tabAsistente.Controls.Add(pnlIzquierdo);
            tabAsistente.Location = new Point(4, 25);
            tabAsistente.Name = "tabAsistente";
            tabAsistente.Padding = new Padding(8);
            tabAsistente.Size = new Size(1066, 661);
            tabAsistente.TabIndex = 0;
            tabAsistente.Text = "Asistente de Nueva Reservacion";
            // 
            // pnlDerecho
            // 
            pnlDerecho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlDerecho.AutoScroll = true;
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
            pnlDerecho.Location = new Point(648, 10);
            pnlDerecho.Name = "pnlDerecho";
            pnlDerecho.Padding = new Padding(12);
            pnlDerecho.Size = new Size(406, 641);
            pnlDerecho.TabIndex = 1;
            // 
            // btnCrearReserva
            // 
            btnCrearReserva.BackColor = Color.FromArgb(21, 128, 61);
            btnCrearReserva.FlatAppearance.BorderSize = 0;
            btnCrearReserva.FlatStyle = FlatStyle.Flat;
            btnCrearReserva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrearReserva.ForeColor = Color.White;
            btnCrearReserva.Location = new Point(16, 560);
            btnCrearReserva.Name = "btnCrearReserva";
            btnCrearReserva.Size = new Size(370, 44);
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
            grpAnticipo.Location = new Point(16, 396);
            grpAnticipo.Name = "grpAnticipo";
            grpAnticipo.Size = new Size(370, 152);
            grpAnticipo.TabIndex = 6;
            grpAnticipo.TabStop = false;
            grpAnticipo.Text = "Pago de Anticipo (30% minimo para confirmar)";
            // 
            // txtReferencia
            // 
            txtReferencia.Location = new Point(132, 116);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.PlaceholderText = "No. aprobacion / transferencia";
            txtReferencia.Size = new Size(224, 24);
            txtReferencia.TabIndex = 6;
            // 
            // cboMetodoPago
            // 
            cboMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodoPago.FormattingEnabled = true;
            cboMetodoPago.Items.AddRange(new object[] { "TarjetaCredito", "TarjetaDebito", "Efectivo", "TransferenciaBancaria" });
            cboMetodoPago.Location = new Point(132, 86);
            cboMetodoPago.Name = "cboMetodoPago";
            cboMetodoPago.Size = new Size(224, 24);
            cboMetodoPago.TabIndex = 5;
            // 
            // numAnticipo
            // 
            numAnticipo.DecimalPlaces = 2;
            numAnticipo.Location = new Point(132, 56);
            numAnticipo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numAnticipo.Name = "numAnticipo";
            numAnticipo.Size = new Size(224, 24);
            numAnticipo.TabIndex = 4;
            // 
            // lblRef
            // 
            lblRef.AutoSize = true;
            lblRef.Location = new Point(12, 119);
            lblRef.Name = "lblRef";
            lblRef.Size = new Size(71, 17);
            lblRef.TabIndex = 3;
            lblRef.Text = "Referencia:";
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Location = new Point(12, 89);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(57, 17);
            lblMetodo.TabIndex = 2;
            lblMetodo.Text = "Metodo:";
            // 
            // lblMontoAnt
            // 
            lblMontoAnt.AutoSize = true;
            lblMontoAnt.Location = new Point(12, 58);
            lblMontoAnt.Name = "lblMontoAnt";
            lblMontoAnt.Size = new Size(102, 17);
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
            chkConfirmarAnticipo.Size = new Size(292, 21);
            chkConfirmarAnticipo.TabIndex = 0;
            chkConfirmarAnticipo.Text = "Registrar anticipo y confirmar inmediatamente";
            chkConfirmarAnticipo.UseVisualStyleBackColor = true;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(16, 330);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Observaciones o solicitudes del huesped";
            txtObservaciones.Size = new Size(370, 54);
            txtObservaciones.TabIndex = 5;
            // 
            // txtAcompanantes
            // 
            txtAcompanantes.Location = new Point(16, 296);
            txtAcompanantes.Name = "txtAcompanantes";
            txtAcompanantes.PlaceholderText = "Acompanantes (opcional)";
            txtAcompanantes.Size = new Size(370, 24);
            txtAcompanantes.TabIndex = 4;
            // 
            // lblCotizacion
            // 
            lblCotizacion.BackColor = Color.FromArgb(247, 245, 240);
            lblCotizacion.BorderStyle = BorderStyle.FixedSingle;
            lblCotizacion.Font = new Font("Segoe UI", 9F);
            lblCotizacion.Location = new Point(16, 92);
            lblCotizacion.Name = "lblCotizacion";
            lblCotizacion.Padding = new Padding(10);
            lblCotizacion.Size = new Size(370, 192);
            lblCotizacion.TabIndex = 3;
            lblCotizacion.Text = "Seleccione fechas y una habitacion disponible para calcular la cotizacion.";
            // 
            // btnRefrescarCli
            // 
            btnRefrescarCli.BackColor = Color.FromArgb(100, 116, 139);
            btnRefrescarCli.FlatAppearance.BorderSize = 0;
            btnRefrescarCli.FlatStyle = FlatStyle.Flat;
            btnRefrescarCli.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRefrescarCli.ForeColor = Color.White;
            btnRefrescarCli.Location = new Point(304, 54);
            btnRefrescarCli.Name = "btnRefrescarCli";
            btnRefrescarCli.Size = new Size(82, 26);
            btnRefrescarCli.TabIndex = 2;
            btnRefrescarCli.Text = "Recargar";
            btnRefrescarCli.UseVisualStyleBackColor = false;
            btnRefrescarCli.Click += btnRefrescarCli_Click;
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(16, 55);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(280, 24);
            cboClientes.TabIndex = 1;
            cboClientes.SelectedIndexChanged += cboClientes_SelectedIndexChanged;
            // 
            // lblPaso3
            // 
            lblPaso3.AutoSize = true;
            lblPaso3.Font = new Font("Georgia", 11.5F, FontStyle.Bold);
            lblPaso3.ForeColor = Color.FromArgb(15, 30, 54);
            lblPaso3.Location = new Point(16, 18);
            lblPaso3.Name = "lblPaso3";
            lblPaso3.Size = new Size(238, 19);
            lblPaso3.TabIndex = 0;
            lblPaso3.Text = "2. Cliente y Cotizacion en Vivo";
            // 
            // pnlIzquierdo
            // 
            pnlIzquierdo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlIzquierdo.BackColor = Color.White;
            pnlIzquierdo.BorderStyle = BorderStyle.FixedSingle;
            pnlIzquierdo.Controls.Add(dgvDisponibles);
            pnlIzquierdo.Controls.Add(pnlBuscador);
            pnlIzquierdo.Location = new Point(10, 10);
            pnlIzquierdo.Name = "pnlIzquierdo";
            pnlIzquierdo.Size = new Size(628, 641);
            pnlIzquierdo.TabIndex = 0;
            // 
            // dgvDisponibles
            // 
            dgvDisponibles.AllowUserToAddRows = false;
            dgvDisponibles.AllowUserToDeleteRows = false;
            dgvDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDisponibles.BackgroundColor = Color.White;
            dgvDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDisponibles.Dock = DockStyle.Fill;
            dgvDisponibles.Location = new Point(0, 98);
            dgvDisponibles.MultiSelect = false;
            dgvDisponibles.Name = "dgvDisponibles";
            dgvDisponibles.ReadOnly = true;
            dgvDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDisponibles.Size = new Size(626, 541);
            dgvDisponibles.TabIndex = 1;
            dgvDisponibles.CellClick += dgvDisponibles_CellClick;
            // 
            // pnlBuscador
            // 
            pnlBuscador.BackColor = Color.FromArgb(15, 30, 54);
            pnlBuscador.Controls.Add(flpBuscador);
            pnlBuscador.Dock = DockStyle.Top;
            pnlBuscador.Location = new Point(0, 0);
            pnlBuscador.Name = "pnlBuscador";
            pnlBuscador.Padding = new Padding(10);
            pnlBuscador.Size = new Size(626, 98);
            pnlBuscador.TabIndex = 0;
            // 
            // flpBuscador
            // 
            flpBuscador.Controls.Add(lblEntrada);
            flpBuscador.Controls.Add(dtpEntrada);
            flpBuscador.Controls.Add(lblSalida);
            flpBuscador.Controls.Add(dtpSalida);
            flpBuscador.Controls.Add(lblNoches);
            flpBuscador.Controls.Add(lblHuespedes);
            flpBuscador.Controls.Add(numHuespedes);
            flpBuscador.Controls.Add(lblTipo);
            flpBuscador.Controls.Add(cboTipo);
            flpBuscador.Controls.Add(btnBuscarDisp);
            flpBuscador.Dock = DockStyle.Fill;
            flpBuscador.Location = new Point(10, 10);
            flpBuscador.Name = "flpBuscador";
            flpBuscador.Size = new Size(606, 78);
            flpBuscador.TabIndex = 0;
            // 
            // lblEntrada
            // 
            lblEntrada.AutoSize = true;
            lblEntrada.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEntrada.ForeColor = Color.White;
            lblEntrada.Location = new Point(3, 8);
            lblEntrada.Margin = new Padding(3, 8, 4, 4);
            lblEntrada.Name = "lblEntrada";
            lblEntrada.Size = new Size(54, 15);
            lblEntrada.TabIndex = 0;
            lblEntrada.Text = "Entrada:";
            // 
            // dtpEntrada
            // 
            dtpEntrada.Format = DateTimePickerFormat.Short;
            dtpEntrada.Location = new Point(64, 4);
            dtpEntrada.Margin = new Padding(3, 4, 10, 4);
            dtpEntrada.Name = "dtpEntrada";
            dtpEntrada.Size = new Size(112, 24);
            dtpEntrada.TabIndex = 1;
            dtpEntrada.ValueChanged += dtpFechas_ValueChanged;
            // 
            // lblSalida
            // 
            lblSalida.AutoSize = true;
            lblSalida.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSalida.ForeColor = Color.White;
            lblSalida.Location = new Point(189, 8);
            lblSalida.Margin = new Padding(3, 8, 4, 4);
            lblSalida.Name = "lblSalida";
            lblSalida.Size = new Size(44, 15);
            lblSalida.TabIndex = 2;
            lblSalida.Text = "Salida:";
            // 
            // dtpSalida
            // 
            dtpSalida.Format = DateTimePickerFormat.Short;
            dtpSalida.Location = new Point(240, 4);
            dtpSalida.Margin = new Padding(3, 4, 10, 4);
            dtpSalida.Name = "dtpSalida";
            dtpSalida.Size = new Size(112, 24);
            dtpSalida.TabIndex = 3;
            dtpSalida.ValueChanged += dtpFechas_ValueChanged;
            // 
            // lblNoches
            // 
            lblNoches.AutoSize = true;
            lblNoches.BackColor = Color.FromArgb(26, 49, 84);
            lblNoches.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNoches.ForeColor = Color.FromArgb(200, 157, 84);
            lblNoches.Location = new Point(365, 4);
            lblNoches.Margin = new Padding(3, 4, 10, 4);
            lblNoches.Name = "lblNoches";
            lblNoches.Padding = new Padding(8, 4, 8, 4);
            lblNoches.Size = new Size(73, 23);
            lblNoches.TabIndex = 4;
            lblNoches.Text = "2 noches";
            // 
            // lblHuespedes
            // 
            lblHuespedes.AutoSize = true;
            lblHuespedes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHuespedes.ForeColor = Color.White;
            lblHuespedes.Location = new Point(3, 44);
            lblHuespedes.Margin = new Padding(3, 10, 4, 4);
            lblHuespedes.Name = "lblHuespedes";
            lblHuespedes.Size = new Size(74, 15);
            lblHuespedes.TabIndex = 5;
            lblHuespedes.Text = "Huespedes:";
            // 
            // numHuespedes
            // 
            numHuespedes.Location = new Point(84, 40);
            numHuespedes.Margin = new Padding(3, 6, 10, 4);
            numHuespedes.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numHuespedes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHuespedes.Name = "numHuespedes";
            numHuespedes.Size = new Size(64, 24);
            numHuespedes.TabIndex = 6;
            numHuespedes.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipo.ForeColor = Color.White;
            lblTipo.Location = new Point(161, 44);
            lblTipo.Margin = new Padding(3, 10, 4, 4);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 7;
            lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(202, 40);
            cboTipo.Margin = new Padding(3, 6, 10, 4);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(192, 24);
            cboTipo.TabIndex = 8;
            // 
            // btnBuscarDisp
            // 
            btnBuscarDisp.BackColor = Color.FromArgb(200, 157, 84);
            btnBuscarDisp.FlatAppearance.BorderSize = 0;
            btnBuscarDisp.FlatStyle = FlatStyle.Flat;
            btnBuscarDisp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarDisp.ForeColor = Color.FromArgb(15, 30, 54);
            btnBuscarDisp.Location = new Point(407, 38);
            btnBuscarDisp.Margin = new Padding(3, 4, 3, 4);
            btnBuscarDisp.Name = "btnBuscarDisp";
            btnBuscarDisp.Size = new Size(166, 30);
            btnBuscarDisp.TabIndex = 9;
            btnBuscarDisp.Text = "Buscar Disponibles";
            btnBuscarDisp.UseVisualStyleBackColor = false;
            btnBuscarDisp.Click += btnBuscarDisp_Click;
            // 
            // tabMatriz
            // 
            tabMatriz.BackColor = Color.FromArgb(247, 245, 240);
            tabMatriz.Controls.Add(dgvMatriz);
            tabMatriz.Controls.Add(pnlMatrizTop);
            tabMatriz.Location = new Point(4, 25);
            tabMatriz.Name = "tabMatriz";
            tabMatriz.Padding = new Padding(8);
            tabMatriz.Size = new Size(1066, 661);
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
            dgvMatriz.Location = new Point(8, 56);
            dgvMatriz.MultiSelect = false;
            dgvMatriz.Name = "dgvMatriz";
            dgvMatriz.ReadOnly = true;
            dgvMatriz.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriz.Size = new Size(1050, 597);
            dgvMatriz.TabIndex = 1;
            // 
            // pnlMatrizTop
            // 
            pnlMatrizTop.BackColor = Color.White;
            pnlMatrizTop.Controls.Add(lblDesde);
            pnlMatrizTop.Controls.Add(dtpMatrizDesde);
            pnlMatrizTop.Controls.Add(lblHasta);
            pnlMatrizTop.Controls.Add(dtpMatrizHasta);
            pnlMatrizTop.Controls.Add(btnCargarMatriz);
            pnlMatrizTop.Dock = DockStyle.Top;
            pnlMatrizTop.Location = new Point(8, 8);
            pnlMatrizTop.Name = "pnlMatrizTop";
            pnlMatrizTop.Padding = new Padding(10, 8, 10, 6);
            pnlMatrizTop.Size = new Size(1050, 48);
            pnlMatrizTop.TabIndex = 0;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(13, 15);
            lblDesde.Margin = new Padding(3, 7, 4, 4);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(46, 17);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // dtpMatrizDesde
            // 
            dtpMatrizDesde.Format = DateTimePickerFormat.Short;
            dtpMatrizDesde.Location = new Point(66, 12);
            dtpMatrizDesde.Margin = new Padding(3, 4, 10, 4);
            dtpMatrizDesde.Name = "dtpMatrizDesde";
            dtpMatrizDesde.Size = new Size(116, 24);
            dtpMatrizDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(195, 15);
            lblHasta.Margin = new Padding(3, 7, 4, 4);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(44, 17);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpMatrizHasta
            // 
            dtpMatrizHasta.Format = DateTimePickerFormat.Short;
            dtpMatrizHasta.Location = new Point(246, 12);
            dtpMatrizHasta.Margin = new Padding(3, 4, 12, 4);
            dtpMatrizHasta.Name = "dtpMatrizHasta";
            dtpMatrizHasta.Size = new Size(116, 24);
            dtpMatrizHasta.TabIndex = 3;
            // 
            // btnCargarMatriz
            // 
            btnCargarMatriz.BackColor = Color.FromArgb(15, 30, 54);
            btnCargarMatriz.FlatAppearance.BorderSize = 0;
            btnCargarMatriz.FlatStyle = FlatStyle.Flat;
            btnCargarMatriz.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCargarMatriz.ForeColor = Color.White;
            btnCargarMatriz.Location = new Point(377, 10);
            btnCargarMatriz.Margin = new Padding(3, 2, 3, 2);
            btnCargarMatriz.Name = "btnCargarMatriz";
            btnCargarMatriz.Size = new Size(154, 30);
            btnCargarMatriz.TabIndex = 4;
            btnCargarMatriz.Text = "Consultar Matriz";
            btnCargarMatriz.UseVisualStyleBackColor = false;
            btnCargarMatriz.Click += btnCargarMatriz_Click;
            // 
            // FrmNuevaReservacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 245, 240);
            ClientSize = new Size(1074, 690);
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
            pnlBuscador.ResumeLayout(false);
            flpBuscador.ResumeLayout(false);
            flpBuscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHuespedes).EndInit();
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
        private Panel pnlBuscador;
        private FlowLayoutPanel flpBuscador;
        private Label lblEntrada;
        private DateTimePicker dtpEntrada;
        private Label lblSalida;
        private DateTimePicker dtpSalida;
        private Label lblNoches;
        private Label lblHuespedes;
        private NumericUpDown numHuespedes;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Button btnBuscarDisp;
        private TabPage tabMatriz;
        private DataGridView dgvMatriz;
        private FlowLayoutPanel pnlMatrizTop;
        private Label lblDesde;
        private DateTimePicker dtpMatrizDesde;
        private Label lblHasta;
        private DateTimePicker dtpMatrizHasta;
        private Button btnCargarMatriz;
    }
}
