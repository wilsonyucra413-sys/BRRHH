using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class DepartamentoEmpresaMapeador
    {
        public static DepartamentoEmpresaDTO toDepartamentoEmpresaDTO(this DepartamentoEmpresa departamentoempresa)
        {
            return new DepartamentoEmpresaDTO()
            {
                Nombre=departamentoempresa.Nombre,
                Codigo=departamentoempresa.Codigo
            };
        }
    }
}