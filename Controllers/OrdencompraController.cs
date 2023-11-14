using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route ("[controller]/[action]")]
    public class OrdencompraController : Controller
    {
        private IOrdencompraService _OrdencompraService;
        public OrdencompraController (IOrdencompraService OrdencompraService) {
            _OrdencompraService = OrdencompraService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Ordencompra = _OrdencompraService.getByPk(Id);
            if (Ordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Ordencompra);
        }
        [HttpPost]
        public IActionResult NuevoOrdenCompra(OrdenCompra obj)
        {
            var Id = _OrdencompraService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta un OrdenCompra." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateOrdenCompra(OrdenCompra obj)
        {
            try
            {
                if (obj != null)
                {
                    _OrdencompraService.update(obj);
                    return Ok(new { message = "OrdenCompra actualizado exitosamente" });
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
            var Coleccion = _OrdencompraService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByUsuario(int idUsuario)
        {
            var Coleccion = _OrdencompraService.getByUsuario(idUsuario);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getBySecretaria(int idSecretaria)
        {
            var Coleccion = _OrdencompraService.getBySecretaria(idSecretaria);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByOficina(int idOficina)
        {
            var Coleccion = _OrdencompraService.getByOficina(idOficina);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByDireccion(int idDireccion)
        {
            var Coleccion = _OrdencompraService.getByDireccion(idDireccion);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult delete(OrdenCompra obj)
        {
            _OrdencompraService.delete(obj);
            var detalleOrdenCompra = _OrdencompraService.getByPk(obj.Id);
            if (detalleOrdenCompra != null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(detalleOrdenCompra);
        }
    }
}

