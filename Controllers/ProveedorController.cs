using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json;
using WebApiCompras.Services;

namespace WebApiCompras.Controllers
{
[ApiController]
[Route ("[controller]/[action]")]
public class ProveedorController : Controller
{
private IProveedorService _ProveedorService;
public ProveedorController (IProveedorService ProveedorService) {
_ProveedorService = ProveedorService;
}
[HttpGet]
public IActionResult getByPk(
int Id)
{
var Proveedor = _ProveedorService.getByPk(Id);
if (Proveedor == null)
{
return BadRequest(new { message = "Error al obtener los datos" });
}
return Ok(Proveedor);
}







}
}

