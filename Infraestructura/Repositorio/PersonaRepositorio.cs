using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;
using RRHH.Core.Interfaces;
using RRHH.Core.Mapeador;
using RRHH.Infraestructura.Data;

namespace RRHH.Infraestructura.Repositorio
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly RRHHContext context;

        public PersonaRepositorio(RRHHContext context)
        {
            this.context = context;
        }

        // Obtiene una persona por su CI si está activa
        public async Task<PersonaDTO> GetPersona(string ci)
        {
            var personaEncontrada = await SearchPersona(ci);
            if (personaEncontrada == null) return null;
            return personaEncontrada.toPersonaDTO();
        }
        public async Task<List<PersonaDTO>> GetPersona()
        {
            return await context.Persona
                    .Where (p => p.Estado=="Activo")
                    .Select(p => p.toPersonaDTO())
                    .ToListAsync();

        }
        public async Task<PersonaDTO> PostPersona(PersonaDTO persona)
        {
            if (persona == null || await SearchPersona(persona.Ci)!=null) return null;
            var nuevaPersona = new Persona
            {
                Nombre = persona.Nombre,
                Apellidos = persona.Apellidos,
                Ci = persona.Ci,
                FechaNacimiento = persona.FechaNacimiento,
                Sexo = persona.Sexo, 
                Estado = "Activo"       
            };

            await context.AddAsync(nuevaPersona);
            await context.SaveChangesAsync();
            return persona;
        }

        public async Task<PersonaDTO> PutPersona(PersonaDTO persona)
        {
            var personaActualizar = await SearchPersona(persona.Ci);
            if (personaActualizar == null) return null;
            personaActualizar.Nombre = persona.Nombre;
            personaActualizar.Apellidos = persona.Apellidos;
            personaActualizar.Sexo=persona.Sexo;
            personaActualizar.FechaNacimiento = persona.FechaNacimiento;
            await context.SaveChangesAsync();
            return personaActualizar.toPersonaDTO();
        }
        public async Task<PersonaDTO> DeletePersona(string ci)
        {
            var personaEliminar = await SearchPersona(ci);
            if (personaEliminar == null) return null;
            personaEliminar.Estado = "Borrado";
            await context.SaveChangesAsync();
            return personaEliminar.toPersonaDTO();
        }
        private async Task<Persona?> SearchPersona(string ci)
            => await context.Persona
                    .FirstOrDefaultAsync(p => p.Ci == ci && p.Estado == "Activo");
    }
}
