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
    }
}

