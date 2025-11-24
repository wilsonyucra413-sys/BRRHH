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
    public class EmpleadosController : ControllerBase
    {
      private readonly IEmpleadoRepositorio context;
      public EmpleadosController(IEmpleadoRepositorio context)
      {
        this.context=context;
      }
      [HttpGet("{codigo}")]
        public async Task<IActionResult> GetEmpleado(string codigo)
        {
            var empleado = await context.GetEmpleado(codigo);
            if (empleado == null) return NotFound($"No existe el empleado con ese codigo: {codigo}");
            return Ok(new
            {
                mensaje=$"Se encontro el empleado.",
                empleado
            });
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetEmpleado()
        {
            return Ok(await context.GetEmpleado());
        }

        [HttpPost("Crear/{codigo}")]
        public async Task<IActionResult> PostEmpleado(string persona, string departamentoempresa,string puesto,string estadoempleado,DateOnly fechaingreso,string sucursal,string codigo)
        {
            var empleado= await context.PostEmpleado(persona,departamentoempresa,puesto,estadoempleado,fechaingreso,sucursal,codigo);
            if(empleado==null) return NotFound("Verifique tus datos ingresados.");
            return Ok(new
            {
                mensaje="Se registro una nueva persona.",
                empleado
            });
        }

        [HttpPut("Actulizar/{codigo}")]
        public async Task<IActionResult> PutEmpleado( string codigo,DateOnly fechaingreso, string sucursal)
        {
            var empleado = await context.PutEmpleado(codigo,fechaingreso , sucursal);
            if (empleado == null) return NotFound($"No existe el empleado con codigo: {codigo} para actulizar.");
            return Ok(new
            {
                mensaje="Se actulizo la persona.",
                empleado
            });
        }

        [HttpDelete("Eliminar/{codigo}")]
        public async Task<IActionResult> DeleteEmpleado(string codigo)
        {
            var empleado = await context.GetEmpleado(codigo);
            return empleado == null ? NotFound($"No existe el empleado con Codigo: {codigo}.") : Ok(new
            {
                mensaje="Se elimino el empleado.",
                empleado
            }); 
        }
    }
}