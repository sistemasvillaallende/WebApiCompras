using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route ("[controller]/[action]")]
    public class SurtidoController : Controller
    {
        private ISurtidoService _SurtidoService;
        public SurtidoController (ISurtidoService SurtidoService) {
        _SurtidoService = SurtidoService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Surtido = _SurtidoService.getByPk(Id);
            if (Surtido == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Surtido);
        }
        [HttpPost]
        public IActionResult NuevoSurtido(Surtido obj)
        {
            var Id = _SurtidoService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta un surtido." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateSurtido(Surtido obj)
        {
            try
            {
                if (obj != null)
                {
                    _SurtidoService.update(obj);
                    return Ok(new { message = "Surtido actualizado exitosamente" });
                }
                else
                {
                    return BadRequest(new { message = "Los datos de entrada no son válidos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el surtido" });
            }
        }
        [HttpGet]
        public IActionResult read()
        {
            var Coleccion = _SurtidoService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByUsuario(int idUsuario)
        {
            var Coleccion = _SurtidoService.getByUsuario(idUsuario);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getBySecretaria(int idSecretaria)
        {
            var Coleccion = _SurtidoService.getBySecretaria(idSecretaria);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByOficina(int idOficina)
        {
            var Coleccion = _SurtidoService.getByOficina(idOficina);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult getByDireccion(int idDireccion)
        {
            var Coleccion = _SurtidoService.getByDireccion(idDireccion);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
    }
}

