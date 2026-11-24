namespace Hotel.Dominio.ReglasNegocio
{
    /// <summary>
    /// Value Object para representar un intervalo semiabierto [FechaInicio, FechaFin).
    /// Una salida el mismo día de la siguiente entrada no constituye traslape.
    /// </summary>
    public sealed class RangoFechas
    {
        public DateOnly FechaInicio { get; }
        public DateOnly FechaFin { get; }

        public RangoFechas(DateOnly fechaInicio, DateOnly fechaFin)
        {
            if (fechaInicio >= fechaFin)
                throw new ArgumentException("La fecha de entrada debe ser anterior a la fecha de salida.");

            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public int Noches => FechaFin.DayNumber - FechaInicio.DayNumber;

        /// <summary>
        /// Regla del proyecto: nuevaEntrada &lt; salidaExistente &amp;&amp; nuevaSalida &gt; entradaExistente
        /// </summary>
        public bool SeTraslapaCon(RangoFechas otro) =>
            FechaInicio < otro.FechaFin && FechaFin > otro.FechaInicio;

        public static bool HayTraslape(DateOnly nuevaEntrada, DateOnly nuevaSalida, DateOnly entradaExistente, DateOnly salidaExistente) =>
            nuevaEntrada < salidaExistente && nuevaSalida > entradaExistente;
    }
}
