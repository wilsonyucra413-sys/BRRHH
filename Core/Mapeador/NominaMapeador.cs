using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class NominaMapeador
    {
        public static NominaDTO toNominaDTO(this Nomina nomina,string empleado)
        {
            return new NominaDTO()
            {
                Empleado=empleado,
                Total = nomina.Total,
                TotalDescuento = nomina.TotalDescuento,
                TotalNeto = nomina.TotalNeto
            };
        }
    }
}