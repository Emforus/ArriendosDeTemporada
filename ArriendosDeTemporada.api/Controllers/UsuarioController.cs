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
        public ActionResult<Usuario> AddUsuario([FromBody] Usuario usuario)
        {
            try
            {
                UsuarioServicio.CrearUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
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

        [HttpGet("{username}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioByUsername(string username)
        {
            try
            {
                var usr = await UsuarioServicio.BuscarUsername(username);
                if (usr == null)
                {
                    return NotFound($"Usuario con ID {username} no encontrado/deshabilitado");
                }
                return usr;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> EditUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                var usr = await UsuarioServicio.EditarUsuario(id, usuario);
                if (usr == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado");
                }
                return Ok(usr);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPut("{username}/changePassword")]
        public async Task<ActionResult<UsuarioDTO>> ChangeUserPassword([FromBody] AuthDataDTO data)
        {
            try
            {
                var usr = await UsuarioServicio.CambiarContraseña(data);
                if (usr == null)
                {
                    return BadRequest($"Usuario no encontrado/Contraseña invalida.");
                }
                return Ok(usr);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpGet("{id:int}/disable")]
        public async Task<ActionResult<Usuario>> SetEstadoUsuario(int id)
        {
            try
            {
                var usr = await UsuarioServicio.SetEstadoUsuario(id);
                if (usr == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado");
                }
                return Ok(usr);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> Autenticar([FromBody] AuthDataDTO data)
        {
            try
            {
                var auth = await UsuarioServicio.Autenticar(data);
                if (!auth)
                {
                    return Unauthorized($"Usuario y/o contraseña invalidos");
                }
                return auth;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> RemoverUsuario(int id)
        {
            try
            {
                var usr = await UsuarioServicio.RemoverUsuario(id);
                if (usr == null)
                {
                    return NotFound($"Usuario con ID {id} no encontrado");
                }
                return Ok(usr);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

    }
}
