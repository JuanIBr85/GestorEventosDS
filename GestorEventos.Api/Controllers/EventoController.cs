using System.Diagnostics.CodeAnalysis;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : Controller
    {
        [HttpGet]
        public IActionResult GetAllEvento()
        {
            EventoService eventoService = new EventoService();

            return Ok(eventoService.GetEventoDespedida());
        }

        [HttpGet("{IdEvento:int}")]

        public IActionResult GetEventoDespedidaPorId(int IdEvento)
        {
            EventoService eventoService = new EventoService();

            Evento evento = eventoService.GetEventoDespedidaPorId(IdEvento);

            if (evento == null)
                return UnprocessableEntity();
            else
                return Ok(evento);

        }

        [HttpPost("NuevoEvento")]

        public IActionResult PostNuevoEvento([FromBody] Evento evento)
        {
            EventoService eventoService = new EventoService();

            bool resultado = eventoService.AgregarEvento(evento);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity();

            }
        }
        // Modificar un recurso existente
        [HttpPut("ModificarEvento/{idEvento:int}")]
        public IActionResult PutNuevoEvento(int idEvento, [FromBody] Evento evento) 
        {
            EventoService eventoService = new EventoService();
            bool resultado = eventoService.PutNuevoEvento(idEvento, evento);

            if (resultado)           
            {
                return Ok();
            }
            else 
            {
                return UnprocessableEntity();
            }

        }
        [HttpDelete("{idEvento:int}/Borrar")]
        public IActionResult DeleteEvento(int idEvento)
        {
            EventoService eventoService = new EventoService();

            bool resultado = eventoService.DeleteEvento(idEvento);

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
