using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class TipoContratoMapeador
    {
        static public TipoContratoDTO toTipoContratoDTO(this TipoContrato tipocontrato)
        {
            return new TipoContratoDTO()
            {
                Nombre = tipocontrato.Nombre,
                Descripcion = tipocontrato.Descripcion
            };
        } 
    }
}