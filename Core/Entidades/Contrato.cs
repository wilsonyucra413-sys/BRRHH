using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class Contrato
    {
        [Key]
        public int id { get; set; }
        public int idEmpleado { get; set; }
        public int idTipoContrato { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int Salario { get; set; }
        // CTR-{IdEmpleado}-{AÑO}-{MES}
        //CTR-24-2025-11
        public string Codigo { get; set; }
        public string Estado { get; set; }

    }
}