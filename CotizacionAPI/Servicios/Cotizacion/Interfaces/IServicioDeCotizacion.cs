using CotizacionAPI.Dominio.Entidades;
using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;

namespace CotizacionAPI.Servicios.Cotizacion.Interfaces;

public interface IServicioDeCotizacion
{
    Task<Result<CotizacionResponse>> GetAsync();
}
