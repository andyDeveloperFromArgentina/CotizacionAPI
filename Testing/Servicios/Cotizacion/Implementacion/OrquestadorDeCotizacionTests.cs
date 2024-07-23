using CotizacionAPI.Dominio.Entidades;
using CotizacionAPI.Infraestructura.Servicios.Interfaces;
using CotizacionAPI.Servicios.Cotizacion.Implementacion;
using CotizacionAPI.Servicios.Cotizacion.Implementacion.Models;
using CotizacionAPI.Servicios.Cotizacion.Interfaces;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace Testing.Servicios.Cotizacion.Implementacion;

[ExcludeFromCodeCoverage]
[TestClass]
public class OrquestadorDeCotizacionTests
{
    [TestMethod]
    public async Task GetAsync_Return_DolarCotizacion_With_Value()
    {
        var bancoProvincia = new Mock<IServicioExternoBancoProvincia>();

        bancoProvincia.Setup(s => s.Cotizacion())
            .ReturnsAsync(new List<string> { "1", "2", "3" });

        var serviceProvider = new Mock<IServiceProvider>();

        serviceProvider.Setup(sp => sp.GetService(typeof(ServicioBancoProvincia)))
            .Returns(new ServicioBancoProvincia(bancoProvincia.Object));

        var instancia = Instanciar(serviceProvider: serviceProvider.Object);
        var result = await instancia.GetCotizacionAsync("dolar");

        Assert.IsTrue(result.Success);
        Assert.AreEqual("1", result.Datos!.ValorCompra);
    }

    [TestMethod]
    public async Task GetAsync_Return_DolarCotizacion_WithOut_Value()
    {
        var bancoProvincia = new Mock<IServicioExternoBancoProvincia>();

        bancoProvincia.Setup(s => s.Cotizacion())
            .ReturnsAsync(new List<string>());

        var serviceProvider = new Mock<IServiceProvider>();

        serviceProvider.Setup(sp => sp.GetService(typeof(ServicioBancoProvincia)))
            .Returns(new ServicioBancoProvincia(bancoProvincia.Object));

        var instancia = Instanciar(serviceProvider: serviceProvider.Object);
        var result = await instancia.GetCotizacionAsync("dolar");

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
    }

    [TestMethod]
    public async Task GetAsync_Return_PesosCotizacion_with_401()
    {
        var serviceProvider = new Mock<IServiceProvider>();

        serviceProvider.Setup(sp => sp.GetService(typeof(ServicioLocal)))
           .Returns(new ServicioLocal());

        var instancia = Instanciar(serviceProvider: serviceProvider.Object);
       
        var result = await instancia.GetCotizacionAsync("pesos");

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
        Assert.AreEqual("401", result.Error!.Codigo);
    }

    [TestMethod]
    public async Task GetAsync_Return_RealCotizacion_with_401()
    {
        var serviceProvider = new Mock<IServiceProvider>();

           serviceProvider.Setup(sp => sp.GetService(typeof(ServicioLocal)))
           .Returns(new ServicioLocal());

        var instancia = Instanciar(serviceProvider: serviceProvider.Object);
        var result = await instancia.GetCotizacionAsync("real");

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
        Assert.AreEqual("401", result.Error!.Codigo);
    }

    [TestMethod]
    public async Task GetAsync_return_SinCotizacion()
    {
        var instancia = Instanciar();
        var result = await instancia.GetCotizacionAsync("canadienses");

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
    }

    private static OrquestadorDeCotizacion Instanciar(IServiceProvider? serviceProvider = null)
    {
        serviceProvider ??= new Mock<IServiceProvider>().Object;

        return new OrquestadorDeCotizacion(serviceProvider);
    }
}
