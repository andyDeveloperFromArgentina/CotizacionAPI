namespace CotizacionAPI.Servicios.Cotizacion.Interfaces;

using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;
using CotizacionAPI.Dominio.Entidades;

public interface IOrquestadorDeCotizacion
{
    Task<Result<CotizacionResponse>> GetCotizacionAsync(string moneda);
}
