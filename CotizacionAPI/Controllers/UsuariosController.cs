using CotizacionAPI.Servicios.Usuarios.Interfaces;
using CotizacionAPI.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CotizacionAPI.Controllers
{
    public class UsuariosController : ControllerBase
    {
        private readonly IOrquestadorDeUsuarios orquestadorUsuarios;

        public UsuariosController(IOrquestadorDeUsuarios orquestador)
        {
            this.orquestadorUsuarios = orquestador;
        }

        [HttpPost("Usuarios/PopularTabla")]
        public async Task<IActionResult> Post()
        {
                await orquestadorUsuarios.PopularUsuariosAsync();
                return Ok();
        }

        [HttpGet("Usuarios")]
        public async Task<List<Usuario>> Get()
        {
                return await orquestadorUsuarios.GetAsync();
        }
    }
}
