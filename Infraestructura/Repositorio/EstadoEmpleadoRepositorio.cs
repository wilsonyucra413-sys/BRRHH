using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;
using RRHH.Core.Interfaces;
using RRHH.Core.Mapeador;
using RRHH.Infraestructura.Data;

namespace RRHH.Infraestructura.Repositorio
{
    public class EstadoEmpleadoRepositorio : IEstadoEmpleadoRepositorio
    {
        private readonly RRHHContext context;
        public EstadoEmpleadoRepositorio(RRHHContext context)
        {
            this.context=context;
        }

        public async Task<EstadoEmpleadoDTO> DeleteEstadoEmpleado(string codigo)
        {
            var estadompleado= await SearchEstadoEmpleado(codigo);
            if(estadompleado==null) return null;
            estadompleado.Estado="Borrado";
            await context.SaveChangesAsync();
            return estadompleado.toEstadoEmpleadoDTO(); 
        }

        public async Task<EstadoEmpleadoDTO> GetEstadoEmpleado(string codigo)
        {
            var estadoempleado= await SearchEstadoEmpleado(codigo);
            if(estadoempleado==null) return null;
            return estadoempleado.toEstadoEmpleadoDTO();
        }

        public async Task<List<EstadoEmpleadoDTO>> GetEstadoEmpleado()
        {
            return await context.EstadoEmpleado
                        .Where(ee => ee.Estado=="Activo")
                        .Select(ee => ee.toEstadoEmpleadoDTO())
                        .ToListAsync();
        }

        public async Task<EstadoEmpleadoDTO> PostEstadoEmpleado(string descripcion, string codigo)
        {   
            var estadoempleado= await SearchEstadoEmpleado(codigo);
            if(estadoempleado!=null) return null;
            var nuevo=new EstadoEmpleado
            {
                Descripcion=descripcion,
                Codigo=codigo,
                Estado="Activo"
            };
            await context.AddAsync(nuevo);
            await context.SaveChangesAsync();
            return nuevo.toEstadoEmpleadoDTO();
        }

        public async Task<EstadoEmpleadoDTO> PutEstadoEmpleado(string descripcion, string codigo)
        {
            var estadoempleado= await SearchEstadoEmpleado(codigo);
            if(estadoempleado==null) return null;
            estadoempleado.Descripcion=descripcion;
            await context.SaveChangesAsync();
            return estadoempleado.toEstadoEmpleadoDTO();
        }
        private async Task<EstadoEmpleado?> SearchEstadoEmpleado(string codigo)
        => await context.EstadoEmpleado
                .FirstOrDefaultAsync(ee => ee.Codigo == codigo && ee.Estado=="Activo");
    }
}
