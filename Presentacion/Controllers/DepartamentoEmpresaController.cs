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
    public class DepartamentoEmpresaController : ControllerBase
    {
        private readonly IDepartamentoEmpresaRepositorio  context;

        public DepartamentoEmpresaController(IDepartamentoEmpresaRepositorio context)
        {
            this.context = context;
        }
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetDepartamentoEmpresa(string codigo)
        {
            var departamentoempresa= await context.GetDeparatamentoEmpresa(codigo);
            if(departamentoempresa==null) return NotFound("Verifique sus datos de Departamento Empresa.");
            return Ok(departamentoempresa);
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetDepartamentoEmpresa()
        {
            var departamentoempresa= await context.GetDeparatamentoEmpresa();
            return Ok(departamentoempresa);
        }
        [HttpPost("Crear/{codigo}")]
        public async Task<IActionResult> PostDepartamentoEmpresa(string nombre,string codigo)
        {
            var departamentoempresa= await context.PostDeparatamentoEmpresa(nombre,codigo);
            if(departamentoempresa==null) return NotFound("Verifique sus datos de Departamento Empresa.");
            return Ok(departamentoempresa);
        }
        [HttpPut("Actulizar/{codigo}")]
        public async Task<IActionResult> PutDepartamentoEmpresa(string nombre,string codigo,string nuevocodigo)
        {
            var departamentoempresa= await context.PutDeparatamentoEmpresa(nombre,codigo,nuevocodigo);
            if(departamentoempresa==null) return NotFound("Verifique sus datos de Departamento Empresa.");
            return Ok(departamentoempresa);
        }
        [HttpDelete("Eliminar/{codigo}")]
        public async Task<IActionResult> DeleteDepartamentoEmpresa(string codigo)
        {
            var departamentoempresa= await context.DeleteDeparatamentoEmpresa(codigo);
            if(departamentoempresa==null) return NotFound("Verifique sus datos de Departamento Empresa.");
            return Ok(departamentoempresa);
        }

    }
}