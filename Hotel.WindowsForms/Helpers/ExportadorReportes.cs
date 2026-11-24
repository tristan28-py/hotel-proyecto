using ClosedXML.Excel;
using Hotel.WindowsForms.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Hotel.WindowsForms.Helpers
{
    public static class ExportadorReportes
    {
        static ExportadorReportes()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static void ExportarExcel(
            string rutaArchivo,
            List<ResumenMensualOcupacionModel> mensual,
            ReporteIngresosModel? ingresos,
            List<PlatilloMasSolicitadoModel> platillosTop)
        {
            using var wb = new XLWorkbook();

            var wsMensual = wb.Worksheets.Add("Ocupación Mensual");
            wsMensual.Cell(1, 1).Value = "Año";
            wsMensual.Cell(1, 2).Value = "Mes";
            wsMensual.Cell(1, 3).Value = "Reservaciones";
            wsMensual.Cell(1, 4).Value = "Total Facturado";
            wsMensual.Row(1).Style.Font.Bold = true;

            for (int i = 0; i < mensual.Count; i++)
            {
                var r = mensual[i];
                wsMensual.Cell(i + 2, 1).Value = r.Anio;
                wsMensual.Cell(i + 2, 2).Value = r.MesNombre;
                wsMensual.Cell(i + 2, 3).Value = r.CantidadReservaciones;
                wsMensual.Cell(i + 2, 4).Value = r.TotalFacturado;
                wsMensual.Cell(i + 2, 4).Style.NumberFormat.Format = "$#,##0.00";
            }
            wsMensual.Columns().AdjustToContents();

            if (ingresos != null)
            {
                var wsIng = wb.Worksheets.Add("Ingresos y Pagos");
                wsIng.Cell(1, 1).Value = "Período";
                wsIng.Cell(1, 2).Value = $"{ingresos.FechaInicio:yyyy-MM-dd} al {ingresos.FechaFin:yyyy-MM-dd}";
                wsIng.Cell(2, 1).Value = "Total Pagos Recibidos";
                wsIng.Cell(2, 2).Value = ingresos.TotalPagosRecibidos;
                wsIng.Cell(3, 1).Value = "Total Hospedaje Proyectado";
                wsIng.Cell(3, 2).Value = ingresos.TotalHospedajeProyectado;
                wsIng.Cell(4, 1).Value = "Total Consumos Restaurante";
                wsIng.Cell(4, 2).Value = ingresos.TotalConsumosRestaurante;

                wsIng.Cell(6, 1).Value = "Fecha Pago";
                wsIng.Cell(6, 2).Value = "Reserva";
                wsIng.Cell(6, 3).Value = "Método";
                wsIng.Cell(6, 4).Value = "Comprobante";
                wsIng.Cell(6, 5).Value = "Monto";
                wsIng.Row(6).Style.Font.Bold = true;

                for (int i = 0; i < ingresos.DetallePagos.Count; i++)
                {
                    var p = ingresos.DetallePagos[i];
                    wsIng.Cell(i + 7, 1).Value = p.FechaPago.ToLocalTime().ToString("yyyy-MM-dd HH:mm");
                    wsIng.Cell(i + 7, 2).Value = p.CodigoReservacion ?? "-";
                    wsIng.Cell(i + 7, 3).Value = p.MetodoPago;
                    wsIng.Cell(i + 7, 4).Value = $"{p.TipoComprobante} {p.NumeroComprobante}";
                    wsIng.Cell(i + 7, 5).Value = p.Monto;
                    wsIng.Cell(i + 7, 5).Style.NumberFormat.Format = "$#,##0.00";
                }
                wsIng.Columns().AdjustToContents();
            }

            var wsPlat = wb.Worksheets.Add("Platillos Top");
            wsPlat.Cell(1, 1).Value = "Platillo";
            wsPlat.Cell(1, 2).Value = "Categoría";
            wsPlat.Cell(1, 3).Value = "Cantidad";
            wsPlat.Cell(1, 4).Value = "Monto Generado";
            wsPlat.Row(1).Style.Font.Bold = true;

            for (int i = 0; i < platillosTop.Count; i++)
            {
                var p = platillosTop[i];
                wsPlat.Cell(i + 2, 1).Value = p.Nombre;
                wsPlat.Cell(i + 2, 2).Value = p.Categoria;
                wsPlat.Cell(i + 2, 3).Value = p.CantidadTotalSolicitada;
                wsPlat.Cell(i + 2, 4).Value = p.MontoTotalGenerado;
                wsPlat.Cell(i + 2, 4).Style.NumberFormat.Format = "$#,##0.00";
            }
            wsPlat.Columns().AdjustToContents();

            wb.SaveAs(rutaArchivo);
        }

        public static void ExportarPdf(
            string rutaArchivo,
            List<ResumenMensualOcupacionModel> mensual,
            ReporteIngresosModel? ingresos,
            List<PlatilloMasSolicitadoModel> platillosTop)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("SISTEMA DE GESTIÓN HOTELERA - REPORTE EJECUTIVO")
                            .FontSize(15).Bold().FontColor(Colors.Blue.Darken3);
                        col.Item().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .FontSize(9).FontColor(Colors.Grey.Darken1);
                    });

                    page.Content().PaddingVertical(12).Column(col =>
                    {
                        col.Spacing(14);

                        if (ingresos != null)
                        {
                            col.Item().Text($"Resumen de Ingresos ({ingresos.FechaInicio:dd/MM/yyyy} - {ingresos.FechaFin:dd/MM/yyyy})")
                                .FontSize(12).Bold();
                            col.Item().Text($"• Pagos recibidos: {ingresos.TotalPagosRecibidos:C2} ({ingresos.CantidadTransacciones} transacciones)");
                            col.Item().Text($"• Hospedaje proyectado: {ingresos.TotalHospedajeProyectado:C2}");
                            col.Item().Text($"• Consumos restaurante: {ingresos.TotalConsumosRestaurante:C2}");
                        }

                        col.Item().Text("Ocupación Mensual").FontSize(12).Bold();
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn();
                                c.RelativeColumn(2);
                                c.RelativeColumn();
                                c.RelativeColumn();
                            });
                            table.Header(h =>
                            {
                                h.Cell().Text("Año").Bold();
                                h.Cell().Text("Mes").Bold();
                                h.Cell().Text("Reservas").Bold();
                                h.Cell().Text("Facturado").Bold();
                            });
                            foreach (var m in mensual)
                            {
                                table.Cell().Text(m.Anio.ToString());
                                table.Cell().Text(m.MesNombre);
                                table.Cell().Text(m.CantidadReservaciones.ToString());
                                table.Cell().Text(m.TotalFacturado.ToString("C2"));
                            }
                        });

                        col.Item().Text("Platillos Más Solicitados").FontSize(12).Bold();
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(2);
                                c.RelativeColumn();
                                c.RelativeColumn();
                                c.RelativeColumn();
                            });
                            table.Header(h =>
                            {
                                h.Cell().Text("Platillo").Bold();
                                h.Cell().Text("Categoría").Bold();
                                h.Cell().Text("Cantidad").Bold();
                                h.Cell().Text("Total").Bold();
                            });
                            foreach (var p in platillosTop)
                            {
                                table.Cell().Text(p.Nombre);
                                table.Cell().Text(p.Categoria);
                                table.Cell().Text(p.CantidadTotalSolicitada.ToString());
                                table.Cell().Text(p.MontoTotalGenerado.ToString("C2"));
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                    });
                });
            }).GeneratePdf(rutaArchivo);
        }

        public static void ExportarFacturaCheckOutPdf(string rutaArchivo, EstadoCuentaModel cuenta)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(35);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header().Column(col =>
                    {
                        col.Item().Text("COMPROBANTE / FACTURA DE ESTADÍA").FontSize(16).Bold().FontColor(Colors.Blue.Darken3);
                        col.Item().Text($"Reserva: {cuenta.Codigo} | Habitación: {cuenta.HabitacionNumero} | Huésped: {cuenta.ClienteNombre}");
                        col.Item().Text($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9).FontColor(Colors.Grey.Darken1);
                    });

                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        col.Spacing(10);
                        col.Item().Text("Desglose de Cargos").FontSize(12).Bold();
                        col.Item().Text($"• Hospedaje (incluye impuestos/temporada): {cuenta.CostoHospedaje:C2}");
                        col.Item().Text($"• Consumos de Restaurante / Room Service: {cuenta.TotalRestaurante:C2}");
                        col.Item().Text($"• Ajustes Check-out: {cuenta.AjustesCheckOut:C2}");
                        col.Item().Text($"• Total General: {cuenta.TotalGeneral:C2}").Bold();
                        col.Item().Text($"• Total Pagado: {cuenta.TotalPagado:C2}");
                        col.Item().Text($"• Saldo Pendiente: {cuenta.SaldoPendiente:C2}").Bold();

                        if (cuenta.Pagos.Count > 0)
                        {
                            col.Item().PaddingTop(8).Text("Historial de Pagos").FontSize(11).Bold();
                            foreach (var p in cuenta.Pagos)
                            {
                                col.Item().Text($"  - {p.FechaPago.ToLocalTime():dd/MM/yyyy HH:mm} | {p.MetodoPago} | {p.TipoComprobante} {p.NumeroComprobante} | {p.Monto:C2}");
                            }
                        }
                    });
                });
            }).GeneratePdf(rutaArchivo);
        }
    }
}
