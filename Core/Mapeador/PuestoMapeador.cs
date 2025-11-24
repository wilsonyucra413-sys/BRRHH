using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class PuestoMapeador
    {
        public static PuestoDTO toPuestoDTO(this Puesto puesto)
        {
            return new PuestoDTO()
            {
                Nombre = puesto.Nombre,
                Salario = puesto.Salario,
                Codigo=puesto.Codigo
            };
        }
    }
}