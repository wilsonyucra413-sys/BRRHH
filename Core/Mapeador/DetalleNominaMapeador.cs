using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class DetalleNominaMapeador
    {
        public static DetalleNominaDTO toDetalleNominaDTO(this DetalleNomina detallenomina)
        {
            return new DetalleNominaDTO()
            {
                Concepto = detallenomina.Concepto,
                Monto = detallenomina.Monto,
                Tipo = detallenomina.Tipo
            };
        }
    }
}