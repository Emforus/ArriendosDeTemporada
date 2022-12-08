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
    [Route("api/departamentos")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoServicio departamentoServicio;

        public DepartamentoController(IDepartamentoServicio departamentoServicio)
        {
            this.departamentoServicio = departamentoServicio;
        }

        [HttpGet]
        public IEnumerable<DepartamentoDTO> ListarDepartamentos()
        {
            return departamentoServicio.ListarDepartamentos();
        }

        [HttpPost]
        public ActionResult<Departamento> AddDepartamento([FromBody] Departamento depto)
        {
            try
            {
                departamentoServicio.CrearDepartamento(depto);
                return Ok(depto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartamentoDTO>> GetDepartamento(int id)
        {
            try
            {
                var depto = await departamentoServicio.BuscarDepartamento(id);
                if (depto == null)
                {
                    return NotFound($"Departamento con ID {id} no encontrado/deshabilitado");
                }
                return depto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> EditDepartamnto(int id, [FromBody] Departamento depto)
        {
            try
            {
                var departamento = await departamentoServicio.EditarDepartamento(id, depto);
                if (departamento == null)
                {
                    return NotFound($"Departamento con ID {id} no encontrado");
                }
                return Ok(departamento);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{id:int}/disable")]
        public async Task<ActionResult<Departamento>> SetEstadoDepartamento(int id)
        {
            try
            {
                var depto = await departamentoServicio.SetEstadoDepartamento(id);
                if (depto == null)
                {
                    return NotFound($"Departamento con ID {id} no encontrado");
                }
                return Ok(depto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPost("reservar")]
        public async Task<ActionResult<FacturaDTO>> ReservarDepartamento([FromBody] Factura factura)
        {
            try
            {
                var depto = await departamentoServicio.ReservarDepartamento(factura);
                if (depto == null)
                {
                    return NotFound($"Error desconocido.");
                }
                return Ok(depto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }
        [HttpGet("{id:int}/utilidades")]
        public async Task<ActionResult<List<Utilidad>>> GetUtilidades(int id)
        {
            try
            {
                var depto = await departamentoServicio.ListarUtilidades(id);
                if (depto == null)
                {
                    return NotFound($"Error desconocido.");
                }
                return Ok(depto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPost("{id:int}/utilidades")]
        public async Task<ActionResult<Departamento>> AddUtilidades([FromBody] Utilidad[] utilidades, int id)
        {
            try
            {
                var depto = await departamentoServicio.AñadirUtilidades(utilidades, id);
                if (depto == null)
                {
                    return NotFound($"Error desconocido.");
                }
                return Ok(depto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpPut("{id:int}/utilidades")]
        public async Task<ActionResult<Departamento>> RemoveUtilidades([FromBody] Utilidad[] utilidades, int id)
        {
            try
            {
                var depto = await departamentoServicio.RemoverUtilidades(utilidades, id);
                if (depto == null)
                {
                    return NotFound($"Error desconocido.");
                }
                return Ok(depto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{id:int}/servicios")]
        public async Task<ActionResult<Departamento>> GetServicios(int id)
        {
            try
            {
                var servicios = await departamentoServicio.ListarServiciosDisponibles(id);
                if (servicios == null)
                {
                    return NotFound($"Departamento con ID {id} no encontrado o no tiene servicios disponibles registrados.");
                }
                return Ok(servicios);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

    }
}
