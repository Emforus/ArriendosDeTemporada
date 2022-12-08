using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.business.Shared;
using ArriendosDeTemporada.core.Models.DTOs;
using ArriendosDeTemporada.business;

namespace ArriendosDeTemporada.api.Controllers
{
    [Route("api/servicios")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioExtraServicio ServicioServicio;

        public ServicioController(IServicioExtraServicio ServicioServicio)
        {
            this.ServicioServicio = ServicioServicio;
        }

        [HttpGet]
        public IEnumerable<ServicioExtraDTO> ListarServicios()
        {
            return ServicioServicio.ListarServicios();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicioExtraDTO>> GetServicio(int id)
        {
            try
            {
                var svc = await ServicioServicio.BuscarServicio(id);
                if (svc == null)
                {
                    return NotFound($"Servicio con ID {id} no encontrado");
                }
                return Ok(svc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> EditServicio(int id, [FromBody] ServicioExtra servicio)
        {
            try
            {
                var Servicio = await ServicioServicio.EditarServicio(id, servicio);
                if (Servicio == null)
                {
                    return NotFound($"Servicio con ID {id} no encontrado");
                }
                return Ok(Servicio);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpGet("{id:int}/disable")]
        public async Task<ActionResult<ServicioExtra>> SetEstadoServicio(int id)
        {
            try
            {
                var svc = await ServicioServicio.SetEstadoServicio(id);
                if (svc == null)
                {
                    return NotFound($"Servicio con ID {id} no encontrado");
                }
                return Ok(svc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }
        [HttpPost]
        public ActionResult<ServicioExtra> AddServicio([FromBody] ServicioExtra svc)
        {
            try
            {
                ServicioServicio.RegistrarServicio(svc);
                return Ok(svc);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

    }
}
