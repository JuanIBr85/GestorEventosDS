﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Eventos
    {       /*Evento: IdEvento, Nombre, FechaEvento, CantPersonas, IdTipoDespedida, IdPersonaAgasajada, IdPersonaContacto
             */
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public int CantPersonas { get; set; }
        public int IdTipoDespedida {  get; set; }
        public int IdPersonaContacto { get; set; }
        public int IdPersonaAgasajada { get; set; }
    }
}
