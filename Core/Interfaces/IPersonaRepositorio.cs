using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Core.Interfaces
{
    public interface IPersonaRepositorio
    {
        Task<PersonaDTO> GetPersona(string ci);
        Task<List<PersonaDTO>> GetPersona();
        Task<PersonaDTO> PostPersona(PersonaDTO persona);
        Task<PersonaDTO> PutPersona(PersonaDTO persona);
        Task<PersonaDTO> DeletePersona(string ci);
    }
}
