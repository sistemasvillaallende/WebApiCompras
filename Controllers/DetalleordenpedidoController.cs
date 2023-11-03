using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class DetalleordenpedidoController : Controller
{
private IDetalleordenpedidoService _DetalleordenpedidoService;
public DetalleordenpedidoController (IDetalleordenpedidoService DetalleordenpedidoService) {
_DetalleordenpedidoService = DetalleordenpedidoService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Detalleordenpedido = _DetalleordenpedidoService.getByPk(Id);
if (Detalleordenpedido == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Detalleordenpedido);
}







}
}

