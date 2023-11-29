using Microsoft.AspNetCore.Mvc;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallepresupuestoordencompraController : Controller
    {
        private IDetallepresupuestoordencompraService _DetallepresupuestoordencompraService;
        public DetallepresupuestoordencompraController(IDetallepresupuestoordencompraService DetallepresupuestoordencompraService)
        {
            _DetallepresupuestoordencompraService = DetallepresupuestoordencompraService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Detallepresupuestoordencompra = _DetallepresupuestoordencompraService.getByPk(Id);
            if (Detallepresupuestoordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detallepresupuestoordencompra);
        }
        [HttpPost]
        public IActionResult NuevoDetallepresupuestoordencompra(DetallePresupuestoOrdenCompra obj)
        {
            var Id = _DetallepresupuestoordencompraService.insert(obj);

            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta un surtido." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateDetallepresupuestoordencompra(DetallePresupuestoOrdenCompra obj)
        {
            try
            {
                if (obj != null)
                {
                    _DetallepresupuestoordencompraService.update(obj);
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
            var Coleccion = _DetallepresupuestoordencompraService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult delete(DetallePresupuestoOrdenCompra obj)
        {
            _DetallepresupuestoordencompraService.delete(obj);
            var Detallepresupuestoordencompra = _DetallepresupuestoordencompraService.getByPk(obj.Id);
            if (Detallepresupuestoordencompra != null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detallepresupuestoordencompra);
        }
        [HttpGet]
        public IActionResult getByIdPresupuestoOrdenCompra(int idPresupuestoOrdenCompra)
        {
            var Detallepresupuestoordencompra = _DetallepresupuestoordencompraService.getByIdPresupuestoOrdenCompra(idPresupuestoOrdenCompra);
            if (Detallepresupuestoordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detallepresupuestoordencompra);
        }


    }
}

