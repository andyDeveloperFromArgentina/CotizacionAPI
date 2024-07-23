using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CotizacionAPI.Dominio.Entidades;

public class Result<T>
{
    public T? Datos { get; }

    public Error? Error { get; set; }

    public bool Success { get; }

    public Result (Error? error, T? data = default)
    {
        Datos = data;
        Success = error == null ? true : false;
        Error = error;
    }
}

public sealed record Error(string Codigo, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}
