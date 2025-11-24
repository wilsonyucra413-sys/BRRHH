using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class DetalleNomina
    {
        [Key]
        public int id { get; set; }
        public int idNomina { get; set; }
        public string Concepto { get; set; }
        public int Monto { get; set; }
        // DNM-{IdNomina}-{TIPO}
        // DNM-88-BONIFICACION
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}