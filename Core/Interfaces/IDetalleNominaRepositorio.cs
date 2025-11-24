using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface IDetalleNominaRepositorio
    {
        Task<DetalleNominaDTO> GetDetalleNomina(string tipo);
        Task<List<DetalleNominaDTO>> GetDetalleNomina();
        Task<DetalleNominaDTO> PostDetalleNomina(int idnomina,string concepto,int monto, string tipo,string estado);
        Task<DetalleNominaDTO> PutDetalleNomina(string tipo,string concepto,int monto);
        Task<DetalleNominaDTO> DeleteDetalleNomina(string tipo);
    }
}
