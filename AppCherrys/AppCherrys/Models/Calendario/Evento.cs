using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Calendario
{
    /// <summary>
    /// Evento de calendario
    /// </summary>
    public class Evento : IItem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
