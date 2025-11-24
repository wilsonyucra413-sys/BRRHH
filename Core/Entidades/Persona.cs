using System.ComponentModel.DataAnnotations;

namespace RRHH.Core.Entidades
{
    public class Persona
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        //el ci seria suficiente como codigo
        public string Ci { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
    }
}