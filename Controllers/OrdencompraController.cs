using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class OrdencompraController : Controller
{
private IOrdencompraService _OrdencompraService;
public OrdencompraController (IOrdencompraService OrdencompraService) {
_OrdencompraService = OrdencompraService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Ordencompra = _OrdencompraService.getByPk(Id);
if (Ordencompra == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Ordencompra);
}







}
}

