using System.Drawing.Drawing2D;

namespace Hotel.WindowsForms.Helpers
{
    public static class UiTheme
    {
        public static readonly Color FondoPrincipal = Color.FromArgb(247, 245, 240);
        public static readonly Color SidebarFondo = Color.FromArgb(15, 30, 54);
        public static readonly Color SidebarHover = Color.FromArgb(26, 49, 84);
        public static readonly Color DoradoHotel = Color.FromArgb(200, 157, 84);
        public static readonly Color Primario = Color.FromArgb(30, 64, 175);
        public static readonly Color BordeSuave = Color.FromArgb(229, 224, 216);
        public static readonly Color TextoOscuro = Color.FromArgb(30, 41, 59);
        public static readonly Color TextoSuave = Color.FromArgb(100, 116, 139);
        public static readonly Color Blanco = Color.White;

        public static Color ColorEstadoHabitacion(string estado) => estado switch
        {
            "Disponible" => Color.FromArgb(21, 128, 61),
            "Ocupada" => Color.FromArgb(185, 28, 28),
            "EnLimpieza" => Color.FromArgb(217, 119, 6),
            "Reservada" => Color.FromArgb(29, 78, 216),
            _ => Color.FromArgb(75, 85, 99)
        };

        public static void EstilizarBoton(Button btn, Color fondo, Color? texto = null)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto ?? Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        }

        public static void EstilizarGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = BordeSuave;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = SidebarFondo;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            grid.ColumnHeadersHeight = 38;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 249, 246);
            grid.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(237, 227, 207);
            grid.DefaultCellStyle.SelectionForeColor = TextoOscuro;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            grid.RowTemplate.Height = 34;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public static void ConfigurarColumnas(
            DataGridView grid,
            params (string Propiedad, string Titulo, float Peso, int MinAncho, string? Formato)[] columnas)
        {
            EstilizarGrid(grid);
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();

            foreach (var col in columnas)
            {
                var c = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = col.Propiedad,
                    Name = col.Propiedad,
                    HeaderText = col.Titulo,
                    FillWeight = col.Peso,
                    MinimumWidth = col.MinAncho
                };
                if (!string.IsNullOrEmpty(col.Formato))
                    c.DefaultCellStyle.Format = col.Formato;
                grid.Columns.Add(c);
            }

            grid.CellFormatting -= Grid_EstadoCellFormatting;
            grid.CellFormatting += Grid_EstadoCellFormatting;
        }

        private static void Grid_EstadoCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView grid || e.Value == null) return;
            string colName = grid.Columns[e.ColumnIndex].DataPropertyName;
            if (colName is not ("Estado" or "EstadoOperativo" or "EstadoPedido")) return;

            string val = e.Value.ToString() ?? string.Empty;
            (Color fondo, Color texto) = val switch
            {
                "Disponible" or "Confirmada" or "Entregado" or "Completada" =>
                    (Color.FromArgb(220, 252, 231), Color.FromArgb(22, 101, 52)),
                "Ocupada" or "Cancelada" or "Cancelado" =>
                    (Color.FromArgb(254, 226, 226), Color.FromArgb(153, 27, 27)),
                "EnLimpieza" or "PendientePago" or "Recibido" or "EnCocina" =>
                    (Color.FromArgb(254, 243, 199), Color.FromArgb(146, 64, 14)),
                "Reservada" or "EnCurso" or "EnCamino" =>
                    (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175)),
                _ => (Color.FromArgb(241, 245, 249), Color.FromArgb(71, 85, 105))
            };

            if (e.CellStyle != null)
            {
                e.CellStyle.BackColor = fondo;
                e.CellStyle.ForeColor = texto;
                e.CellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            }
        }

        public static void AplicarBordeRedondeado(Control ctrl, int radio = 10)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = new GraphicsPath();
            int d = radio * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(ctrl.Width - d, 0, d, d, 270, 90);
            path.AddArc(ctrl.Width - d, ctrl.Height - d, d, d, 0, 90);
            path.AddArc(0, ctrl.Height - d, d, d, 90, 90);
            path.CloseFigure();
            ctrl.Region = new Region(path);
        }
    }
}
