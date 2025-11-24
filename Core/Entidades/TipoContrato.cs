using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class TipoContrato
    {
        [Key]
        public int id { get; set; }
        public string Descripcion { get; set; }
        // PLAZOFIJO
        // PLAZOINDEFINIDO
        // PASANTIA
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
}