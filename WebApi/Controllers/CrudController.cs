﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        [Route("RegistrarPersona")]
        public async Task<IActionResult> RegistarDaos([FromBody] Persona ent )
        {
            var res = await Globales.ServicioWebRemoto.RegistrarPersona(ent);
            return Ok(res);
        }

        [HttpPost]
        [Route("EliminarPersona")]
        public async Task<IActionResult> EliminarPersona([FromBody] Persona ent)
        {
            var res = await Globales.ServicioWebRemoto.EliminarPersona(ent);
            return Ok(res);
        }

        [HttpPost]
        [Route("ActualizarPersona")]
        public async Task<IActionResult> ActualizarPersona([FromBody] Persona ent)
        {
            var res = await Globales.ServicioWebRemoto.ActualizarPersona(ent);
            return Ok(res);
        }

    }
}
