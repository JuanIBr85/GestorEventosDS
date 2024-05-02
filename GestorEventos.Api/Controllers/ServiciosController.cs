using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiciosController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {   
            ServiciosService serviciosService = new ServiciosService();

            return Ok(serviciosService.GetServiciosDespedida());
        }

        [HttpGet("{IdServicio:int}")]
        public IActionResult GetServicioPorId(int IdServicio) 
        
        {
            ServiciosService serviciosService = new ServiciosService();

            ServicioDS serviciosDespedida = serviciosService.GetServiciosDespedidaPorId(IdServicio);

            if(serviciosDespedida == null)
                return NotFound();
            else
                return Ok(serviciosDespedida);
        }

        [HttpPost("Nuevo")]
        public IActionResult PostNuevoServicio([FromBody]ServicioDS servicionuevo) 
        
        {
            ServiciosService serviciosService = new ServiciosService();
            serviciosService.AgregarServicio(servicionuevo);
            return Ok();
        }

    }
}
