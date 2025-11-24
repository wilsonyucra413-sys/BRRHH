namespace RRHH.Core.DTOs
{
    public class PersonaDTO
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Ci { get; set; }
        public string Sexo { get; set; }
        public DateOnly FechaNacimiento { get; set; }
    }
}
