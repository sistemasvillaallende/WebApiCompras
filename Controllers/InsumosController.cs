using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;


namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route ("[controller]/[action]")]
    public class InsumosController : Controller
    {
        private IInsumosService _InsumosService;
        public InsumosController (IInsumosService InsumosService) {
        _InsumosService = InsumosService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
        var Insumos = _InsumosService.getByPk(Id);
        if (Insumos == null)
        {
        return BadRequest(new { message = "Error al obtener los datos" });
        }
        return Ok(Insumos);
        }
        [HttpPost]
        public IActionResult NuevaColeccion(Insumos obj)
        {
            var Id = _InsumosService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta el Insumo." });
            }
            return Ok(Id);
        }

        [HttpPost]
        public IActionResult UpdateInsumo(Insumos obj)
        {
            try
            {
                if (obj != null)
                {
                    _InsumosService.update(obj);
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
            var Coleccion = _InsumosService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }

        [HttpGet]
        public IActionResult getByCuenta(string cuenta)
        {
            var Coleccion = _InsumosService.getByCuenta(cuenta);
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }

    }
}

