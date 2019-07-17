using AppCherrys.Constantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Tarea
{
    /// <summary>
    /// Define una tarea
    /// </summary>
    public class Tarea
    {
        public string Id { get; set; }
        public List<string> IdUsuariosAsignado { get; set; }
        public string Description { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaPrevistaFin { get; set; }

        public EstadoTarea Estado { get; set; }
    }

    
}
