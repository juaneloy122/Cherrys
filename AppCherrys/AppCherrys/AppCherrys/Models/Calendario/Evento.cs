using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Calendario
{
    /// <summary>
    /// Evento de calendario
    /// </summary>
    public class Evento
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
