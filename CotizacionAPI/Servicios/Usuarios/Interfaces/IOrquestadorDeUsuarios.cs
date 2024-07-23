namespace CotizacionAPI.Servicios.Usuarios.Interfaces;

using CotizacionAPI.Dominio.Entidades;

public interface IOrquestadorDeUsuarios
{
    Task PopularUsuariosAsync();

    Task<List<Usuario>> GetAsync();
}
