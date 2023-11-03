using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class SurtidoController : Controller
{
private ISurtidoService _SurtidoService;
public SurtidoController (ISurtidoService SurtidoService) {
_SurtidoService = SurtidoService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Surtido = _SurtidoService.getByPk(Id);
if (Surtido == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Surtido);
}







}
}

