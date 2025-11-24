using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RRHH.Core.Entidades;
using RRHH.Core.Interfaces;
using RRHH.Infraestructura.Data;
using RRHH.Infraestructura.Repositorio;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RRHHContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RRHHContext") ?? throw new InvalidOperationException("Connection string 'RRHHContext' not found.")));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
builder.Services.AddScoped<IDepartamentoEmpresaRepositorio, DepartamentoEmpresaRepositorio>();
builder.Services.AddScoped<IPuestoRepositorio, PuestoRepositorio>();
builder.Services.AddScoped<IEstadoEmpleadoRepositorio, EstadoEmpleadoRepositorio>();
builder.Services.AddScoped<ITipoContratoRepositorio,TipoContratoRepositorio>();



builder.Services.AddCors(option =>
{
    option.AddPolicy("myApp", policyBuilder =>
    {

        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("myApp");
app.UseAuthorization();
app.MapControllers();
app.Run();

