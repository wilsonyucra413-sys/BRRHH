using Microsoft.AspNetCore.Mvc;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;
using RRHH.Core.Interfaces;
namespace RRHH.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepositorio context;

        public PersonasController(IPersonaRepositorio context)
        {
            this.context = context;
        }
        [HttpGet("Buscar")]
        public async Task<IActionResult> GetPersona(string ci)
        {
            var persona = await context.GetPersona(ci);
            if (persona == null) return NotFound($"No existe la persona con ese CI: {ci}");
            return Ok(persona);
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetPersona()
        {
            return Ok(await context.GetPersona());
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> PostPersona(PersonaDTO pe)
        {
            var persona= await context.PostPersona(pe);
            if(persona==null) return NotFound("Verifique tus datos ingresados.");
            return Ok(persona);
        }

        [HttpPut("Actulizar")]
        public async Task<IActionResult> PutPersona(PersonaDTO pe)
        {
            var persona = await context.PutPersona(pe);
            if (persona == null) return NotFound($"No existe la persona con CI: {pe.Ci} para actulizar.");
            return Ok(persona);
        }
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> DeletePersona(PersonaDTO pe)
        {
            var persona = await context.DeletePersona(pe.Ci);
            return persona == null ? NotFound($"No existe la persona con ese CI: {pe.Ci}.") : Ok(persona); 
        }

    }
}
