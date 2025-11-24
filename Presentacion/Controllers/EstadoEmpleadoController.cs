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
    public class EstadoEmpleadoController : ControllerBase
    {
        private readonly IEstadoEmpleadoRepositorio context;
        public EstadoEmpleadoController(IEstadoEmpleadoRepositorio context)
        {
            this.context=context;
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetEstadoEmpleado(string codigo)
        {
            var estadoempleado= await context.GetEstadoEmpleado(codigo);
            if(estadoempleado==null) return NotFound("Verifique sus datos de Estado Empleado");
            return Ok(estadoempleado);
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetEstadoEmpleado()
        {
            return Ok(await context.GetEstadoEmpleado());
        }
        [HttpPost("Crear/{codgio}")]
        public async Task<IActionResult> PostEstadoEmpleado(string descripcion,string codigo)
        {
            var estadoempleado= await context.PostEstadoEmpleado(descripcion,codigo);
            if(estadoempleado==null) return NotFound("Verifique sus datos de Estado Empleado");
            return Ok(estadoempleado);
        }
        [HttpPut("Actulizar/{codigo}")]
        public async Task<IActionResult> PutEstadoEmpleado(string descripcion,string codigo)
        {
            var estadoempleado= await context.PutEstadoEmpleado(descripcion,codigo);
            if(estadoempleado==null) return NotFound("Verifique sus datos de Estado Empleado");
            return Ok(estadoempleado);
        }
        [HttpDelete("Eliminar/{codigo}")]
        public async Task<IActionResult> DeleteEstadoEmpleado(string codigo)
        {
            var estadoempleado= await context.DeleteEstadoEmpleado(codigo);
            if(estadoempleado==null) return NotFound("Verifique sus datos de Estado Empleado");
            return Ok(estadoempleado);
        }
        
    }
}