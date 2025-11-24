using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class Nomina
    {
        [Key]
        public int id { get; set; }
        public int idEmpleado { get; set; }
        public DateOnly PeriodoInicio { get; set; }
        public DateOnly PeriodoFin { get; set; }
        public int Total { get; set; }
        public int TotalDescuento { get; set; }
        public int TotalNeto { get; set; }
        // NOM-{PERIODOINICIO(YYYYMM)}-{codigoempleado}
        // NOM-202511-EM-001
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}