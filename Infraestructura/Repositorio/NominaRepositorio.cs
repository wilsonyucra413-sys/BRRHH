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
    public class NominaRepositorio : INominaRepositorio
    {
        private readonly RRHHContext context;
        public NominaRepositorio(RRHHContext context)
        {
            this.context=context;
        }

        public async Task<NominaDTO> DeleteNomina(string codigo)
        {
            var nomina = await SearchNomina(codigo);
            if( nomina ==null) return null;
            var empleado = await context.Empleado.FirstOrDefaultAsync(e => e.id==nomina.idEmpleado);
            nomina.Estado="Borrado";
            await context.SaveChangesAsync();
            return nomina.toNominaDTO(empleado.Codigo);
        }

        public async Task<NominaDTO> GetNomina(string codigo)
        {
            var nomina= await SearchNomina(codigo);
            if(nomina==null) return null;
            var empleado = await context.Empleado.FirstOrDefaultAsync(e => e.id==nomina.idEmpleado);
            return nomina.toNominaDTO(empleado.Codigo);
        }

        public async Task<List<NominaDTO>> GetNomina()
        {

            var nominas = await context.Nomina
                                .Where(n => n.Estado == "Activo")
                                .ToListAsync();
            if (!nominas.Any())
            {
                return new List<NominaDTO>();
            }
            var empleadoIds = nominas.Select(n => n.idEmpleado).Distinct().ToList();
            var empleadosMap = await context.Empleado
                                    .Where(e => empleadoIds.Contains(e.id))
                                    .ToDictionaryAsync(e => e.id);
            var nominasDto = nominas.Select(nomina =>
            {
                Empleado empleado = empleadosMap.GetValueOrDefault(nomina.idEmpleado);
                return nomina.toNominaDTO(empleado.Codigo);
            })
            .ToList();

            return nominasDto;
        }

        public async Task<NominaDTO> PostNomina(string empleado, DateOnly periodoinicio, DateOnly periodofin, int total,int totaldescuento,string codigo)
        {
            var nomina= await SearchNomina(codigo);
            if(nomina!=null) return null;
            var Empleado= await SearchEmpleado(empleado);
            if(periodoinicio>periodofin ||total-totaldescuento<0 || Empleado==null) return null;
            var nuevo= new Nomina
            {
                idEmpleado=Empleado.id,
                PeriodoInicio=periodoinicio,
                PeriodoFin= periodofin,
                Total= total,
                TotalDescuento=totaldescuento,
                TotalNeto=total-totaldescuento,
                Estado="Activo"
            };
            await context.AddAsync(nuevo);
            await context.SaveChangesAsync();
            return nuevo.toNominaDTO(Empleado.Codigo );
        }

        public async Task<NominaDTO> PutNomina(DateOnly periodoinicio, DateOnly periodofin, int total, int totaldescuento, string codigo)
        {
            var nomina= await SearchNomina(codigo);
            if(nomina==null || total-totaldescuento<0 || periodoinicio>periodofin) return null;
            var empleado= await context.Empleado.FirstOrDefaultAsync(e => e.id==nomina.idEmpleado);
            nomina.PeriodoInicio=periodoinicio;
            nomina.PeriodoFin=periodofin;
            nomina.Total=total;
            nomina.TotalDescuento=totaldescuento;
            nomina.TotalNeto=total-totaldescuento;
            await context.SaveChangesAsync();
            return nomina.toNominaDTO(empleado.Codigo);
        }
        private async Task<Nomina?> SearchNomina(string codigo)
        => await context.Nomina.FirstOrDefaultAsync(n => n.Codigo==codigo && n.Estado=="Activo");
        private async Task<Empleado?> SearchEmpleado(string codigo)
        => await context.Empleado.FirstOrDefaultAsync(e => e.Codigo==codigo && e.Estado=="Activo");
        
    }
}