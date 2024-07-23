using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;
using CotizacionAPI.Servicios.Cotizacion.Interfaces;
using CotizacionAPI.Dominio.Entidades;

namespace CotizacionAPI.Servicios.Cotizacion.Implementacion;

public class OrquestadorDeCotizacion : IOrquestadorDeCotizacion
{
    public readonly IServiceProvider serviceProvider;

    public OrquestadorDeCotizacion(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task<Result<CotizacionResponse>> GetCotizacionAsync(string moneda)
    {
        Monedas enumMonedas;
        IServicioDeCotizacion cotizacion;

        if (Enum.TryParse(moneda.ToUpper(), out enumMonedas))
        {
            switch (enumMonedas)
            {
                case Monedas.DOLAR:
                    {
                        cotizacion = this.serviceProvider!.GetService<ServicioBancoProvincia>()!;
                        return await cotizacion.GetAsync();
                    }
                case Monedas.PESOS:
                case Monedas.REAL:
                    {
                        cotizacion = this.serviceProvider!.GetService<ServicioLocal>()!;
                        return await cotizacion.GetAsync();
                    }
            }
        }

        return await Task.FromResult(new Result<CotizacionResponse>(new Error("E002", "Moneda sin cotizacion"), null));
    }
}