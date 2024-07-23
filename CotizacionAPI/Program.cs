using CotizacionAPI.Infraestructura.Persistencia;
using CotizacionAPI.Infraestructura.Servicios.Interfaces;
using CotizacionAPI.Infraestructura.Servicios.Implementacion;
using CotizacionAPI.Servicios.Cotizacion.Implementacion;
using CotizacionAPI.Servicios.Cotizacion.Interfaces;
using CotizacionAPI.Servicios.Usuarios.Implementacion;
using CotizacionAPI.Servicios.Usuarios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ServicioBancoProvincia>();
builder.Services.AddScoped<ServicioLocal>();
builder.Services.AddScoped<IServicioExternoBancoProvincia, ServicioExternoBancoProvincia>();

builder.Services.AddScoped<IOrquestadorDeCotizacion, OrquestadorDeCotizacion>();
builder.Services.AddScoped<IOrquestadorDeUsuarios, OrquestadorDeUsuarios>();

builder.Services.AddDbContext<DataBaseContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DataBaseContext")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
