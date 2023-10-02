using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class InsumosController : Controller
{
private IInsumosService _InsumosService;
public InsumosController (IInsumosService InsumosService) {
_InsumosService = InsumosService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Insumos = _InsumosService.getByPk(Id);
if (Insumos == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Insumos);
}







}
}

