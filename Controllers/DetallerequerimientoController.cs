using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class DetallerequerimientoController : Controller
{
private IDetallerequerimientoService _DetallerequerimientoService;
public DetallerequerimientoController (IDetallerequerimientoService DetallerequerimientoService) {
_DetallerequerimientoService = DetallerequerimientoService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Detallerequerimiento = _DetallerequerimientoService.getByPk(Id);
if (Detallerequerimiento == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Detallerequerimiento);
}







}
}

