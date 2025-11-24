using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface IPuestoRepositorio
    {
        Task<PuestoDTO> GetPuesto(string codigo);
        Task<List<PuestoDTO>> GetPuesto();
        Task<PuestoDTO> PostPuesto (string nombre, int salario,string codigo);
        Task<PuestoDTO> PutPuesto (string nombre, int salario , string codigo);
        Task<PuestoDTO> DeletePuesto (string codigo);
    }
}