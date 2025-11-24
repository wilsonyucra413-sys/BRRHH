using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface IDepartamentoEmpresaRepositorio
    {
        Task<DepartamentoEmpresaDTO> GetDeparatamentoEmpresa(string codigo);
        Task<List<DepartamentoEmpresaDTO>> GetDeparatamentoEmpresa();
        Task<DepartamentoEmpresaDTO> PostDeparatamentoEmpresa(string nombre,string codigo);
        Task<DepartamentoEmpresaDTO> PutDeparatamentoEmpresa(string nombre, string codigo,string nuevocodigo);
        Task<DepartamentoEmpresaDTO> DeleteDeparatamentoEmpresa(string codigo);
    }
}
