using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService
    {
        // Utilizacion de un IEnumerable para establecer una listad de entidades   
        public IEnumerable<Persona> PersonasDePrueba { get; set; }

        // Constructor de PersonaService
        public PersonaService()
        {

            PersonasDePrueba = new List<Persona>
        {

            new Persona() {IdPersona=1,Nombre="Jose",Apellido="Perez",DireccionCalle="Los Patos",DireccionNumero="1384",DireccionCodigoPostal="7540",DireccionDepartamento="-",DireccionPiso="-",Telefono="22222222",Email="jose_p@gmail.com"},
            new Persona() {IdPersona=2,Nombre="Marcelo",Apellido="Gonzales",DireccionCalle="Remedios",DireccionNumero="1340",DireccionCodigoPostal="7540",DireccionDepartamento="2",DireccionPiso="-",Telefono="2556562222",Email="gonzales.marcelo@gmail.com"},
            new Persona() {IdPersona=3,Nombre="Jose",Apellido="Garcia",DireccionCalle="San Martin",DireccionNumero="1200",DireccionCodigoPostal="8000",DireccionDepartamento="A",DireccionPiso="3",Telefono="22226542",Email="garcia859@gmail.com"}
        };

        }
        // Para consultar "PersonasDePrueba"
        public IEnumerable<Persona> GetPersonasDePrueba()
        {
            return PersonasDePrueba;
        }
        /*Metodo que a partir de un IdPersona, busca dentro de la lista de PersonasDePrueba, utilizando una condición. En lugar de recorrer todo el array, utilizamos una herramienta que
         permite filtrar en la lista segun el Id devolviendo la primera coincidencia, denominada LINQ. 
         */

        // Una de las cosas a tener en cuenta al momento de desarrollar una API, una es el manejo de errores, una de las formas es segurizando la aplicacion
        public Persona GetPersonaDePruebaSegunId(int IdPersona) // ? indica que persona es opcional
        {
            
            // Manejo del error segurizando la aplicacion.
        /*
            var SubListaPerosnasDePrueba = PersonasDePrueba.Where(x => x.IdPersona == IdPersona); // var xxxx = es igual a las personas que existan.
            
            if (SubListaPerosnasDePrueba == null)
                return null;

            return SubListaPerosnasDePrueba.First();
        */
            // Manejo del error mediante el manejo de excepciones. En este caso, si no encuentra nunguna persona con el Id devuelve un codigo 404 (Not found).

            try
            {
                Persona persona = PersonasDePrueba.Where(x => x.IdPersona == IdPersona).First();
                return persona;
            }
            catch (Exception) // esto es a modo de simplificar el codigo, la excepcion hay que informarla
            {
                return null;

            }
        }
    }
}
