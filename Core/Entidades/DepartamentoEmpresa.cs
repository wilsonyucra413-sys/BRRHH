using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class DepartamentoEmpresa
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }

        //DEP-{NOMBRECORTO}
        // DEP-RRHH
        // DEP-ADM
        // DEP-FIN
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}