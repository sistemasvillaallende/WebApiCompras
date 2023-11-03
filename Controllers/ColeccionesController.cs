using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using WebApiCompras.Services;

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
        public IActionResult getByPk(
        int Id)
        {
            var Colecciones = _ColeccionesService.getByPk(Id);
            if (Colecciones == null)
            {
                return BadRequest(new { message = "Error al obtener los datos" });
            }
            return Ok(Colecciones);
        }







    }
}

