using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.Entidades
{
    public class Curriculum
    {
        [Key]
        public int id { get; set; }
        public int idPersona { get; set; }
        public int idDepartamentoEmpresa { get; set; }
        public string CVurl { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
    }
}