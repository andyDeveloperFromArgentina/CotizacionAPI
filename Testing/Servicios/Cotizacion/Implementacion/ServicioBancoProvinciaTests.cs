namespace Testing.Servicios.Cotizacion.Implementacion;

using CotizacionAPI.Infraestructura.Servicios.Interfaces;
using CotizacionAPI.Servicios.Cotizacion.Implementacion;
using System.Diagnostics.CodeAnalysis;
using Moq;

[ExcludeFromCodeCoverage]
[TestClass]
public class ServicioBancoProvinciaTests
{
    [TestMethod]
    public async Task GetAsync_return_Success_withData()
    {
        var servicioExterno = new Mock<IServicioExternoBancoProvincia>();

        servicioExterno.Setup(s => s.Cotizacion())
            .ReturnsAsync(new List<string> { "1", "2", "3"});

        var instancia = Instanciar(servicioExterno.Object);
        var result = await instancia.GetAsync();

        Assert.IsTrue(result.Success);
    }

    [TestMethod]
    public async Task GetAsync_return_Error()
    {
        var servicioExterno = new Mock<IServicioExternoBancoProvincia>();

        servicioExterno.Setup(s => s.Cotizacion())
            .ReturnsAsync(new List<string>());

        var instancia = Instanciar(servicioExterno.Object);
        var result = await instancia.GetAsync();

        Assert.IsNotNull(result.Error);
    }

    private static ServicioBancoProvincia Instanciar (IServicioExternoBancoProvincia? servicioExternoBancoProvincia = null)
        {
            servicioExternoBancoProvincia ??= new Mock<IServicioExternoBancoProvincia>().Object;
            return new ServicioBancoProvincia(servicioExternoBancoProvincia);
        }
    }
