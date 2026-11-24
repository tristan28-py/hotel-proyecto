namespace Hotel.WindowsForms.Views
{
    partial class FrmCheckInOut
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
            pnlBusqueda = new Panel();
            btnBuscar = new Button();
            cboFiltroEstado = new ComboBox();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            dgvReservas = new DataGridView();
            pnlPagos = new Panel();
            dgvPagos = new DataGridView();
            lblPagosTitulo = new Label();
            pnlAcciones = new Panel();
            grpCheckOut = new GroupBox();
            btnCheckOut = new Button();
            txtObsOut = new TextBox();
            cboComprobante = new ComboBox();
            numAjustes = new NumericUpDown();
            lblObsOut = new Label();
            lblComp = new Label();
            lblAjustes = new Label();
            grpPago = new GroupBox();
            btnPagar = new Button();
            txtRefPago = new TextBox();
            cboMetodo = new ComboBox();
            numPago = new NumericUpDown();
            lblRef = new Label();
            lblMetodo = new Label();
            lblMonto = new Label();
            grpCheckIn = new GroupBox();
            btnCancelar = new Button();
            btnCheckIn = new Button();
            btnConfirmar = new Button();
            txtAcompanantes = new TextBox();
            txtLlaves = new TextBox();
            lblResumenFolio = new Label();
            pnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            pnlPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            pnlAcciones.SuspendLayout();
            grpCheckOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAjustes).BeginInit();
            grpPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPago).BeginInit();
            grpCheckIn.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBusqueda.BackColor = Color.White;
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(cboFiltroEstado);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Controls.Add(lblBuscar);
            pnlBusqueda.Location = new Point(12, 10);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(1000, 44);
            pnlBusqueda.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(37, 99, 235);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(572, 8);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(92, 28);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cboFiltroEstado
            // 
            cboFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroEstado.FormattingEnabled = true;
            cboFiltroEstado.Items.AddRange(new object[] { "Todos", "PendientePago", "Confirmada", "EnCurso", "Completada", "Cancelada" });
            cboFiltroEstado.Location = new Point(414, 10);
            cboFiltroEstado.Name = "cboFiltroEstado";
            cboFiltroEstado.Size = new Size(148, 23);
            cboFiltroEstado.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(190, 10);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(214, 23);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.Location = new Point(12, 13);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(172, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "DNI / Codigo / Habitacion:";
            // 
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Location = new Point(12, 62);
            dgvReservas.MultiSelect = false;
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.Size = new Size(605, 326);
            dgvReservas.TabIndex = 1;
            dgvReservas.CellClick += dgvReservas_CellClick;
            // 
            // pnlPagos
            // 
            pnlPagos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPagos.BackColor = Color.White;
            pnlPagos.BorderStyle = BorderStyle.FixedSingle;
            pnlPagos.Controls.Add(dgvPagos);
            pnlPagos.Controls.Add(lblPagosTitulo);
            pnlPagos.Location = new Point(12, 396);
            pnlPagos.Name = "pnlPagos";
            pnlPagos.Size = new Size(605, 228);
            pnlPagos.TabIndex = 2;
            // 
            // dgvPagos
            // 
            dgvPagos.AllowUserToAddRows = false;
            dgvPagos.AllowUserToDeleteRows = false;
            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagos.BackgroundColor = Color.White;
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Dock = DockStyle.Fill;
            dgvPagos.Location = new Point(0, 26);
            dgvPagos.MultiSelect = false;
            dgvPagos.Name = "dgvPagos";
            dgvPagos.ReadOnly = true;
            dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagos.Size = new Size(603, 200);
            dgvPagos.TabIndex = 1;
            // 
            // lblPagosTitulo
            // 
            lblPagosTitulo.Dock = DockStyle.Top;
            lblPagosTitulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPagosTitulo.Location = new Point(0, 0);
            lblPagosTitulo.Name = "lblPagosTitulo";
            lblPagosTitulo.Padding = new Padding(8, 4, 8, 0);
            lblPagosTitulo.Size = new Size(603, 26);
            lblPagosTitulo.TabIndex = 0;
            lblPagosTitulo.Text = "Historial de Pagos y Abonos";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlAcciones.BackColor = Color.White;
            pnlAcciones.BorderStyle = BorderStyle.FixedSingle;
            pnlAcciones.Controls.Add(grpCheckOut);
            pnlAcciones.Controls.Add(grpPago);
            pnlAcciones.Controls.Add(grpCheckIn);
            pnlAcciones.Controls.Add(lblResumenFolio);
            pnlAcciones.Location = new Point(628, 62);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(384, 562);
            pnlAcciones.TabIndex = 3;
            // 
            // grpCheckOut
            // 
            grpCheckOut.Controls.Add(btnCheckOut);
            grpCheckOut.Controls.Add(txtObsOut);
            grpCheckOut.Controls.Add(cboComprobante);
            grpCheckOut.Controls.Add(numAjustes);
            grpCheckOut.Controls.Add(lblObsOut);
            grpCheckOut.Controls.Add(lblComp);
            grpCheckOut.Controls.Add(lblAjustes);
            grpCheckOut.Location = new Point(12, 404);
            grpCheckOut.Name = "grpCheckOut";
            grpCheckOut.Size = new Size(358, 146);
            grpCheckOut.TabIndex = 3;
            grpCheckOut.TabStop = false;
            grpCheckOut.Text = "3. Check-out y Factura";
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.FromArgb(220, 38, 38);
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(10, 106);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(336, 32);
            btnCheckOut.TabIndex = 6;
            btnCheckOut.Text = "Finalizar Check-out y Factura PDF";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // txtObsOut
            // 
            txtObsOut.Location = new Point(126, 76);
            txtObsOut.Name = "txtObsOut";
            txtObsOut.PlaceholderText = "Inspeccion / minibar";
            txtObsOut.Size = new Size(220, 23);
            txtObsOut.TabIndex = 5;
            // 
            // cboComprobante
            // 
            cboComprobante.DropDownStyle = ComboBoxStyle.DropDownList;
            cboComprobante.FormattingEnabled = true;
            cboComprobante.Items.AddRange(new object[] { "Recibo", "Factura" });
            cboComprobante.Location = new Point(126, 48);
            cboComprobante.Name = "cboComprobante";
            cboComprobante.Size = new Size(220, 23);
            cboComprobante.TabIndex = 4;
            // 
            // numAjustes
            // 
            numAjustes.DecimalPlaces = 2;
            numAjustes.Location = new Point(126, 20);
            numAjustes.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numAjustes.Minimum = new decimal(new int[] { 5000, 0, 0, -2147483648 });
            numAjustes.Name = "numAjustes";
            numAjustes.Size = new Size(220, 23);
            numAjustes.TabIndex = 3;
            // 
            // lblObsOut
            // 
            lblObsOut.AutoSize = true;
            lblObsOut.Location = new Point(10, 79);
            lblObsOut.Name = "lblObsOut";
            lblObsOut.Size = new Size(78, 15);
            lblObsOut.TabIndex = 2;
            lblObsOut.Text = "Observacion:";
            // 
            // lblComp
            // 
            lblComp.AutoSize = true;
            lblComp.Location = new Point(10, 51);
            lblComp.Name = "lblComp";
            lblComp.Size = new Size(85, 15);
            lblComp.TabIndex = 1;
            lblComp.Text = "Comprobante:";
            // 
            // lblAjustes
            // 
            lblAjustes.AutoSize = true;
            lblAjustes.Location = new Point(10, 22);
            lblAjustes.Name = "lblAjustes";
            lblAjustes.Size = new Size(99, 15);
            lblAjustes.TabIndex = 0;
            lblAjustes.Text = "Ajustes/Minibar:";
            // 
            // grpPago
            // 
            grpPago.Controls.Add(btnPagar);
            grpPago.Controls.Add(txtRefPago);
            grpPago.Controls.Add(cboMetodo);
            grpPago.Controls.Add(numPago);
            grpPago.Controls.Add(lblRef);
            grpPago.Controls.Add(lblMetodo);
            grpPago.Controls.Add(lblMonto);
            grpPago.Location = new Point(12, 250);
            grpPago.Name = "grpPago";
            grpPago.Size = new Size(358, 146);
            grpPago.TabIndex = 2;
            grpPago.TabStop = false;
            grpPago.Text = "2. Registrar Abono / Pago";
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.FromArgb(37, 99, 235);
            btnPagar.FlatAppearance.BorderSize = 0;
            btnPagar.FlatStyle = FlatStyle.Flat;
            btnPagar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPagar.ForeColor = Color.White;
            btnPagar.Location = new Point(10, 106);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(336, 32);
            btnPagar.TabIndex = 6;
            btnPagar.Text = "Registrar Abono";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // txtRefPago
            // 
            txtRefPago.Location = new Point(126, 76);
            txtRefPago.Name = "txtRefPago";
            txtRefPago.PlaceholderText = "Referencia transaccion";
            txtRefPago.Size = new Size(220, 23);
            txtRefPago.TabIndex = 5;
            // 
            // cboMetodo
            // 
            cboMetodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodo.FormattingEnabled = true;
            cboMetodo.Items.AddRange(new object[] { "Efectivo", "TarjetaCredito", "TarjetaDebito", "TransferenciaBancaria" });
            cboMetodo.Location = new Point(126, 48);
            cboMetodo.Name = "cboMetodo";
            cboMetodo.Size = new Size(220, 23);
            cboMetodo.TabIndex = 4;
            // 
            // numPago
            // 
            numPago.DecimalPlaces = 2;
            numPago.Location = new Point(126, 20);
            numPago.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPago.Name = "numPago";
            numPago.Size = new Size(220, 23);
            numPago.TabIndex = 3;
            // 
            // lblRef
            // 
            lblRef.AutoSize = true;
            lblRef.Location = new Point(10, 79);
            lblRef.Name = "lblRef";
            lblRef.Size = new Size(65, 15);
            lblRef.TabIndex = 2;
            lblRef.Text = "Referencia:";
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Location = new Point(10, 51);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(52, 15);
            lblMetodo.TabIndex = 1;
            lblMetodo.Text = "Metodo:";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(10, 22);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(46, 15);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "Monto:";
            // 
            // grpCheckIn
            // 
            grpCheckIn.Controls.Add(btnCancelar);
            grpCheckIn.Controls.Add(btnCheckIn);
            grpCheckIn.Controls.Add(btnConfirmar);
            grpCheckIn.Controls.Add(txtAcompanantes);
            grpCheckIn.Controls.Add(txtLlaves);
            grpCheckIn.Location = new Point(12, 128);
            grpCheckIn.Name = "grpCheckIn";
            grpCheckIn.Size = new Size(358, 114);
            grpCheckIn.TabIndex = 1;
            grpCheckIn.TabStop = false;
            grpCheckIn.Text = "1. Check-in y Estado de Reserva";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(220, 38, 38);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(268, 76);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(78, 28);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.FromArgb(22, 163, 74);
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(136, 76);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(124, 28);
            btnCheckIn.TabIndex = 3;
            btnCheckIn.Text = "Hacer Check-in";
            btnCheckIn.UseVisualStyleBackColor = false;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(37, 99, 235);
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(10, 76);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(118, 28);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtAcompanantes
            // 
            txtAcompanantes.Location = new Point(10, 48);
            txtAcompanantes.Name = "txtAcompanantes";
            txtAcompanantes.PlaceholderText = "Acompanantes presentes";
            txtAcompanantes.Size = new Size(336, 23);
            txtAcompanantes.TabIndex = 1;
            // 
            // txtLlaves
            // 
            txtLlaves.Location = new Point(10, 20);
            txtLlaves.Name = "txtLlaves";
            txtLlaves.PlaceholderText = "Llaves magneticas (ej. LLAVE-101A)";
            txtLlaves.Size = new Size(336, 23);
            txtLlaves.TabIndex = 0;
            // 
            // lblResumenFolio
            // 
            lblResumenFolio.BackColor = Color.FromArgb(248, 250, 252);
            lblResumenFolio.BorderStyle = BorderStyle.FixedSingle;
            lblResumenFolio.Font = new Font("Consolas", 9F);
            lblResumenFolio.Location = new Point(12, 10);
            lblResumenFolio.Name = "lblResumenFolio";
            lblResumenFolio.Padding = new Padding(6);
            lblResumenFolio.Size = new Size(358, 110);
            lblResumenFolio.TabIndex = 0;
            lblResumenFolio.Text = "Seleccione una reservacion para ver su folio.";
            // 
            // FrmCheckInOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(pnlAcciones);
            Controls.Add(pnlPagos);
            Controls.Add(dgvReservas);
            Controls.Add(pnlBusqueda);
            Name = "FrmCheckInOut";
            Text = "Check-in, Check-out, Pagos y Folio";
            FormClosed += FrmCheckInOut_FormClosed;
            Load += FrmCheckInOut_Load;
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            pnlPagos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            pnlAcciones.ResumeLayout(false);
            grpCheckOut.ResumeLayout(false);
            grpCheckOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAjustes).EndInit();
            grpPago.ResumeLayout(false);
            grpPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPago).EndInit();
            grpCheckIn.ResumeLayout(false);
            grpCheckIn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBusqueda;
        private Button btnBuscar;
        private ComboBox cboFiltroEstado;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private DataGridView dgvReservas;
        private Panel pnlPagos;
        private DataGridView dgvPagos;
        private Label lblPagosTitulo;
        private Panel pnlAcciones;
        private GroupBox grpCheckOut;
        private Button btnCheckOut;
        private TextBox txtObsOut;
        private ComboBox cboComprobante;
        private NumericUpDown numAjustes;
        private Label lblObsOut;
        private Label lblComp;
        private Label lblAjustes;
        private GroupBox grpPago;
        private Button btnPagar;
        private TextBox txtRefPago;
        private ComboBox cboMetodo;
        private NumericUpDown numPago;
        private Label lblRef;
        private Label lblMetodo;
        private Label lblMonto;
        private GroupBox grpCheckIn;
        private Button btnCancelar;
        private Button btnCheckIn;
        private Button btnConfirmar;
        private TextBox txtAcompanantes;
        private TextBox txtLlaves;
        private Label lblResumenFolio;
    }
}
