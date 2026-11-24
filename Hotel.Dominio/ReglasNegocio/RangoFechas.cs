namespace Hotel.Dominio.ReglasNegocio
{
    // Intervalo [FechaInicio, FechaFin) donde una salida el mismo dia de la entrada no traslapa
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

        // Regla: nuevaEntrada < salidaExistente && nuevaSalida > entradaExistente
        public bool SeTraslapaCon(RangoFechas otro) =>
            FechaInicio < otro.FechaFin && FechaFin > otro.FechaInicio;

        public static bool HayTraslape(DateOnly nuevaEntrada, DateOnly nuevaSalida, DateOnly entradaExistente, DateOnly salidaExistente) =>
            nuevaEntrada < salidaExistente && nuevaSalida > entradaExistente;
    }
}
