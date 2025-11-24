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
    public class DepartamentoEmpresaRepositorio : IDepartamentoEmpresaRepositorio
    {
        private readonly RRHHContext context;

        public DepartamentoEmpresaRepositorio(RRHHContext context)
        {
            this.context = context;
        }

        public async Task<DepartamentoEmpresaDTO> DeleteDeparatamentoEmpresa(string codigo)
        {
            var departamentoempresa= await SearchDepartementoEmpresa(codigo);
            if(departamentoempresa==null) return null;
            departamentoempresa.Estado="Borrado";
            await context.SaveChangesAsync();
            return departamentoempresa.toDepartamentoEmpresaDTO();
        }

        public async Task<DepartamentoEmpresaDTO> GetDeparatamentoEmpresa(string codigo)
        {
            var departamentoempresa= await SearchDepartementoEmpresa(codigo);
            if(departamentoempresa==null) return null;
            return departamentoempresa.toDepartamentoEmpresaDTO();
        }

        public async Task<List<DepartamentoEmpresaDTO>> GetDeparatamentoEmpresa()
        {
            return await context.DepartamentoEmpresa
                        .Where(de => de.Estado=="Activo")
                        .Select(de => de.toDepartamentoEmpresaDTO())
                        .ToListAsync();            
        }

        public async Task<DepartamentoEmpresaDTO> PostDeparatamentoEmpresa(string nombre, string codigo)
        {
            var departamentoempresa= await context.DepartamentoEmpresa.FirstOrDefaultAsync(de => de.Codigo==codigo);
            if(departamentoempresa!=null) return null;
            var nuevo= new DepartamentoEmpresa{
                Nombre=nombre,
                Codigo=codigo,
                Estado="Activo"
            };
            await context.AddAsync(nuevo);
            await context.SaveChangesAsync();
            return nuevo.toDepartamentoEmpresaDTO();

        }

        public async Task<DepartamentoEmpresaDTO> PutDeparatamentoEmpresa(string nombre, string codigo,string nuevocodigo)
        {
            var nuevo= await SearchDepartementoEmpresa(codigo);
            if(nuevo==null) return null;
            nuevo.Nombre=nombre;
            nuevo.Codigo=nuevocodigo;
            await context.SaveChangesAsync();
            return nuevo.toDepartamentoEmpresaDTO();
        }
        private async Task<DepartamentoEmpresa?> SearchDepartementoEmpresa(string codigo)
            => await context.DepartamentoEmpresa
                    .FirstOrDefaultAsync(de =>  de.Codigo== codigo && de.Estado=="Activo");
    }
}