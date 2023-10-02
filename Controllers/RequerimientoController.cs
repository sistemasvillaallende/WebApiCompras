using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class RequerimientoController : Controller
{
private IRequerimientoService _RequerimientoService;
public RequerimientoController (IRequerimientoService RequerimientoService) {
_RequerimientoService = RequerimientoService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Requerimiento = _RequerimientoService.getByPk(Id);
if (Requerimiento == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Requerimiento);
}







}
}

