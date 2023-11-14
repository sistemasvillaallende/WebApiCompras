using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class OrdenpedidoController : Controller
{
private IOrdenpedidoService _OrdenpedidoService;
public OrdenpedidoController (IOrdenpedidoService OrdenpedidoService) {
    _OrdenpedidoService = OrdenpedidoService;
}
[HttpGet]
public IActionResult getByPk(int Id)
{
    var Ordenpedido = _OrdenpedidoService.getByPk(Id);
    if (Ordenpedido == null)
    {
        return BadRequest(new { message = "Error al obtener los datos" });
    }
    return Ok(Ordenpedido);
}
        public IActionResult NuevoOrdenpedido(Ordenpedido obj)
        {
            var Id = _OrdenpedidoService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta un Ordenpedido." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateOrdenpedido(Ordenpedido obj)
        {
            try
            {
                if (obj != null)
                {
                    _OrdenpedidoService.update(obj);
                    return Ok(new { message = "Ordenpedido actualizado exitosamente" });
                }
                else
                {
                    return BadRequest(new { message = "Los datos de entrada no son válidos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el Ordenpedido" });
            }
        }
        [HttpGet]
        public IActionResult read()
        {
            var Coleccion = _OrdenpedidoService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByUsuario(int idUsuario)
        {
            var Coleccion = _OrdenpedidoService.getByUsuario(idUsuario);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getBySecretaria(int idSecretaria)
        {
            var Coleccion = _OrdenpedidoService.getBySecretaria(idSecretaria);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByOficina(int idOficina)
        {
            var Coleccion = _OrdenpedidoService.getByOficina(idOficina);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByDireccion(int idDireccion)
        {
            var Coleccion = _OrdenpedidoService.getByDireccion(idDireccion);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }






    }
}

