namespace Hotel.WindowsForms.Helpers
{
    public static class UiTheme
    {
        public static readonly Color FondoPrincipal = Color.FromArgb(243, 246, 250);
        public static readonly Color SidebarFondo = Color.FromArgb(18, 32, 54);
        public static readonly Color SidebarHover = Color.FromArgb(30, 52, 84);
        public static readonly Color SidebarActivo = Color.FromArgb(37, 99, 235);
        public static readonly Color Primario = Color.FromArgb(37, 99, 235);
        public static readonly Color TextoOscuro = Color.FromArgb(30, 41, 59);
        public static readonly Color TextoSuave = Color.FromArgb(100, 116, 139);
        public static readonly Color Blanco = Color.White;

        // Colores oficiales de estado de habitación del PDF
        public static Color ColorEstadoHabitacion(string estado) => estado switch
        {
            "Disponible" => Color.FromArgb(22, 163, 74),      // Verde
            "Ocupada" => Color.FromArgb(220, 38, 38),         // Rojo
            "EnLimpieza" => Color.FromArgb(234, 179, 8),      // Amarillo
            "Reservada" => Color.FromArgb(37, 99, 235),       // Azul
            _ => Color.FromArgb(107, 114, 128)                // Gris (Mantenimiento / Bloqueada)
        };

        public static void EstilizarBoton(Button btn, Color fondo, Color? texto = null)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto ?? Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        }

        public static void EstilizarGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextoOscuro;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            grid.ColumnHeadersHeight = 36;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = TextoOscuro;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            grid.RowTemplate.Height = 30;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
