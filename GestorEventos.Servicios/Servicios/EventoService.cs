using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class EventoService
    {
        public IEnumerable<Evento> ElEvento {  get; set; }


        public EventoService() 
        
        {
            ElEvento = new List<Evento>()
            {
                new Evento {IdEvento=1, CantPersonas=24,FechaEvento=DateTime.Now,IdPersonaAgasajada=3,IdPersonaContacto=1,IdTipoDespedida=2,NombreEvento="Fiesta disfraces Oscar",Visible=true },
                new Evento {IdEvento=2, CantPersonas=12,FechaEvento=DateTime.Now,IdPersonaAgasajada=1,IdPersonaContacto=2,IdTipoDespedida=1,NombreEvento="Gira por boliches",Visible=true },
                new Evento {IdEvento=3, CantPersonas=10,FechaEvento=DateTime.Now,IdPersonaAgasajada=2,IdPersonaContacto=3,IdTipoDespedida=2,NombreEvento="Fiesta disfraces Pablo",Visible=true },
            };
        }

        public IEnumerable<Evento> GetEventoDespedida()

        {
            return this.ElEvento.Where(x=> x.Visible ==true); // trae solo los evento visible, luego de hacer un borrado logico
        }

        public Evento GetEventoDespedidaPorId(int IdEvento) 
        
        {
            try 
            {
                Evento evento = ElEvento.Where(x=> x.IdEvento==IdEvento).First();
                return evento;
            } 
            catch (Exception)
           
            {
                return null;
            }
        }


        public bool AgregarEvento(Evento evento)
        {
            try
            {
                List < Evento > lista= this.ElEvento.ToList(); //  agrega un evento a la lista ElEvento
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool PutNuevoEvento(int IdEvento, Evento evento)
        {
            try
            {
                var eventoDeLista = this.ElEvento.Where(x => x.IdEvento == IdEvento).First(); //LINQ o manejo de listas reemplaza el foreach
                // modifica el evento
         
                eventoDeLista.FechaEvento = evento.FechaEvento;
                eventoDeLista.NombreEvento = evento.NombreEvento;
                eventoDeLista.CantPersonas = evento.CantPersonas;
                eventoDeLista.IdPersonaAgasajada = evento.IdPersonaAgasajada;
                eventoDeLista.IdPersonaContacto = evento.IdPersonaContacto;

                return true;

            }
            catch (Exception)
            {
              return false; 
            }

        }
        
        public bool DeleteEvento(int IdEvento) 
        {
            try 
            {
                var eventoAEliminar = this.ElEvento.Where(x => x.IdEvento == IdEvento).First();

                var listaEvento = this.ElEvento.ToList();
                /* Borrado fisico*/
                listaEvento.Remove(eventoAEliminar);

                /* borrador logico*/

                eventoAEliminar.Visible = false;

                return true;        
            }

            catch (Exception)
            
            { 
                return false;
            
            }
        }
    } 
        
}
