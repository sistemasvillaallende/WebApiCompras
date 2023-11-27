using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route ("[controller]/[action]")]
    public class RequerimientoController : Controller
    {

        private IRequerimientoService _RequerimientoService;

        public RequerimientoController (IRequerimientoService RequerimientoService) {
            _RequerimientoService = RequerimientoService;
        }

        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Requerimiento = _RequerimientoService.getByPk(Id);
            if (Requerimiento == null)
            {
            return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpPost]
        public IActionResult NuevoRequerimiento(Requerimiento obj)
        {
            if (obj.Items.Count == 0)
            {
                return BadRequest(new {messagge = "No puede generarse un requerimiento sin items"});
            }

            var Id = _RequerimientoService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta el Requerimiento." });
            }
            return Ok(Id);
        }

        [HttpGet]
        public IActionResult getByUsuario(int IdUsuario)
        {
            var Requerimiento = _RequerimientoService.getByUsuario(IdUsuario);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpGet]
        public IActionResult getByOficina(int IdOficina)
        {
            var Requerimiento = _RequerimientoService.getByOficina(IdOficina);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpGet]
        public IActionResult getBySecretaria(int IdSecretaria)
        {
            var Requerimiento = _RequerimientoService.getBySecretaria(IdSecretaria);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpGet]
        public IActionResult getByDireccion(int IdDireccion)
        {
            var Requerimiento = _RequerimientoService.getByDireccion(IdDireccion);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpGet]
        public IActionResult updatePrecios(List<DetalleRequerimiento> lista)
        {
            try
            {
                if (lista != null)
                {
                    _RequerimientoService.updatePrecios(lista);
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
    }
}

