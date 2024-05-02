using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class TipoEventoService

    {
        public IEnumerable<TipoEvento> TiposDeEvento { get; set; }  
        
        //Constructor de TipoEventoService 
        public TipoEventoService() 
        {
            TiposDeEvento = new List<TipoEvento>()

            {
                new TipoEvento{IdTipoEvento=1, Descripcion="Despedida de solteros" },
                new TipoEvento{IdTipoEvento=2, Descripcion="Despedida de solteras" },
            };
        }

        public IEnumerable<TipoEvento> GetTipoEventos() 
        {  
            return TiposDeEvento;
        }

        public TipoEvento GetTipoEventoPorId (int IdTipoEvento)
        {
            try
            {
                TipoEvento tipoEvento = TiposDeEvento.Where(x => x.IdTipoEvento == IdTipoEvento).First();
                return tipoEvento;
            }
            catch (Exception) // esto es a modo de simplificar el codigo, la excepcion hay que informarla
            {
                return null;

            }
        }
    
    }
}
