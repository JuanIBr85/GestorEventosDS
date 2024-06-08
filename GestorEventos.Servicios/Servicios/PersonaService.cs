using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService
    {
        // Utilizacion de un IEnumerable para establecer una listad de entidades   
        // public IEnumerable<Persona> PersonasDePrueba { get; set; } (se comenta para que utilizar la coneccion a la DB)

        private string _connectionString;
        // Constructor de PersonaService
        public PersonaService()
        {

            // Connection String 
            _connectionString = "Data Source=Jimi-Floyd\\SQLEXPRESS;Initial Catalog=BDDespedidas;User ID=sa;Password=12345678;Persist Security Info=True"; // instancia de SQL Server Express, aquí tienes la connection string correcta

            /*   PersonasDePrueba = new List<Persona>
           {

               new Persona() {IdPersona=1,Nombre="Jose",Apellido="Perez",DireccionCalle="Los Patos",DireccionNumero="1384",DireccionCodigoPostal="7540",DireccionDepartamento="-",DireccionPiso="-",Telefono="22222222",Email="jose_p@gmail.com"},
               new Persona() {IdPersona=2,Nombre="Marcelo",Apellido="Gonzales",DireccionCalle="Remedios",DireccionNumero="1340",DireccionCodigoPostal="7540",DireccionDepartamento="2",DireccionPiso="-",Telefono="2556562222",Email="gonzales.marcelo@gmail.com"},
               new Persona() {IdPersona=3,Nombre="Jose",Apellido="Garcia",DireccionCalle="San Martin",DireccionNumero="1200",DireccionCodigoPostal="8000",DireccionDepartamento="A",DireccionPiso="3",Telefono="22226542",Email="garcia859@gmail.com"}
           };*/

        }
        // Para consultar "PersonasDePrueba"
        public IEnumerable<Persona> GetPersonasDePrueba()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))

            {
                List<Persona> personas = db.Query<Persona>("SELECT * FROM Personas WHERE Visible = 0").ToList();

                return personas;
            }

            // return PersonasDePrueba;
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


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Persona persona = db.Query<Persona>("SELECT * FROM Personas WHERE IdPersona =" + IdPersona.ToString()).FirstOrDefault();
                return persona;
            }

            /*
              try
              {
                  Persona persona = PersonasDePrueba.Where(x => x.IdPersona == IdPersona).First();
                  return persona;
              }
              catch (Exception) // esto es a modo de simplificar el codigo, la excepcion hay que informarla
              {
                  return null;

              }
            */
        }

        public bool PostNuevaPersona(Persona persona)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Personas (Nombre,Apellido,Telefono,Email,DireccionCalle,DireccionNumero,DireccionPiso,DireccionDepartamento,DireccionCodPostal) VALUES(@Nombre,@Apellido,@Telefono,@Email,@DireccionCalle,@DireccionNumero,@DireccionPiso,@DireccionDepartamento,@DireccionCodPostal)";
                db.Execute(query, persona);
                return true;

            }

            /*try 
            {
                List<Persona> lista = this.PersonasDePrueba.ToList();

                return true;
            }
            catch (Exception) 
           
            {
                return false;
            }*/
        }

        public bool PutNuevaPersona(int idPersona, Persona persona)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string qwery = "UPDATE Personas SET Nombre = @Nombre, Apellido= @Apellido, Telefono= @Telefono, Email = @Email, DireccionCalle = @DireccionCalle, DireccionNumero=@DireccionNumero, DireccionPiso=@DireccionPiso,DireccionDepartamento=@DireccionDepartamento,DireccionCodPostal=@DireccionCodPostal WHERE IdPersona = " + idPersona.ToString();
                db.Execute(qwery, persona);
                return true;

            }


            /*
            try 
            {
                var personaDeLista = this.PersonasDePrueba.Where(x => x.IdPersona == idPersona).First(); //LINQ o manejo de listas reemplaza el foreach

                personaDeLista.Nombre= persona.Nombre;
                personaDeLista.Apellido= persona.Apellido;
                personaDeLista.Telefono= persona.Telefono;
                personaDeLista.Email= persona.Email;
                personaDeLista.DireccionCalle= persona.DireccionCalle;
                personaDeLista.DireccionCodigoPostal=persona.DireccionCodigoPostal;
                personaDeLista.DireccionPiso = persona.DireccionPiso;
                personaDeLista.DireccionNumero= persona.DireccionNumero;
                personaDeLista.DireccionDepartamento = persona.DireccionDepartamento;
                personaDeLista.visible= persona.visible;

                return true;
            }
            catch (Exception)
            {
                return false;
            }*/
        }
        //borrado logico
        public bool BorradoLogicoPersona(int idPersona)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string qwery = "UPDATE Personas SET Visible = 1 WHERE IdPersona = " + idPersona.ToString();
                db.Execute(qwery);
                return true;

            }

            /*
            try
            {
                var personaAEliminar = this.PersonasDePrueba.Where(x => x.IdPersona == idPersona).First();

                var listaPersonas = this.PersonasDePrueba.ToList();

                personaAEliminar.visible = false;

                return true;
            }

            catch (Exception)

            {
                return false;

            }*/

        }

        //borrado Fisico
        public bool BorradoFisicoPersona(int idPersona)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string qwery = "DELETE FROM dbo.Personas WHERE IdPersona = " + idPersona.ToString();
                db.Execute(qwery);
                return true;

            }

        }

    }
}
