using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface IEmpleadoRepositorio
    {
        Task<EmpleadoDTO> GetEmpleado(string codigo);
        Task<List<EmpleadoDTO>> GetEmpleado();
        Task<EmpleadoDTO> PostEmpleado(string persona, string departamentoempresa,string puesto,string estadoempleado,DateOnly fechaingreso,string sucursal,string codigo);
        Task<EmpleadoDTO> PutEmpleado(string codigo ,DateOnly fechaingreso,string sucursal);
        Task<EmpleadoDTO> DeleteEmpleado(string codigo);
    }
}
