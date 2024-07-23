namespace CotizacionAPI.Infraestructura.Servicios.Interfaces;

public interface IServicioExternoBancoProvincia
{
    Task<List<string>?> Cotizacion();
}
