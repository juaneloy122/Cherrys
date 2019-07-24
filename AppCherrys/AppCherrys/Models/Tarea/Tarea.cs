using AppCherrys.Constantes;
using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Tarea
{
    /// <summary>
    /// Define una tarea
    /// </summary>
    public class Tarea : IItem
    {
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
