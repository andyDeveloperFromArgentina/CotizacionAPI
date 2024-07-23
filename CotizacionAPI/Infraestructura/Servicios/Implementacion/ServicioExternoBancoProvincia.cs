namespace CotizacionAPI.Infraestructura.Servicios.Implementacion;

using CotizacionAPI.Infraestructura.Servicios.Interfaces;
using Microsoft.Extensions.Configuration;

public sealed class ServicioExternoBancoProvincia : IServicioExternoBancoProvincia
{
    private string? uri = string.Empty;

    public ServicioExternoBancoProvincia(IConfiguration configuration)
    {
        this.uri = configuration.GetSection("urlBancoProvincia").Value;
    }

    public async Task<List<string>?> Cotizacion()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetFromJsonAsync<List<string>>($"{this.uri}Principal/Dolar");

        return response;
    }
}
