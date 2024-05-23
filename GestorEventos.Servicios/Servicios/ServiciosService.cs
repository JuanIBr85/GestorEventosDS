using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class ServiciosService
    {
        public IEnumerable<ServicioDS> ServiciosDespedida { get; set; }

        public ServiciosService ()
            {
            ServiciosDespedida = new List<ServicioDS>()
            {
                new ServicioDS {IdServicios=1,DescripcionServicio="Bus", PrecioUnitarioSs=50000},
                new ServicioDS {IdServicios=2,DescripcionServicio="Enano locos", PrecioUnitarioSs=25000},
                new ServicioDS {IdServicios=3,DescripcionServicio="Barra", PrecioUnitarioSs=35000},
            };
            }
        public IEnumerable<ServicioDS> GetServiciosDespedida() 
        
        {
            return this.ServiciosDespedida;       
        }
        public ServicioDS GetServiciosDespedidaPorId(int IdServicios)
        {
            try
            {
                ServicioDS serviciosDespedida = ServiciosDespedida.Where(x => x.IdServicios == IdServicios).First();
                return serviciosDespedida;
            }
            catch (Exception) // esto es a modo de simplificar el codigo, la excepcion hay que informarla
            {
                return null;

            }
        }

        public bool AgregarServicio (ServicioDS servicio) 
        
        {
            try 
            {
                List<ServicioDS> lista = this.ServiciosDespedida.ToList();
                lista.Add(servicio);
                return true;
            }catch (Exception) 
            {
                return false;
            }
        }

        public bool PutNuevoServicio (int IdServicios, ServicioDS servicioDS) 
        {
            try
            {
                var servicioDeLista = this.ServiciosDespedida.Where(x => x.IdServicios == IdServicios).First(); //LINQ o manejo de listas reemplaza el foreach
                                                                                                                // modifica el evento
                servicioDeLista.DescripcionServicio = servicioDS.DescripcionServicio;
                servicioDeLista.PrecioUnitarioSs = servicioDS.PrecioUnitarioSs;

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteServicio (int IdServicios)         
        {
            try
            {
                var servicioAEliminar = this.ServiciosDespedida.Where(x => x.IdServicios == IdServicios).First();

                var listaServicios = this.ServiciosDespedida.ToList();

                servicioAEliminar.visible = false;

                return true;
            }

            catch (Exception)

            {
                return false;

            }
        }
    }
}
