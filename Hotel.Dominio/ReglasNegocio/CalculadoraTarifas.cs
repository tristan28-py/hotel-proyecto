namespace Hotel.Dominio.ReglasNegocio
{
    public sealed class ResultadoCalculoTarifa
    {
        public int Noches { get; init; }
        public decimal TarifaBasePorNoche { get; init; }
        public decimal FactorTemporadaPromedio { get; init; }
        public decimal SubtotalHospedaje { get; init; }
        public decimal RecargoTemporada { get; init; }
        public decimal RecargoPersonasExtra { get; init; }
        public decimal DescuentoCliente { get; init; }
        public decimal BaseImponible { get; init; }
        public decimal PorcentajeIva { get; init; }
        public decimal Impuestos { get; init; }
        public decimal CostoTotal { get; init; }
        public decimal MontoAnticipoRequerido { get; init; }
        public string DetalleTemporada { get; init; } = string.Empty;
    }

    // Calculo de tarifa: (Noches * TarifaBase * FactorTemporada) + RecargoPersonasExtra - DescuentoCliente + IVA
    public static class CalculadoraTarifas
    {
        public const decimal PorcentajeAnticipoDefault = 0.30m;
        public const decimal PorcentajeIvaDefault = 0.16m;
        public const decimal RecargoPorPersonaExtraNoche = 25.00m;
        public const decimal DescuentoClienteFrecuentePct = 0.10m;

        public static ResultadoCalculoTarifa Calcular(
            DateOnly fechaInicio,
            DateOnly fechaFin,
            decimal tarifaBaseNoche,
            int capacidadBaseAdultos,
            int cantidadHuespedes,
            bool esClienteFrecuente,
            decimal porcentajeIva = PorcentajeIvaDefault)
        {
            var rango = new RangoFechas(fechaInicio, fechaFin);
            int noches = rango.Noches;

            decimal subtotalBase = Math.Round(noches * tarifaBaseNoche, 2);
            decimal recargoTemporadaTotal = 0m;
            bool tuvoFinSemana = false;
            bool tuvoTemporadaAlta = false;

            for (int i = 0; i < noches; i++)
            {
                DateOnly dia = fechaInicio.AddDays(i);
                decimal factor = ObtenerFactorDia(dia, out bool finSemana, out bool temporadaAlta);
                tuvoFinSemana |= finSemana;
                tuvoTemporadaAlta |= temporadaAlta;
                recargoTemporadaTotal += tarifaBaseNoche * (factor - 1.00m);
            }

            recargoTemporadaTotal = Math.Round(recargoTemporadaTotal, 2);

            int personasExtra = Math.Max(0, cantidadHuespedes - capacidadBaseAdultos);
            decimal recargoPersonasExtra = Math.Round(personasExtra * RecargoPorPersonaExtraNoche * noches, 2);

            decimal brutoAntesDescuento = subtotalBase + recargoTemporadaTotal + recargoPersonasExtra;
            decimal descuentoCliente = esClienteFrecuente
                ? Math.Round(subtotalBase * DescuentoClienteFrecuentePct, 2)
                : 0m;

            decimal baseImponible = Math.Max(0m, Math.Round(brutoAntesDescuento - descuentoCliente, 2));
            decimal impuestos = Math.Round(baseImponible * porcentajeIva, 2);
            decimal costoTotal = Math.Round(baseImponible + impuestos, 2);
            decimal anticipo = Math.Round(costoTotal * PorcentajeAnticipoDefault, 2);

            string detalle = (tuvoTemporadaAlta, tuvoFinSemana) switch
            {
                (true, true) => "Temporada Alta (+25%) y Fin de Semana (+15%)",
                (true, false) => "Temporada Alta (+25%)",
                (false, true) => "Fin de Semana Vie/Sab (+15%)",
                _ => "Temporada Regular"
            };

            return new ResultadoCalculoTarifa
            {
                Noches = noches,
                TarifaBasePorNoche = tarifaBaseNoche,
                FactorTemporadaPromedio = subtotalBase > 0 ? Math.Round((subtotalBase + recargoTemporadaTotal) / subtotalBase, 4) : 1m,
                SubtotalHospedaje = subtotalBase,
                RecargoTemporada = recargoTemporadaTotal,
                RecargoPersonasExtra = recargoPersonasExtra,
                DescuentoCliente = descuentoCliente,
                BaseImponible = baseImponible,
                PorcentajeIva = porcentajeIva,
                Impuestos = impuestos,
                CostoTotal = costoTotal,
                MontoAnticipoRequerido = anticipo,
                DetalleTemporada = detalle
            };
        }

        private static decimal ObtenerFactorDia(DateOnly dia, out bool esFinSemana, out bool esTemporadaAlta)
        {
            esFinSemana = dia.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday;
            esTemporadaAlta =
                (dia.Month == 12 && dia.Day >= 15) ||
                (dia.Month == 1 && dia.Day <= 10) ||
                (dia.Month == 4 && dia.Day <= 15) ||
                (dia.Month == 7);

            decimal factor = 1.00m;
            if (esTemporadaAlta) factor += 0.25m;
            if (esFinSemana) factor += 0.15m;
            return factor;
        }
    }
}
