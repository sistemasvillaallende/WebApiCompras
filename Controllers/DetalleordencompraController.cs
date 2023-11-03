using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;

namespace WebApiCompras.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetalleordencompraController : Controller
    {
        private IDetalleordencompraService _DetalleordencompraService;
        public DetalleordencompraController(IDetalleordencompraService DetalleordencompraService)
        {
            _DetalleordencompraService = DetalleordencompraService;
        }
        [HttpGet]
        public IActionResult getByPk(
        int Id)
        {
            var Detalleordencompra = _DetalleordencompraService.getByPk(Id);
            if (Detalleordencompra == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Detalleordencompra);
        }

        

    }
}

