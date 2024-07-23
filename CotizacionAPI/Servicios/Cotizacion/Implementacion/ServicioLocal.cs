namespace CotizacionAPI.Servicios.Cotizacion.Implementacion;

using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;
using CotizacionAPI.Servicios.Cotizacion.Interfaces;
using CotizacionAPI.Dominio.Entidades;

public sealed class ServicioLocal : IServicioDeCotizacion
{
    public async Task<Result<CotizacionResponse>> GetAsync()
    {
        return await Task.FromResult(new Result<CotizacionResponse>(new Error("401", "NO AUTORIZADO"), null));
    }
}