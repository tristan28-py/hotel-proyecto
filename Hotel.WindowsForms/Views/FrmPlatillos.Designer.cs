namespace Hotel.WindowsForms.Views
{
    partial class FrmPlatillos
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
            dgvPlatillos = new DataGridView();
            pnlDerecho = new Panel();
            btnDesactivar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            chkDisponible = new CheckBox();
            numTiempo = new NumericUpDown();
            numPrecio = new NumericUpDown();
            txtDesc = new TextBox();
            txtNombre = new TextBox();
            cboCategoria = new ComboBox();
            lblEstado = new Label();
            lblTiempo = new Label();
            lblPrecio = new Label();
            lblDesc = new Label();
            lblNombre = new Label();
            lblCategoria = new Label();
            grpCategoria = new GroupBox();
            btnAddCat = new Button();
            txtNuevaCat = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).BeginInit();
            pnlDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTiempo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            grpCategoria.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPlatillos
            // 
            dgvPlatillos.AllowUserToAddRows = false;
            dgvPlatillos.AllowUserToDeleteRows = false;
            dgvPlatillos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPlatillos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlatillos.BackgroundColor = Color.White;
            dgvPlatillos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatillos.Location = new Point(14, 14);
            dgvPlatillos.MultiSelect = false;
            dgvPlatillos.Name = "dgvPlatillos";
            dgvPlatillos.ReadOnly = true;
            dgvPlatillos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatillos.Size = new Size(600, 610);
            dgvPlatillos.TabIndex = 0;
            dgvPlatillos.CellClick += dgvPlatillos_CellClick;
            // 
            // pnlDerecho
            // 
            pnlDerecho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlDerecho.BackColor = Color.White;
            pnlDerecho.BorderStyle = BorderStyle.FixedSingle;
            pnlDerecho.Controls.Add(btnDesactivar);
            pnlDerecho.Controls.Add(btnGuardar);
            pnlDerecho.Controls.Add(btnNuevo);
            pnlDerecho.Controls.Add(chkDisponible);
            pnlDerecho.Controls.Add(numTiempo);
            pnlDerecho.Controls.Add(numPrecio);
            pnlDerecho.Controls.Add(txtDesc);
            pnlDerecho.Controls.Add(txtNombre);
            pnlDerecho.Controls.Add(cboCategoria);
            pnlDerecho.Controls.Add(lblEstado);
            pnlDerecho.Controls.Add(lblTiempo);
            pnlDerecho.Controls.Add(lblPrecio);
            pnlDerecho.Controls.Add(lblDesc);
            pnlDerecho.Controls.Add(lblNombre);
            pnlDerecho.Controls.Add(lblCategoria);
            pnlDerecho.Controls.Add(grpCategoria);
            pnlDerecho.Location = new Point(628, 14);
            pnlDerecho.Name = "pnlDerecho";
            pnlDerecho.Size = new Size(382, 610);
            pnlDerecho.TabIndex = 1;
            // 
            // btnDesactivar
            // 
            btnDesactivar.BackColor = Color.FromArgb(220, 38, 38);
            btnDesactivar.FlatAppearance.BorderSize = 0;
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDesactivar.ForeColor = Color.White;
            btnDesactivar.Location = new Point(264, 378);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(100, 34);
            btnDesactivar.TabIndex = 15;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(22, 163, 74);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(118, 378);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(136, 34);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar Platillo";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(100, 116, 139);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(16, 378);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(92, 34);
            btnNuevo.TabIndex = 13;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Location = new Point(122, 332);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(161, 19);
            chkDisponible.TabIndex = 12;
            chkDisponible.Text = "Disponible para pedidos";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // numTiempo
            // 
            numTiempo.Location = new Point(122, 294);
            numTiempo.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numTiempo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTiempo.Name = "numTiempo";
            numTiempo.Size = new Size(242, 23);
            numTiempo.TabIndex = 11;
            numTiempo.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(122, 256);
            numPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrecio.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(242, 23);
            numPrecio.TabIndex = 10;
            numPrecio.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(122, 182);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(242, 60);
            txtDesc.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(122, 144);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(242, 23);
            txtNombre.TabIndex = 8;
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(122, 106);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(242, 23);
            cboCategoria.TabIndex = 7;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.Location = new Point(16, 333);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(49, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTiempo.Location = new Point(16, 296);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(76, 15);
            lblTiempo.TabIndex = 5;
            lblTiempo.Text = "Prep. (min):";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrecio.Location = new Point(16, 258);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(46, 15);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio:";
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesc.Location = new Point(16, 185);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(78, 15);
            lblDesc.TabIndex = 3;
            lblDesc.Text = "Descripcion:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.Location = new Point(16, 147);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(58, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategoria.Location = new Point(16, 109);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(66, 15);
            lblCategoria.TabIndex = 1;
            lblCategoria.Text = "Categoria:";
            // 
            // grpCategoria
            // 
            grpCategoria.Controls.Add(btnAddCat);
            grpCategoria.Controls.Add(txtNuevaCat);
            grpCategoria.Location = new Point(16, 16);
            grpCategoria.Name = "grpCategoria";
            grpCategoria.Size = new Size(348, 72);
            grpCategoria.TabIndex = 0;
            grpCategoria.TabStop = false;
            grpCategoria.Text = "Agregar Categoria de Menu";
            // 
            // btnAddCat
            // 
            btnAddCat.BackColor = Color.FromArgb(37, 99, 235);
            btnAddCat.FlatAppearance.BorderSize = 0;
            btnAddCat.FlatStyle = FlatStyle.Flat;
            btnAddCat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddCat.ForeColor = Color.White;
            btnAddCat.Location = new Point(242, 26);
            btnAddCat.Name = "btnAddCat";
            btnAddCat.Size = new Size(94, 28);
            btnAddCat.TabIndex = 1;
            btnAddCat.Text = "Agregar";
            btnAddCat.UseVisualStyleBackColor = false;
            btnAddCat.Click += btnAddCat_Click;
            // 
            // txtNuevaCat
            // 
            txtNuevaCat.Location = new Point(12, 28);
            txtNuevaCat.Name = "txtNuevaCat";
            txtNuevaCat.PlaceholderText = "Nombre de categoria";
            txtNuevaCat.Size = new Size(220, 23);
            txtNuevaCat.TabIndex = 0;
            // 
            // FrmPlatillos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 246, 250);
            ClientSize = new Size(1024, 638);
            Controls.Add(pnlDerecho);
            Controls.Add(dgvPlatillos);
            Name = "FrmPlatillos";
            Text = "Mantenimiento de Categorias y Platillos";
            Load += FrmPlatillos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).EndInit();
            pnlDerecho.ResumeLayout(false);
            pnlDerecho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTiempo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            grpCategoria.ResumeLayout(false);
            grpCategoria.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPlatillos;
        private Panel pnlDerecho;
        private Button btnDesactivar;
        private Button btnGuardar;
        private Button btnNuevo;
        private CheckBox chkDisponible;
        private NumericUpDown numTiempo;
        private NumericUpDown numPrecio;
        private TextBox txtDesc;
        private TextBox txtNombre;
        private ComboBox cboCategoria;
        private Label lblEstado;
        private Label lblTiempo;
        private Label lblPrecio;
        private Label lblDesc;
        private Label lblNombre;
        private Label lblCategoria;
        private GroupBox grpCategoria;
        private Button btnAddCat;
        private TextBox txtNuevaCat;
    }
}
