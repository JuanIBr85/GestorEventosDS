using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{           // Una entidad que representa a las personas del sistema  
    public class Persona
    {
        /*Personas: IdPersona, Nombre, Apellido, Teléfono, Email, DireccionCalle, DireccionNumero, DireccionPiso, DireccionDepartamento, DireccionIdLocalidad
       
         */
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionNumero { get; set; }
        public string DireccionPiso { get; set; }
        public string DireccionDepartamento { get; set; }

        public string DireccionCodigoPostal { get; set; }
        public bool visible { get; set; }

    }
}
