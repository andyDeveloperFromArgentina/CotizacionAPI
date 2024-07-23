namespace CotizacionAPI.Infraestructura.Servicios.Implementacion;

using CotizacionAPI.Infraestructura.Servicios.Interfaces;

public sealed class ServicioExternoBancoProvincia : IServicioExternoBancoProvincia
{
    public async Task<List<string>?> Cotizacion()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetFromJsonAsync<List<string>>("http://www.bancoprovincia.com.ar/Principal/Dolar");

        return response;
    }
}
