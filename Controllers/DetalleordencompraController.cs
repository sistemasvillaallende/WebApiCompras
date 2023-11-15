using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetalleordencompraController : Controller
    {
        private IDetalleordencompraService _DetalleordencompraService;
        public DetalleordencompraController(IDetalleordencompraService DetalleordencompraService)
        {
            _DetalleordencompraService = DetalleordencompraService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Detalleordencompra = _DetalleordencompraService.getByPk(Id);
            if (Detalleordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalleordencompra);
        }
        [HttpPost]
        public IActionResult NuevoDetalleOrdenCompra(DetalleOrdenCompra obj)
        {
            var Id = _DetalleordencompraService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta un surtido." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateDetalleOrdenCompra(DetalleOrdenCompra obj)
        {
            try
            {
                if (obj != null)
                {
                    _DetalleordencompraService.update(obj);
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
            var Coleccion = _DetalleordencompraService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult delete(DetalleOrdenCompra obj)
        {
            _DetalleordencompraService.delete(obj);
            var detalleordencompra = _DetalleordencompraService.getByPk(obj.Id);
            if (detalleordencompra != null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(detalleordencompra);
        }
        [HttpGet]
        public IActionResult getByOrdenPedido(int idOrdenCompra)
        {
            var Detalleordencompra = _DetalleordencompraService.getByOrdenCompra(idOrdenCompra);
            if (Detalleordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalleordencompra);
        }


    }
}

