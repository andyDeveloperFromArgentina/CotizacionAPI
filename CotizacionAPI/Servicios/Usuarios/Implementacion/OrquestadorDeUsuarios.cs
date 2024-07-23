namespace CotizacionAPI.Servicios.Usuarios.Implementacion;

using CotizacionAPI.Servicios.Usuarios.Interfaces;
using CotizacionAPI.Dominio.Entidades;
using CotizacionAPI.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

public class OrquestadorDeUsuarios : IOrquestadorDeUsuarios
{
    private readonly DataBaseContext db;

    public OrquestadorDeUsuarios(DataBaseContext db)
    {
        this.db = db;
        db.Database.EnsureCreated();
    }

    public async Task PopularUsuariosAsync()
    {
        using (db)
        {
            db.Usuarios.ExecuteDelete();

            for (int i = 0; i < 10; i++)
                {
                    var n = new Usuario()
                    {
                        Nombre = $"Andrea {i}",
                        Apellido = "Smith",
                        Email = "email",
                        Password = "password",
                    };
                    db.Add(n);
            }

            await db.SaveChangesAsync();
        }
    }

    public async Task<List<Usuario>> GetAsync()
    {
        return await db.Usuarios.ToListAsync();
    }
}
