using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Interfaces
{
    public interface IContratoRepositorio
    {
        Task<ContratoDTO> GetContrato(string codigo);
        Task<List<ContratoDTO>> GetContrato();
        Task<ContratoDTO> PostContrato(int idempleado,int idTipoContrato, DateOnly fechainicio, DateOnly fechafin, int salario,string codigo, string estado);
        Task<ContratoDTO> PutContrato(string codigo,DateOnly fechainicio, DateOnly fechafin, int salario);
        Task<ContratoDTO> DeleteContrato(string codigo);
    }
}
