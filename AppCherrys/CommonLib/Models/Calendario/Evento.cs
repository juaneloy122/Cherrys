using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models.Calendario
{
    /// <summary>
    /// Evento de calendario
    /// </summary>
    public class Evento : IItem
    {

        public Evento() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Evento(string titulo, string descripcion, DateTime fechaInicio, DateTime fechaFin, string idUsuarioPublicacion, int id = -1)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaInicio = fechaInicio ;
            FechaFin = fechaFin;
            IdUsuario = idUsuarioPublicacion;
        }

        public string Cabecera => FechaInicio.ToShortDateString() + " (" + IdUsuario + ") " + Titulo;
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        /// <summary>
        /// Quien crea el evento
        /// </summary>
        public string IdUsuario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
