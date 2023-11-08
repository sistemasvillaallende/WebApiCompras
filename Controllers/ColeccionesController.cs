using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ColeccionesController : Controller
    {
        private IColeccionesService _ColeccionesService;
        public ColeccionesController(IColeccionesService ColeccionesService)
        {
            _ColeccionesService = ColeccionesService;
        }

        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Colecciones = _ColeccionesService.getByPk(Id);
            if (Colecciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Colecciones);
        }

        [HttpPost]
        public IActionResult NuevaColeccion(Colecciones obj)
        {
            var Id = _ColeccionesService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta el Colecciones." });
            }
            return Ok(Id);
        }

        [HttpPost]
        public IActionResult UpdateColeccion(Colecciones obj)
        {
            try
            {
                if (obj != null)
                {
                    _ColeccionesService.update(obj);
                    return Ok(new { message = "Coleccion actualizado exitosamente" });
                }
                else
                {
                    return BadRequest(new { message = "Los datos de entrada no son válidos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el proveedor" });
            }
        }

        [HttpGet]
        public IActionResult read()
        {
            var Coleccion = _ColeccionesService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }

        [HttpGet]
        public IActionResult getByNombre(string nombre)
        {
            var Coleccion = _ColeccionesService.getByNombre(nombre);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
    }
}

