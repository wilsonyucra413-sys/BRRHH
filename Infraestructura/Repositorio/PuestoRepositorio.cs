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
    public class PuestoRepositorio : IPuestoRepositorio
    {
        private readonly RRHHContext context;
        public PuestoRepositorio(RRHHContext context)
        {
            this.context =context;
        }

        public async Task<PuestoDTO> DeletePuesto(string codigo)
        {
            var puesto= await SearchPuesto(codigo);
            if(puesto ==null) return null;
            puesto.Estado="Borrado";
            await context.SaveChangesAsync();
            return puesto.toPuestoDTO();
        }

        public async Task<PuestoDTO> GetPuesto(string codigo)
        {
            var puesto=  await SearchPuesto(codigo);
            if(puesto ==null) return null;
            return puesto.toPuestoDTO();
        }

        public async Task<List<PuestoDTO>> GetPuesto()
        {
            return await context.Puesto
                        .Where(p => p.Estado=="Activo")
                        .Select( p => p.toPuestoDTO())
                        .ToListAsync();
        }

        public async Task<PuestoDTO> PostPuesto(string nombre, int salario, string codigo)
        {
            var puesto= await SearchPuesto(codigo);
            if(puesto!=null) return null;
            var nuevo=new Puesto
            {
                Nombre=nombre,
                Salario=salario,
                Codigo=codigo,
                Estado="Activo"
            };
            await context.AddAsync(nuevo);
            await context.SaveChangesAsync();
            return nuevo.toPuestoDTO();
        }

        public async Task<PuestoDTO> PutPuesto(string nombre, int salario, string codigo)
        {
            var puesto= await SearchPuesto(codigo);
            if(puesto==null) return null;
            puesto.Nombre=nombre;
            puesto.Salario=salario;
            await context.SaveChangesAsync();
            return puesto.toPuestoDTO();
        }
        private async Task<Puesto?> SearchPuesto(string codigo)
        => await context.Puesto.FirstOrDefaultAsync(p => p.Codigo==codigo && p.Estado=="Activo");
    }
}