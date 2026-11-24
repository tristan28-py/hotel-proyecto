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
            grid.ColumnHeadersHeight = 36;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 249, 246);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(237, 227, 207);
            grid.DefaultCellStyle.SelectionForeColor = TextoOscuro;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            grid.RowTemplate.Height = 32;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
