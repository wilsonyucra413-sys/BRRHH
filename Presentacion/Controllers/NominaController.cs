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
        public async Task<IActionResult> PostNomina(string empleado, DateOnly periodoinicio, DateOnly periodofin, int total,int totaldescuento,string codigo)
        {
            var nomina = await context.PostNomina(empleado,periodoinicio,periodofin,total,totaldescuento,codigo); 
            if(nomina == null) return NotFound("Verifique sus datos de Nomina.") ;
            return Ok(nomina);
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