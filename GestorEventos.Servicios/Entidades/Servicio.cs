using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class ServicioDS
    {
        /*Servicios: IdServicio, Descripcion, PrecioUnitario */

        public int IdServicios {  get; set; }
        public string DescripcionServicio {  get; set; }
        public decimal PrecioUnitarioSs {  get; set; }
        public bool visible { get; set; }
    }
}
