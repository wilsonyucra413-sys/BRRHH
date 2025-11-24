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
    public class TipoContratoController : ControllerBase
    {
        private readonly ITipoContratoRepositorio context;
        public TipoContratoController(ITipoContratoRepositorio context)
        {
            this.context=context;
        }
        [HttpGet("{nombre}")]
        public async Task<IActionResult> GetTipoContrato(string nombre)
        {
            var tipocontrato= await context.GetTipoContrato(nombre);
            if(tipocontrato == null) return NotFound("Verifique sus datos de Tipo Contrato.");
            return Ok(tipocontrato);
        }
        [HttpGet("Listar")]
        public async Task<IActionResult> GetTipoContrato()
        {
            return Ok( await context.GetTipoContrato());
        }
        [HttpPost("Crear/{nombre}")]
        public async Task<IActionResult> PostTipoContrato(string nombre, string descripcion)
        {
            var tipocontrato = await context.PostTipoContrato(nombre,descripcion);
            if( tipocontrato== null) return NotFound("Verifique sus datos de puesto.");
            return Ok(tipocontrato);
        }
        [HttpPut("Actulizar/{nombre}")]
        public async Task<IActionResult> PutPuesto(string nombre,string descripcion)
        {
            var tipocontrato= await context.PutTipoContrato(nombre,descripcion);
            if(tipocontrato==null) return  NotFound("Verifique sus datos de Tipo Contrato.");
            tipocontrato.Descripcion=descripcion;
            return Ok(tipocontrato);
        }
        [HttpDelete("Eliminar/{nombre}")]
        public async Task<IActionResult> DeleteTipoContrato(string nombre)
        {
            var tipocontrato=await context.DeleteTipoContrato(nombre);
            if(tipocontrato==null) return NotFound("Verifique sus datos de Tipo Contrato.");
            return Ok(tipocontrato);
        }
    }
}