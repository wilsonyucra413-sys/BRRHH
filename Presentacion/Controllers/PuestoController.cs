using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RRHH.Core.Interfaces;
using RRHH.Infraestructura.Data;

namespace RRHH.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoRepositorio context;
        public PuestoController(IPuestoRepositorio context)
        {
            this.context=context;
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetPuesto(string codigo)
        {
            var puesto= await context.GetPuesto(codigo);
            if(puesto == null) return NotFound("Verifique sus datos de puesto.");
            return Ok(puesto);
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetPuesto()
        {
            return Ok( await context.GetPuesto());
        }
        [HttpPost("Crear/{codigo}")]
        public async Task<IActionResult> PostPuesto(string nombre, int salario, string codigo)
        {
            var puesto = await context.PostPuesto(nombre,salario,codigo);
            if(puesto == null) return NotFound("Verifique sus datos de puesto.") ;
            return Ok(puesto);
        }
        [HttpPut("Actulizar/{codigo}")]
        public async Task<IActionResult> PutPuesto(string nombre,int salario,string codigo)
        {
            var puesto= await context.PutPuesto(nombre,salario,codigo);
            if(puesto==null) return  NotFound("Verifique sus datos de puesto.");
            return Ok(puesto);
        }
        [HttpDelete("Eliminar/{codigo}")]
        public async Task<IActionResult> DeletePuesto(string codigo)
        {
            var puesto=await context.DeletePuesto(codigo);
            if(puesto==null) return NotFound("Verifique sus datos de puesto.");
            return Ok(puesto);
        }
    }
}