using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class Asistencia
    {
        [Key]
        public int id { get; set; }
        public int idEmpleado { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }    
        // AST-{IdEmpleado}-{FECHA(YYYYMMDD)}
        // AST-24-20251113
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}