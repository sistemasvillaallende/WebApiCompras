using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;
using WebApiCompras.Entities;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallerequerimientoController : Controller
    {
        private IDetalleRequerimientoService _DetalleRequerimientoService;
        public DetallerequerimientoController(IDetalleRequerimientoService DetallerequerimientoService)
        {
            _DetalleRequerimientoService = DetallerequerimientoService;
        }
        [HttpGet]
        public IActionResult getByPk(int Id)
        {
            var Detallerequerimiento = _DetalleRequerimientoService.getByPk(Id);
            if (Detallerequerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detallerequerimiento);
        }
        [HttpPost]
        public IActionResult NuevoDetalleRequerimiento(DetalleRequerimiento obj)
        {
            var Id = _DetalleRequerimientoService.insert(obj);
            if (Id.ToString() == null)
            {
                return Ok(new { message = "Error no se pudo dar de Alta el Requerimiento." });
            }
            return Ok(Id);
        }
        [HttpPost]
        public IActionResult UpdateDetalleRequerimiento(DetalleRequerimiento obj)
        {
            try
            {
                if (obj != null)
                {
                    _DetalleRequerimientoService.update(obj);
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
            var Coleccion = _DetalleRequerimientoService.read();
            if (Coleccion == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Coleccion);
        }
        [HttpGet]
        public IActionResult delete(DetalleRequerimiento obj)
        {
            _DetalleRequerimientoService.delete(obj);
            var detalleordencompra = _DetalleRequerimientoService.getByPk(obj.Id);
            if (detalleordencompra != null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(detalleordencompra);
        }
        [HttpGet]
        public IActionResult getByOrdenPedido(int idRequerimiento)
        {
            var Detallerequerimiento = _DetalleRequerimientoService.getByIdRequerimiento(idRequerimiento);
            if (Detallerequerimiento == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detallerequerimiento);
        }
    }
}

