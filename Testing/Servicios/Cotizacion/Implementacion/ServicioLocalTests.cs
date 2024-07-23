using CotizacionAPI.Dominio.Entidades;
using CotizacionAPI.Servicios.Cotizacion.Implementacion;
using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;
using System.Diagnostics.CodeAnalysis;

namespace Testing.Servicios.Cotizacion.Implementacion;

[ExcludeFromCodeCoverage]
[TestClass]
public class ServicioLocalTests
{
    [TestMethod]
    public async Task GetAsync_return_Error_401()
    {
        var instancia = Instanciar();
        var result = await instancia.GetAsync();

        Assert.AreEqual("401", result.Error!.Codigo);
    }

    private static ServicioLocal Instanciar()
    {
        return new ServicioLocal();
    }
}
