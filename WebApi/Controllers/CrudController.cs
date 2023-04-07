using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        [HttpGet]
        [Route("getDatos")]
        public async Task<IActionResult> ListarDatos()
        {
            //var persona = new { 
            //Nombre="Pepito",
            //Direccion="Las cinco esquinas"
            //};
            //return Ok(persona);
            var lista= await Globales.ServicioWebRemoto.ListarPersonas();

            return Ok(lista.DataTableToJSON());
        }
    }
}
