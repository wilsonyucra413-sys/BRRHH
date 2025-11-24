namespace RRHH.Core.DTOs
{
    public class AsistenciaDTO
    {
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }
    }
}
