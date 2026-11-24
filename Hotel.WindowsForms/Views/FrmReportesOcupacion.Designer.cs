namespace Hotel.WindowsForms.Views
{
    partial class FrmReportesOcupacion
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
            pnlFiltros = new Panel();
            btnPdf = new Button();
            btnExcel = new Button();
            btnGenerar = new Button();
            numAnio = new NumericUpDown();
            lblAnio = new Label();
            dtpFin = new DateTimePicker();
            lblHasta = new Label();
            dtpInicio = new DateTimePicker();
            lblDesde = new Label();
            pnlGrafico = new Panel();
            tabReportes = new TabControl();
            tabMensual = new TabPage();
            dgvMensual = new DataGridView();
            tabIngresos = new TabPage();
            dgvIngresos = new DataGridView();
            lblResumenIngresos = new Label();
            tabPlatillos = new TabPage();
            dgvPlatillosTop = new DataGridView();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            tabReportes.SuspendLayout();
            tabMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMensual).BeginInit();
            tabIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).BeginInit();
            tabPlatillos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillosTop).BeginInit();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Controls.Add(btnPdf);
            pnlFiltros.Controls.Add(btnExcel);
            pnlFiltros.Controls.Add(btnGenerar);
            pnlFiltros.Controls.Add(numAnio);
            pnlFiltros.Controls.Add(lblAnio);
            pnlFiltros.Controls.Add(dtpFin);
            pnlFiltros.Controls.Add(lblHasta);
            pnlFiltros.Controls.Add(dtpInicio);
            pnlFiltros.Controls.Add(lblDesde);
            pnlFiltros.Location = new Point(12, 12);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Size = new Size(1000, 48);
            pnlFiltros.TabIndex = 0;
            // 
            // btnPdf
            // 
            btnPdf.BackColor = Color.FromArgb(220, 38, 38);
            btnPdf.FlatAppearance.BorderSize = 0;
            btnPdf.FlatStyle = FlatStyle.Flat;
            btnPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPdf.ForeColor = Color.White;
            btnPdf.Location = new Point(738, 9);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(122, 30);
            btnPdf.TabIndex = 8;
            btnPdf.Text = "Exportar PDF";
            btnPdf.UseVisualStyleBackColor = false;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnExcel
            // 
            btnExcel.BackColor = Color.FromArgb(22, 163, 74);
            btnExcel.FlatAppearance.BorderSize = 0;
            btnExcel.FlatStyle = FlatStyle.Flat;
            btnExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(604, 9);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(124, 30);
            btnExcel.TabIndex = 7;
            btnExcel.Text = "Exportar Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(37, 99, 235);
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(454, 9);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(140, 30);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar Reportes";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // numAnio
            // 
            numAnio.Location = new Point(362, 12);
            numAnio.Maximum = new decimal(new int[] { 2035, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(76, 23);
            numAnio.TabIndex = 5;
            numAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(320, 15);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(34, 15);
            lblAnio.TabIndex = 4;
            lblAnio.Text = "Ano:";
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(214, 12);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(98, 23);
            dtpFin.TabIndex = 3;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(170, 15);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(62, 12);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(98, 23);
            dtpInicio.TabIndex = 1;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(12, 15);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            // 
            // pnlGrafico
            // 
            pnlGrafico.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrafico.BackColor = Color.White;
            pnlGrafico.BorderStyle = BorderStyle.FixedSingle;
            pnlGrafico.Location = new Point(12, 68);
            pnlGrafico.Name = "pnlGrafico";
            pnlGrafico.Size = new Size(1000, 220);
            pnlGrafico.TabIndex = 1;
            pnlGrafico.Paint += pnlGrafico_Paint;
            // 
            // tabReportes
            // 
            tabReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabReportes.Controls.Add(tabMensual);
            tabReportes.Controls.Add(tabIngresos);
            tabReportes.Controls.Add(tabPlatillos);
            tabReportes.Location = new Point(12, 296);
            tabReportes.Name = "tabReportes";
            tabReportes.SelectedIndex = 0;
            tabReportes.Size = new Size(1000, 330);
            tabReportes.TabIndex = 2;
            // 
            // tabMensual
            // 
            tabMensual.Controls.Add(dgvMensual);
            tabMensual.Location = new Point(4, 24);
            tabMensual.Name = "tabMensual";
            tabMensual.Padding = new Padding(3);
            tabMensual.Size = new Size(992, 302);
            tabMensual.TabIndex = 0;
            tabMensual.Text = "Ocupacion por Mes";
            tabMensual.UseVisualStyleBackColor = true;
            // 
            // dgvMensual
            // 
            dgvMensual.AllowUserToAddRows = false;
            dgvMensual.AllowUserToDeleteRows = false;
            dgvMensual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMensual.BackgroundColor = Color.White;
            dgvMensual.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMensual.Dock = DockStyle.Fill;
            dgvMensual.Location = new Point(3, 3);
            dgvMensual.MultiSelect = false;
            dgvMensual.Name = "dgvMensual";
            dgvMensual.ReadOnly = true;
            dgvMensual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMensual.Size = new Size(986, 296);
            dgvMensual.TabIndex = 0;
            // 
            // tabIngresos
            // 
            tabIngresos.Controls.Add(dgvIngresos);
            tabIngresos.Controls.Add(lblResumenIngresos);
            tabIngresos.Location = new Point(4, 24);
            tabIngresos.Name = "tabIngresos";
            tabIngresos.Padding = new Padding(3);
            tabIngresos.Size = new Size(992, 302);
            tabIngresos.TabIndex = 1;
            tabIngresos.Text = "Ingresos y Pagos Recibidos";
            tabIngresos.UseVisualStyleBackColor = true;
            // 
            // dgvIngresos
            // 
            dgvIngresos.AllowUserToAddRows = false;
            dgvIngresos.AllowUserToDeleteRows = false;
            dgvIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIngresos.BackgroundColor = Color.White;
            dgvIngresos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngresos.Dock = DockStyle.Fill;
            dgvIngresos.Location = new Point(3, 35);
            dgvIngresos.MultiSelect = false;
            dgvIngresos.Name = "dgvIngresos";
            dgvIngresos.ReadOnly = true;
            dgvIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngresos.Size = new Size(986, 264);
            dgvIngresos.TabIndex = 1;
            // 
            // lblResumenIngresos
            // 
            lblResumenIngresos.Dock = DockStyle.Top;
            lblResumenIngresos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResumenIngresos.Location = new Point(3, 3);
            lblResumenIngresos.Name = "lblResumenIngresos";
            lblResumenIngresos.Padding = new Padding(6, 6, 6, 0);
            lblResumenIngresos.Size = new Size(986, 32);
            lblResumenIngresos.TabIndex = 0;
            lblResumenIngresos.Text = "Resumen de ingresos";
            // 
            // tabPlatillos
            // 
            tabPlatillos.Controls.Add(dgvPlatillosTop);
            tabPlatillos.Location = new Point(4, 24);
            tabPlatillos.Name = "tabPlatillos";
            tabPlatillos.Padding = new Padding(3);
            tabPlatillos.Size = new Size(992, 302);
            tabPlatillos.TabIndex = 2;
            tabPlatillos.Text = "Platillos Mas Solicitados";
            tabPlatillos.UseVisualStyleBackColor = true;
            // 
            // dgvPlatillosTop
            // 
            dgvPlatillosTop.AllowUserToAddRows = false;
            dgvPlatillosTop.AllowUserToDeleteRows = false;
            dgvPlatillosTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlatillosTop.BackgroundColor = Color.White;
            dgvPlatillosTop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatillosTop.Dock = DockStyle.Fill;
            dgvPlatillosTop.Location = new Point(3, 3);
            dgvPlatillosTop.MultiSelect = false;
            dgvPlatillosTop.Name = "dgvPlatillosTop";
            dgvPlatillosTop.ReadOnly = true;
            dgvPlatillosTop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatillosTop.Size = new Size(986, 296);
            dgvPlatillosTop.TabIndex = 0;
            // 
            // FrmReportesOcupacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(tabReportes);
            Controls.Add(pnlGrafico);
            Controls.Add(pnlFiltros);
            Name = "FrmReportesOcupacion";
            Text = "Reportes Gerenciales y Exportacion";
            Load += FrmReportesOcupacion_Load;
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            tabReportes.ResumeLayout(false);
            tabMensual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMensual).EndInit();
            tabIngresos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIngresos).EndInit();
            tabPlatillos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlatillosTop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFiltros;
        private Button btnPdf;
        private Button btnExcel;
        private Button btnGenerar;
        private NumericUpDown numAnio;
        private Label lblAnio;
        private DateTimePicker dtpFin;
        private Label lblHasta;
        private DateTimePicker dtpInicio;
        private Label lblDesde;
        private Panel pnlGrafico;
        private TabControl tabReportes;
        private TabPage tabMensual;
        private DataGridView dgvMensual;
        private TabPage tabIngresos;
        private DataGridView dgvIngresos;
        private Label lblResumenIngresos;
        private TabPage tabPlatillos;
        private DataGridView dgvPlatillosTop;
    }
}
