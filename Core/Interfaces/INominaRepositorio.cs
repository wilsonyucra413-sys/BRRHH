using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface INominaRepositorio
    {
        Task<NominaDTO> GetNomina(string codigo);
        Task<List<NominaDTO>> GetNomina();
        Task<NominaDTO> PutNomina(DateOnly periodoinicio,DateOnly periodofin,int total,int totaldescuento,string codigo);
        Task<NominaDTO> PostNomina(string empleado,DateOnly periodoinicio,DateOnly periodofin,int total,int totaldescuento,string codigo);
        Task<NominaDTO> DeleteNomina(string codigo);
    }
}