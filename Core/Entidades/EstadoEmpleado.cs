using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class EstadoEmpleado
    {
        [Key]
        public int id { get; set; }
        public string Descripcion { get; set; }
        //EEM-{NOMBRECORTO}
        //EEM-ACTIVO
        //EEM-SUSPENDIDO
        //EEM-VACACIONES
        //EEM-DESPEDIDO
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}