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
    public class TipoContratoRepositorio : ITipoContratoRepositorio
    {
        private readonly RRHHContext context;
        public TipoContratoRepositorio(RRHHContext context)
        {
            this.context=context;            
        }

        public async Task<TipoContratoDTO> DeleteTipoContrato(string nombre)
        {
            var tipocontrato=await SearchTipoContrato(nombre);
            if(tipocontrato==null) return null;
            tipocontrato.Estado="Borrado";
            await context.SaveChangesAsync();
            return tipocontrato.toTipoContratoDTO();
        }

        public async Task<TipoContratoDTO> GetTipoContrato(string nombre)
        {
            var tipocontrato=await SearchTipoContrato(nombre);
            if(tipocontrato==null) return null;
            return tipocontrato.toTipoContratoDTO();
        }

        public async Task<List<TipoContratoDTO>> GetTipoContrato()
        {
            return await context.TipoContrato
                    .Where(tc => tc.Estado=="Activo")
                    .Select(tc => tc.toTipoContratoDTO())
                    .ToListAsync();
        }

        public async Task<TipoContratoDTO> PostTipoContrato(string nombre, string descripcion)
        {
            var tipocontrato= await SearchTipoContrato(nombre);
            if(tipocontrato!=null) return null;
            var nuevo= new TipoContrato
            {
                Nombre=nombre,
                Descripcion=descripcion,
                Estado="Activo"
            };
            await context.AddAsync(nuevo);
            await context.SaveChangesAsync();
            return nuevo.toTipoContratoDTO();
        }

        public async Task<TipoContratoDTO> PutTipoContrato(string nombre, string descripcion)
        {
            var tipocontrato= await SearchTipoContrato(nombre);
            if(tipocontrato==null) return null;
            tipocontrato.Descripcion=descripcion;
            await context.SaveChangesAsync();
            return tipocontrato.toTipoContratoDTO();
        }
        private async Task<TipoContrato?> SearchTipoContrato(string nombre)
        => await context.TipoContrato.FirstOrDefaultAsync(tc => tc.Nombre==nombre && tc.Estado=="Activo");
    }
}