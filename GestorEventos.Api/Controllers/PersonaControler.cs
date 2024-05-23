using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PersonaControler : Controller
    {
        [HttpGet]
        public IActionResult Get() // devuelve la lista de elementos, en este caso una lista de personas
        {
            PersonaService personaService = new PersonaService(); // Instancia de PersonaService, llama al contructor y va a instanciar la lista de PersodasDePrueba

            return Ok(personaService.GetPersonasDePrueba());
        }

        // devuelve un elemento , en este caso una persona
        [HttpGet("{IdPersona:int}")]
        public IActionResult GetPesonaPorId(int IdPersona)
        {
            PersonaService personaService = new PersonaService();

            Persona persona = personaService.GetPersonaDePruebaSegunId(IdPersona);

            if (persona == null)
                return UnprocessableEntity();
            else
                return Ok(persona);
        }

        [HttpPost("ALtaPersona")]

        public IActionResult PostNuevaPersona([FromBody] Persona persona)
        {
            PersonaService personaService = new PersonaService();

            bool resultado = personaService.PostNuevaPersona(persona);

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
        [HttpPut("ModificarPersona/{idPersona:int}")]
        public IActionResult PutNuevaPersona(int idPersona, [FromBody] Persona persona)
        {
            PersonaService personaService = new PersonaService();
            bool resultado = personaService.PutNuevaPersona(idPersona, persona);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        // borrado logico
        [HttpDelete("{idPersona:int}/BorrarPersona")]
        public IActionResult DeletePersona(int idPersona)
        {
            PersonaService personaService = new PersonaService();
            bool resultado = personaService.DeletePersona(idPersona);

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