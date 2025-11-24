using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class Puesto
    {
        [Key]
        public int id { get; set; }
        //{NOMBRECORTO}
        //CAJERO
        //VENDEDOR
        //ALMACEN
        public string Nombre { get; set; }
        public int Salario { get; set; }
        public string Codigo { get; set; }

        public string Estado { get; set; }

    }
}