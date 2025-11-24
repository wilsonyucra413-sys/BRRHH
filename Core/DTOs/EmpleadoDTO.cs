namespace RRHH.Core.DTOs
{
    public class EmpleadoDTO
    {
        public string Persona { get; set; }
        public string DepartamentoEmpresa { get; set; }
        public string Puesto { get; set; }
        public string EstadoEmpleado { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public string Sucursal { get; set; }
        public string Codigo {get; set;}
    }
}
