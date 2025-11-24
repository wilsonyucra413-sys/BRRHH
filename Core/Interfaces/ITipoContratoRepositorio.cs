using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;

namespace RRHH.Core.Interfaces
{
    public interface ITipoContratoRepositorio
    {
        Task<TipoContratoDTO> GetTipoContrato(string nombre);
        Task<List<TipoContratoDTO>> GetTipoContrato();
        Task<TipoContratoDTO> PostTipoContrato(string nombre,string descripcion);
        Task<TipoContratoDTO> PutTipoContrato(string nombre, string descripcion);
        Task<TipoContratoDTO> DeleteTipoContrato(string nombre);
    }
}