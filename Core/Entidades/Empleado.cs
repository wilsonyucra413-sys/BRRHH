using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        public int idPersona { get; set; }
        public int idDepartamentoEmpresa { get; set; }
        public int idPuesto { get; set; }
        public int idEstadoEmpleado { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public string Sucursal { get; set; }
        //EMP-{CI}-{AÑOINGRESO}
        //EMP-7429381-2025
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}