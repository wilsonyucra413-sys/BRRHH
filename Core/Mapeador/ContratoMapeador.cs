using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class ContratoMapeador
    {
        public static ContratoDTO toContratoDTO (this Contrato contrato)
        {
            return new ContratoDTO()
            {
                FechaInicio = contrato.FechaInicio,
                FechaFin = contrato.FechaFin,
                Salario = contrato.Salario
            };
        }
    }
}