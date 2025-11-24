using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class EstadoEmpleadoMapeador
    {
        public static EstadoEmpleadoDTO toEstadoEmpleadoDTO (this EstadoEmpleado estadoempleado)
        {
            return new EstadoEmpleadoDTO()
            {
                Descripcion = estadoempleado.Descripcion,
                Codigo = estadoempleado.Codigo
            };
        }
    }
}