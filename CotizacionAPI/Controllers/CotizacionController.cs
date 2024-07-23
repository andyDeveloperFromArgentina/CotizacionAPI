using CotizacionAPI.Servicios.Cotizacion.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CotizacionAPI.Controllers;

public class CotizacionController : ControllerBase
{
    private readonly IOrquestadorDeCotizacion orquestadorDeCotizacion;

    public CotizacionController(IOrquestadorDeCotizacion orquestador)
    {
        this.orquestadorDeCotizacion = orquestador;
    }

    [HttpGet("Cotizacion/{moneda}")]
    public async Task<IActionResult> Get([FromRoute] string moneda)
    {
        var data = await orquestadorDeCotizacion.GetCotizacionAsync(moneda);

        if (data != null &&
           data.Error != null &&
           data.Error.Codigo == "401")
        {
            return Unauthorized(data.Error.Description);
        }

        return  Ok(data);
    }
}