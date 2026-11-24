namespace Hotel.WindowsForms.Views
{
    partial class FrmTipoHabitacion
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
            lblTitulo = new Label();
            dgvTipos = new DataGridView();
            pnlFormulario = new Panel();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            numPrecio = new NumericUpDown();
            numNinos = new NumericUpDown();
            numAdultos = new NumericUpDown();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            lblNinos = new Label();
            lblAdultos = new Label();
            lblDescripcion = new Label();
            lblNombre = new Label();
            lblSubtitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).BeginInit();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNinos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAdultos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitulo.Location = new Point(16, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(273, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catalogo de Tipos de Habitacion";
            // 
            // dgvTipos
            // 
            dgvTipos.AllowUserToAddRows = false;
            dgvTipos.AllowUserToDeleteRows = false;
            dgvTipos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTipos.BackgroundColor = Color.White;
            dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipos.Location = new Point(16, 52);
            dgvTipos.MultiSelect = false;
            dgvTipos.Name = "dgvTipos";
            dgvTipos.ReadOnly = true;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.Size = new Size(600, 560);
            dgvTipos.TabIndex = 1;
            dgvTipos.CellClick += dgvTipos_CellClick;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlFormulario.AutoScroll = true;
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.BorderStyle = BorderStyle.FixedSingle;
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(btnNuevo);
            pnlFormulario.Controls.Add(numPrecio);
            pnlFormulario.Controls.Add(numNinos);
            pnlFormulario.Controls.Add(numAdultos);
            pnlFormulario.Controls.Add(txtDescripcion);
            pnlFormulario.Controls.Add(txtNombre);
            pnlFormulario.Controls.Add(lblPrecio);
            pnlFormulario.Controls.Add(lblNinos);
            pnlFormulario.Controls.Add(lblAdultos);
            pnlFormulario.Controls.Add(lblDescripcion);
            pnlFormulario.Controls.Add(lblNombre);
            pnlFormulario.Controls.Add(lblSubtitulo);
            pnlFormulario.Location = new Point(630, 52);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(375, 560);
            pnlFormulario.TabIndex = 2;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 38, 38);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(256, 315);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(98, 34);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(37, 99, 235);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(132, 315);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(114, 34);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(100, 116, 139);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(20, 315);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(102, 34);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(140, 262);
            numPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrecio.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(214, 23);
            numPrecio.TabIndex = 10;
            numPrecio.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // numNinos
            // 
            numNinos.Location = new Point(140, 224);
            numNinos.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numNinos.Name = "numNinos";
            numNinos.Size = new Size(214, 23);
            numNinos.TabIndex = 9;
            // 
            // numAdultos
            // 
            numAdultos.Location = new Point(140, 186);
            numAdultos.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numAdultos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAdultos.Name = "numAdultos";
            numAdultos.Size = new Size(214, 23);
            numAdultos.TabIndex = 8;
            numAdultos.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(140, 102);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(214, 68);
            txtDescripcion.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(140, 64);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(214, 23);
            txtNombre.TabIndex = 6;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrecio.Location = new Point(20, 264);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(92, 17);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio/Noche:";
            // 
            // lblNinos
            // 
            lblNinos.AutoSize = true;
            lblNinos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNinos.Location = new Point(20, 226);
            lblNinos.Name = "lblNinos";
            lblNinos.Size = new Size(78, 17);
            lblNinos.TabIndex = 4;
            lblNinos.Text = "Cap. Ninos:";
            // 
            // lblAdultos
            // 
            lblAdultos.AutoSize = true;
            lblAdultos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAdultos.Location = new Point(20, 188);
            lblAdultos.Name = "lblAdultos";
            lblAdultos.Size = new Size(88, 17);
            lblAdultos.TabIndex = 3;
            lblAdultos.Text = "Cap. Adultos:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescripcion.Location = new Point(20, 105);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(84, 17);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripcion:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.Location = new Point(20, 67);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(62, 17);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtitulo.ForeColor = Color.FromArgb(30, 41, 59);
            lblSubtitulo.Location = new Point(20, 18);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(167, 20);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Datos del Tipo";
            // 
            // FrmTipoHabitacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 630);
            Controls.Add(pnlFormulario);
            Controls.Add(dgvTipos);
            Controls.Add(lblTitulo);
            Name = "FrmTipoHabitacion";
            Text = "Tipos de Habitacion";
            Load += FrmTipoHabitacion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTipos).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNinos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAdultos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvTipos;
        private Panel pnlFormulario;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
        private NumericUpDown numPrecio;
        private NumericUpDown numNinos;
        private NumericUpDown numAdultos;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Label lblPrecio;
        private Label lblNinos;
        private Label lblAdultos;
        private Label lblDescripcion;
        private Label lblNombre;
        private Label lblSubtitulo;
    }
}
