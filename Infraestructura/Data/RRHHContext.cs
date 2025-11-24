using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RRHH.Core.DTOs;
using RRHH.Core.Entidades;

namespace RRHH.Infraestructura.Data
{
    public class RRHHContext : DbContext
    {
        public RRHHContext (DbContextOptions<RRHHContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; } = default!;
        public DbSet<Empleado> Empleado { get; set; } = default!;
        public DbSet<DepartamentoEmpresa> DepartamentoEmpresa { get; set; } = default!;
        public DbSet<Puesto> Puesto { get; set; } = default!;
        public DbSet<EstadoEmpleado> EstadoEmpleado { get; set; } = default!;
        public DbSet<TipoContrato> TipoContrato { get; set; } = default!;
        public DbSet<Nomina> Nomina { get; set; } = default!;
        public DbSet<Asistencia> Asistencia { get; set; } = default!;
        public DbSet<Contrato> Contrato { get; set; } = default!;
        public DbSet<DetalleNomina>DetalleNomina { get; set; } = default!;
        public DbSet<Curriculum>Curriculum { get; set; } = default!;
        





    }
}
