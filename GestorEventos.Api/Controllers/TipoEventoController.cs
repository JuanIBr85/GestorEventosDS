using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TipoEventoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
          TipoEventoService tipoEventoService = new TipoEventoService();
            return Ok(tipoEventoService.GetTipoEventos());
        }

        [HttpGet("{IdTipoEvento:int}")]
        public IActionResult GetTipoEventoId(int IdTipoEvento)
        {
            TipoEventoService tipoEventoService = new TipoEventoService();

            TipoEvento tipoEvento = tipoEventoService.GetTipoEventoPorId(IdTipoEvento);

            if (tipoEvento == null)
                return UnprocessableEntity();
            else
            return Ok(tipoEvento);
        }
    }
}
