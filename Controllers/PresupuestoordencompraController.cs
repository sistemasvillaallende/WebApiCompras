using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route ("[controller]/[action]")]
    public class PresupuestoordencompraController : Controller
    {
        private IPresupuestoOrdenCompraService _PresupuestoordencompraService;
        public PresupuestoordencompraController (IPresupuestoOrdenCompraService PresupuestoordencompraService) {
            _PresupuestoordencompraService = PresupuestoordencompraService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Ordencompra = _PresupuestoordencompraService.getByPk(Id);
            if (Ordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ordencompra);
        }
        [HttpPost]
        public IActionResult NuevoPresupuestoOrdenCompra(PresupuestoOrdenCompra obj)
        {
            var Id = _PresupuestoordencompraService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdatePresupuestoOrdenCompra(PresupuestoOrdenCompra obj)
        {
            try
            {
                if (obj != null)
                {
                    _PresupuestoordencompraService.update(obj);
                    return Ok(new { message = "Actualizado exitosamente" });
                }
                else
                {
                    return BadRequest(new { message = "Los datos de entrada no son válidos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el OrdenCompra" });
            }
        }
        [HttpGet]
        public IActionResult read()
        {
            var Coleccion = _PresupuestoordencompraService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByUsuario(int idUsuario)
        {
            var Coleccion = _PresupuestoordencompraService.getByUsuario(idUsuario);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getBySecretaria(int idSecretaria)
        {
            var Coleccion = _PresupuestoordencompraService.getBySecretaria(idSecretaria);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByOficina(int idOficina)
        {
            var Coleccion = _PresupuestoordencompraService.getByOficina(idOficina);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByDireccion(int idDireccion)
        {
            var Coleccion = _PresupuestoordencompraService.getByDireccion(idDireccion);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult delete(PresupuestoOrdenCompra obj)
        {
            _PresupuestoordencompraService.delete(obj);
            var detalleOrdenCompra = _PresupuestoordencompraService.getByPk(obj.Id);
            if (detalleOrdenCompra != null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(detalleOrdenCompra);
        }
        [HttpGet]
        public IActionResult getByOrdenCompra(int idOrdenPedido)
        {
            var Coleccion = _PresupuestoordencompraService.getByOrdenCompra(idOrdenPedido);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
    }
}

