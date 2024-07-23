namespace CotizacionAPI.Servicios.Cotizacion.Implementacion;

using CotizacionAPI.Infraestructura.Servicios.Interfaces;
using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;
using CotizacionAPI.Servicios.Cotizacion.Interfaces;
using CotizacionAPI.Dominio.Entidades;

public sealed class ServicioBancoProvincia : IServicioDeCotizacion
{
    private readonly IServicioExternoBancoProvincia httpServicioBancoProvincia;

    public ServicioBancoProvincia(IServicioExternoBancoProvincia httpServicioBancoProvincia)
    {
        this.httpServicioBancoProvincia = httpServicioBancoProvincia;
    }

    public async Task<Result<CotizacionResponse>> GetAsync()
    {
        var stringResult = await this.httpServicioBancoProvincia.Cotizacion();

        if (stringResult == null || stringResult.Count == 0)
        {
            return new Result<CotizacionResponse>(new Error("E001", "No hay cotizacion"), default);
        }

        return new Result<CotizacionResponse>(null , new CotizacionResponse { ValorCompra = stringResult[0], ValorVenta = stringResult[1] });
    }
}
