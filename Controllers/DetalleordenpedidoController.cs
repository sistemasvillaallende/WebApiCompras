using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetalleordenpedidoController : Controller
    {
        private IDetalleordenpedidoService _DetalleordenpedidoService;
        public DetalleordenpedidoController(IDetalleordenpedidoService DetalleordenpedidoService)
        {
            _DetalleordenpedidoService = DetalleordenpedidoService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Detalleordenpedido = _DetalleordenpedidoService.getByPk(Id);
            if (Detalleordenpedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalleordenpedido);
        }
        [HttpPost]
        public IActionResult NuevoDetalleOrdenPedido(DetalleOrdenpedido obj)
        {
            var Id = _DetalleordenpedidoService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta un surtido." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateDetalleOrdenPedido(DetalleOrdenpedido obj)
        {
            try
            {
                if (obj != null)
                {
                    _DetalleordenpedidoService.update(obj);
                    return Ok(new { message = "Actualizado exitosamente" });
                }
                else
                {
                    return BadRequest(new { message = "Los datos de entrada no son válidos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar" });
            }
        }
        [HttpGet]
        public IActionResult read()
        {
            var Coleccion = _DetalleordenpedidoService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult delete(DetalleOrdenpedido obj)
        {
            _DetalleordenpedidoService.delete(obj);
            var detalleordenpedido = _DetalleordenpedidoService.getByPk(obj.Id);
            if (detalleordenpedido != null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(detalleordenpedido);
        }
        [HttpGet]
        public IActionResult getByOrdenPedido(int idOrdenPedido)
        {
            var Detalleordenpedido = _DetalleordenpedidoService.getByOrdenPedido(idOrdenPedido);
            if (Detalleordenpedido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalleordenpedido);
        }
    }
}

