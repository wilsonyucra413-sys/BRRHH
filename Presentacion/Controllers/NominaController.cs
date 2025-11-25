using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RRHH.Core.Interfaces;

namespace RRHH.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominaController : ControllerBase
    {
        private readonly INominaRepositorio context;
        public NominaController(INominaRepositorio context)
        {
            this.context=context;
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetNomina(string codigo)
        {
            var nomina= await context.GetNomina(codigo);
            if(nomina == null) return NotFound("Verifique sus datos de nomina.");
            return Ok(nomina);
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetNomina()
        {
            return Ok(await context.GetNomina());
        }
[HttpPost("Crear/{codigo}")]
public async Task<IActionResult> PostNomina(
    [FromRoute] string codigo, 
    [FromQuery] string empleado, 
    [FromQuery] string periodoinicio, 
    [FromQuery] string periodofin,    
    [FromQuery] int total, 
    [FromQuery] int totaldescuento)
{

    DateOnly fechaInicioParsed;
    DateOnly fechaFinParsed;

    if (!DateOnly.TryParse(periodoinicio, out fechaInicioParsed) || !DateOnly.TryParse(periodofin, out fechaFinParsed))
    {

        return BadRequest("El formato de las fechas es incorrecto. Use AAAA-MM-DD.");
    }

    try
    {
        var nomina = await context.PostNomina(empleado, fechaInicioParsed, fechaFinParsed, total, totaldescuento, codigo); 
        
        if (nomina == null)
        {
            return BadRequest("Verifique sus datos de Nomina. El empleado puede no existir, la nómina ya puede existir o los valores son incorrectos.");
        }

        return Ok(nomina);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Error interno del servidor: {ex.Message}");
    }
}
        [HttpPut("Actulizar/{codigo}")]
        public async Task<IActionResult> PutNomina(DateOnly periodoinicio, DateOnly periodofin, int total, int totaldescuento, string codigo)
        {
            var puesto= await context.PutNomina(periodoinicio,periodofin,total,totaldescuento,codigo);
            if(puesto==null) return  NotFound("Verifique sus datos de puesto.");
            return Ok(puesto);
        }
        [HttpDelete("Eliminar/{codigo}")]
        public async Task<IActionResult> DeleteNomina(string codigo)
        {
            var nomina=await context.DeleteNomina(codigo);
            if(nomina==null) return NotFound("Verifique sus datos de Nomina.");
            return Ok(nomina);
        }
    }
}