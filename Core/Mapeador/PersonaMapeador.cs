using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Mapeador
{
    static public class PersonaMapeador
    {
        public static PersonaDTO toPersonaDTO(this Persona persona)
        {
            return new PersonaDTO()
            {
                Nombre=persona.Nombre,
                Apellidos=persona.Apellidos,
                Ci = persona.Ci,
                Sexo=persona.Sexo,
                FechaNacimiento = persona.FechaNacimiento
            };
        }
    }
}
