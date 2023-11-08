using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedorController : Controller
    {
        private IProveedorService _ProveedorService;
        public ProveedorController(IProveedorService ProveedorService)
        {
            _ProveedorService = ProveedorService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Proveedor = _ProveedorService.getByPk(Id);
            if (Proveedor == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Proveedor);
        }

        [HttpPost]
        public IActionResult NuevoProveedor(Proveedor obj)
        {
            var Id = _ProveedorService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta el Proveedor." });
            }
            return Ok(Id);
        }

        [HttpGet]
        public IActionResult getByActivo(bool activo)
        {
            var Requerimiento = _ProveedorService.getByActivo(activo);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }
        
        [HttpGet]
        public IActionResult getByNombre(string nombre)
        {
            var Requerimiento = _ProveedorService.getByNombre(nombre);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpGet]
        public IActionResult getByTipo(string tipo)
        {
            var Requerimiento = _ProveedorService.getByNombre(tipo);
            if (Requerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Requerimiento);
        }

        [HttpGet]
        public IActionResult read()
        {
            var Proveedor = _ProveedorService.read();
            if (Proveedor == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Proveedor);
        }

        [HttpPost]
        public IActionResult UpdateProveedor(Proveedor obj)
        {
            try
            {
                if (obj != null)
                {
                    _ProveedorService.update(obj);
                    return Ok(new { message = "Proveedor actualizado exitosamente" });
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
    }
}

