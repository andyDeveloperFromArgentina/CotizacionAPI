namespace Testing.Servicios.Usuarios.Implementacion;

using Castle.Components.DictionaryAdapter.Xml;
using CotizacionAPI.Dominio.Entidades;
using CotizacionAPI.Infraestructura.Persistencia;
using CotizacionAPI.Servicios.Usuarios.Implementacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
[TestClass]
public class OrquestadorDeUsuariosTests
{

    [TestMethod]
    public async Task GetAsync_return_Usuarios()
    {
        var usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nombre = "Nombre" }
        };

        var dbSet = CreateDbSetMock<Usuario>(usuarios);

        var dbContext = new Mock<DataBaseContext>(new DbContextOptionsBuilder<DataBaseContext>().Options);
        dbContext.Setup<DbSet<Usuario>>(x => x.Usuarios).Returns(dbSet.Object);

        var instancia = Instanciar(dbContext.Object);
        var result = instancia.GetAsync();

        Assert.IsNotNull(result);
    }

    private static OrquestadorDeUsuarios Instanciar(DataBaseContext db)
    {
        return new OrquestadorDeUsuarios(db);
    }

    private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
    {
        var elementsAsQueryable = elements.AsQueryable();
        var dbSetMock = new Mock<DbSet<T>>();

        dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

        dbSetMock.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(element => elementsAsQueryable.ToList().Add(element));

        return dbSetMock;
    }
}
