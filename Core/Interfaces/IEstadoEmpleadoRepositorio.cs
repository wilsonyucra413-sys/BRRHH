using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface IEstadoEmpleadoRepositorio
    {
        Task<EstadoEmpleadoDTO> GetEstadoEmpleado(string codigo);
        Task<List<EstadoEmpleadoDTO>> GetEstadoEmpleado();
        Task<EstadoEmpleadoDTO> PutEstadoEmpleado(string descripcion, string codigo);
        Task<EstadoEmpleadoDTO> PostEstadoEmpleado(string descripcion,string codigo);
        Task<EstadoEmpleadoDTO> DeleteEstadoEmpleado(string codigo);
    }
}
