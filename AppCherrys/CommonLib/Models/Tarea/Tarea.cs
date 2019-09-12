using CommonLib.Constantes;
using CommonLib.Interfaces;
using System;
using System.Collections.Generic;

namespace CommonLib.Models.Tarea
{
    /// <summary>
    /// Define una tarea
    /// </summary>
    public class Tarea : IItem
    {

        public Tarea() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Tarea(string titulo, string descripcion, DateTime fechaInicio, DateTime fechaFin, string idUsuarioPublicacion, int id = -1)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            IdUsuario = idUsuarioPublicacion;
        }

        public string Cabecera => FechaInicio.ToShortDateString() + " (" + IdUsuario + ") " + Titulo;
        public int Id { get; set; }
        public string Titulo { get; set; }

        /// <summary>
        /// Quién crea la tarea
        /// </summary>
        public string IdUsuario { get; set; }
        /// <summary>
        /// Usuarios asignados para hacer la tarea
        /// </summary>
        public List<string> IdUsuariosAsignado { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaPrevistaFin { get; set; }

        public EstadoTarea Estado { get; set; }
    }


}
