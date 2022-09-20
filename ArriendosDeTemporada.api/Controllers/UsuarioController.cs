using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.business.Shared;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio UsuarioServicio;

        public UsuarioController(IUsuarioServicio UsuarioServicio)
        {
            this.UsuarioServicio = UsuarioServicio;
        }

        [HttpGet]
        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            return UsuarioServicio.ListarUsuarios();
        }

        [HttpPost]
        public void AddUsuario([FromBody] Usuario usuario)
        {
            UsuarioServicio.CrearUsuario(usuario);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            try
            {
                var usr = await UsuarioServicio.BuscarUsuario(id);
                if (usr == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado/deshabilitado");
                }
                return usr;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPut("{id:int}/disable")]
        public async Task<ActionResult<Usuario>> DeshabilitarUsuario(int id)
        {
            try
            {
                var usr = await UsuarioServicio.BuscarUsuario(id);
                if (usr == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado/deshabilitado");
                }
                return await UsuarioServicio.DeshabilitarUsuario(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }
    }
}
