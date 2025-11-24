using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRHH.Core.DTOs
{
    public class CurriculumDTO
    {
        public int Persona { get; set; }
        public int DepartamentoEmpresa { get; set; }
        public string Codigo { get; set; }
        public string CVurl { get; set; }
    }
}