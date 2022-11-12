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
    [Route("api/reservas")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServicio facturaServicio;

        public FacturaController(IFacturaServicio facturaServicio)
        {
            this.facturaServicio = facturaServicio;
        }

        [HttpGet]
        public IEnumerable<FacturaDTO> ListarFacturas()
        {
            return facturaServicio.ListarFacturas();
        }

        [HttpGet("departamento/{id:int}")]
        public IQueryable<FacturaDTO> ListarFacturasPorDepartamento(int id)
        {
            return facturaServicio.ListarFacturasPorDepartamento(id);
        }

        [HttpGet("usuario/{id:int}")]
        public IQueryable<FacturaDTO> ListarFacturasPorCliente(int id)
        {
            return facturaServicio.ListarFacturasPorCliente(id);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FacturaDTO>> GetFactura(int id)
        {
            try
            {
                var fac = await facturaServicio.BuscarFactura(id);
                if (fac == null)
                {
                    return NotFound($"Reserva con ID {id} no encontrada");
                }
                return Ok(fac);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno: No se pudo realizar la operacion");
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Factura>> AnularFactura([FromBody] Factura factura)
        {
            try
            {
                var fac = await facturaServicio.AnularFactura(factura);
                if (fac == null)
                {
                    return NotFound($"Reserva con ID {factura.ID} no encontrada");
                }
                return Ok(fac);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

    }
}
