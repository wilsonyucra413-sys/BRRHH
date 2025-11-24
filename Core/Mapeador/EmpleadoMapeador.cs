using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class EmpleadoMapeador
    {
        public static EmpleadoDTO toEmpleadoDTO(this Empleado empleado,string persona,string departamentoempresa,string puesto,string estadoempleado)
        {
            return new EmpleadoDTO()
            {
                Persona=persona,
                DepartamentoEmpresa=departamentoempresa,
                Puesto=puesto,
                EstadoEmpleado=estadoempleado,
                FechaIngreso = empleado.FechaIngreso,
                Sucursal = empleado.Sucursal,
                Codigo = empleado.Codigo
            };
        }
    }
}