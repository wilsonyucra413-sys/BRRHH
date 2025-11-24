using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface IAsistenciaRepositorio
    {
        Task<AsistenciaDTO> GetAsistencia(string codigo);
        Task<List<AsistenciaDTO>> GetAsistencia();
        Task<AsistenciaDTO> PostAsistencia(int idempleado, DateOnly fecha, TimeOnly horaentrada,TimeOnly horasalida, string codigo, string estado);
        Task<AsistenciaDTO> PutAsistencia(string codigo,DateOnly fecha, TimeOnly horaentrada, TimeOnly horasalida);
        Task<AsistenciaDTO> DeleteAsistencia(string codigo);
    }
   
}
