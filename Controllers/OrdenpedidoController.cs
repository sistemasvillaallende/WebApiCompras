using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class OrdenpedidoController : Controller
{
private IOrdenpedidoService _OrdenpedidoService;
public OrdenpedidoController (IOrdenpedidoService OrdenpedidoService) {
_OrdenpedidoService = OrdenpedidoService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Ordenpedido = _OrdenpedidoService.getByPk(Id);
if (Ordenpedido == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Ordenpedido);
}







}
}

