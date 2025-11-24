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
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly RRHHContext context;
        public EmpleadoRepositorio(RRHHContext context)
        {
            this.context = context;
        }


        public async Task<EmpleadoDTO> GetEmpleado(string codigo)
        {
            var empleado = await SearchEmpleado(codigo);
            if (empleado == null) return null;
            var persona = await SearchPersona(empleado.idPersona);
            var departamentoempresa = await SearchDepartamentoEmpresa(empleado.idDepartamentoEmpresa);
            var puesto = await SearchPuesto(empleado.idPuesto);
            var estadoempleado = await SearchEstadoEmpleado(empleado.idEstadoEmpleado);
            if (persona == null || departamentoempresa == null || puesto == null || estadoempleado == null) return null;
            return empleado.toEmpleadoDTO(persona.Ci, departamentoempresa.Codigo, puesto.Codigo, estadoempleado.Codigo);

        }

        public async Task<List<EmpleadoDTO>> GetEmpleado()
        {
            var empleados = await context.Empleado.Where(e => e.Estado == "Activo").ToListAsync();
            if (!empleados.Any())
            {
                return new List<EmpleadoDTO>();
            }
            var personaIds = empleados.Select(e => e.idPersona).Distinct().ToList();
            var deptoIds = empleados.Select(e => e.idDepartamentoEmpresa).Distinct().ToList();
            var puestoIds = empleados.Select(e => e.idPuesto).Distinct().ToList();
            var estadoIds = empleados.Select(e => e.idEstadoEmpleado).Distinct().ToList();
            var personasMap = await context.Persona
                .Where(p => personaIds.Contains(p.id))
                .ToDictionaryAsync(p => p.id);
            var deptosMap = await context.DepartamentoEmpresa
                .Where(d => deptoIds.Contains(d.id))
                .ToDictionaryAsync(d => d.id);
            var puestosMap = await context.Puesto
                .Where(p => puestoIds.Contains(p.id))
                .ToDictionaryAsync(p => p.id);
            var estadosMap = await context.EstadoEmpleado
                .Where(e => estadoIds.Contains(e.id))
                .ToDictionaryAsync(e => e.id);
            var resultado = new List<EmpleadoDTO>();
            foreach (var empleado in empleados)
            {
                Persona persona = personasMap.GetValueOrDefault(empleado.idPersona);
                DepartamentoEmpresa depto = deptosMap.GetValueOrDefault(empleado.idDepartamentoEmpresa);
                Puesto puesto = puestosMap.GetValueOrDefault(empleado.idPuesto);
                EstadoEmpleado estado = estadosMap.GetValueOrDefault(empleado.idEstadoEmpleado);
                if (persona != null && depto != null && puesto != null && estado != null)
                {
                    resultado.Add(empleado.toEmpleadoDTO(persona.Ci, depto.Codigo, puesto.Codigo, estado.Codigo));
                }
            }

            return resultado;
        }
        public async Task<EmpleadoDTO> PostEmpleado(string persona, string departamentoempresa, string puesto, string estadoempleado, DateOnly fechaingreso, string sucursal, string codigo)
        {
            var verifict = await SearchEmpleado(codigo);
            if (verifict != null) return null;
            var Persona = await context.Persona.FirstOrDefaultAsync(p => p.Ci == persona && p.Estado == "Activo");
            var Departamentoempresa = await context.DepartamentoEmpresa.FirstOrDefaultAsync(de => de.Codigo == departamentoempresa && de.Estado == "Activo");
            var Puesto = await context.Puesto.FirstOrDefaultAsync(p => p.Codigo == puesto && p.Estado == "Activo");
            var Estadoempleado = await context.EstadoEmpleado.FirstOrDefaultAsync(ee => ee.Codigo == estadoempleado && ee.Estado == "Activo");
            if (persona == null || departamentoempresa == null || puesto == null || estadoempleado == null) return null;
            var empleado = new Empleado()
            {
                idPersona = Persona.id,
                idDepartamentoEmpresa = Departamentoempresa.id,
                idPuesto = Puesto.id,
                idEstadoEmpleado = Estadoempleado.id,
                FechaIngreso = fechaingreso,
                Sucursal = sucursal,
                Codigo = codigo,
                Estado = "Activo"
            };
            await context.AddAsync(empleado);
            await context.SaveChangesAsync();
            return empleado.toEmpleadoDTO(Persona.Ci, Departamentoempresa.Codigo, Puesto.Codigo, Estadoempleado.Codigo);
        }

        public async Task<EmpleadoDTO> PutEmpleado(string codigo, DateOnly fechaingreso, string sucursal)
        {
            var empleado = await SearchEmpleado(codigo);
            if (empleado == null) return null;
            empleado.FechaIngreso = fechaingreso;
            empleado.Sucursal = sucursal;
            var persona = await SearchPersona(empleado.idPersona);
            var departamentoempresa = await SearchDepartamentoEmpresa(empleado.idDepartamentoEmpresa);
            var puesto = await SearchPuesto(empleado.idPuesto);
            var estadoempleado = await SearchEstadoEmpleado(empleado.idEstadoEmpleado);
            await context.SaveChangesAsync();
            return empleado.toEmpleadoDTO(persona.Ci, departamentoempresa.Codigo, puesto.Codigo, estadoempleado.Codigo);
        }
        public async Task<EmpleadoDTO> DeleteEmpleado(string codigo)
        {
            var empleado = await SearchEmpleado(codigo);
            if (empleado == null) return null;
            empleado.Estado = "Borrado";
            await context.SaveChangesAsync();
            var persona = await SearchPersona(empleado.idPersona);
            var departamentoempresa = await SearchDepartamentoEmpresa(empleado.idDepartamentoEmpresa);
            var puesto = await SearchPuesto(empleado.idPuesto);
            var estadoempleado = await SearchEstadoEmpleado(empleado.idEstadoEmpleado);
            return empleado.toEmpleadoDTO(persona.Ci, departamentoempresa.Codigo, puesto.Codigo, estadoempleado.Codigo);
        }
        private async Task<Empleado?> SearchEmpleado(string codigo)
        => await context.Empleado
            .FirstOrDefaultAsync(e => e.Codigo == codigo && e.Estado == "Activo");
        private async Task<Persona?> SearchPersona(int id)
        => await context.Persona
            .FirstOrDefaultAsync(p => p.id == id && p.Estado == "Activo");
        private async Task<DepartamentoEmpresa?> SearchDepartamentoEmpresa(int id)
        => await context.DepartamentoEmpresa
            .FirstOrDefaultAsync(de => de.id == id && de.Estado == "Activo");
        private async Task<Puesto?> SearchPuesto(int id)
        => await context.Puesto
            .FirstOrDefaultAsync(p => p.id == id && p.Estado == "Activo");
        private async Task<EstadoEmpleado?> SearchEstadoEmpleado(int id)
        => await context.EstadoEmpleado
            .FirstOrDefaultAsync(ee => ee.id == id && ee.Estado == "Activo");
    }
}