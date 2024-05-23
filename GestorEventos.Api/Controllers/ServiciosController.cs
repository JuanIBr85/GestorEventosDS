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

            if (serviciosDespedida == null)
                return UnprocessableEntity();
            else
                return Ok(serviciosDespedida);
        }

        [HttpPost("Nuevo")]
        public IActionResult PostNuevoServicio([FromBody] ServicioDS servicioDS)

        {
            ServiciosService serviciosService = new ServiciosService();
            serviciosService.AgregarServicio(servicioDS);
            return Ok();
        }

        // Modificar un recurso existente
        [HttpPut("ModificarServicio/{idServicio:int}")]
        public IActionResult PutNuevoServicio(int idServicio, [FromBody] ServicioDS servicioDS)
        {
            ServiciosService serviciosService = new ServiciosService();
            bool resultado = serviciosService.PutNuevoServicio(idServicio, servicioDS);

            if (resultado)
            {
              return Ok();
            }
            else
            {
             return UnprocessableEntity();
            }
        }

        [HttpDelete("{idServicio:int}/BorrarServicio")]
        public IActionResult DeleteEvento(int IdServicio)
        {
            ServiciosService serviciosService = new ServiciosService();

            bool resultado = serviciosService.DeleteServicio(IdServicio);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity();
            }

        }

    }
}
