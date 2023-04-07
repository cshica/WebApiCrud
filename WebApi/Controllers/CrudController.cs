using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        [HttpGet]
        [Route("getDatos")]
        public IActionResult ListarDatos()
        {
            var persona = new { 
            Nombre="Pepito",
            Direccion="Las cinco esquinas"
            };
            return Ok(persona);
        }
    }
}
