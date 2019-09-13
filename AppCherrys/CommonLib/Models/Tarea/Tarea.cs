using CommonLib.Constantes;
using CommonLib.Interfaces;
using Microsoft.Rest;
using Newtonsoft.Json;
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

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// Quién crea la tarea
        /// </summary> 
        [JsonProperty(PropertyName = "IdUsuario")]
        public string IdUsuario { get; set; }

        /// <summary>
        /// Usuarios asignados para hacer la tarea
        /// </summary> 
        [JsonProperty(PropertyName = "IdUsuariosAsignado")]
        public List<string> IdUsuariosAsignado { get; set; }

        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [JsonProperty(PropertyName = "FechaFin")]
        public DateTime FechaFin { get; set; }

        [JsonProperty(PropertyName = "FechaPrevistaFin")]
        public DateTime FechaPrevistaFin { get; set; }

        [JsonProperty(PropertyName = "Estado")]
        public EstadoTarea Estado { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validar()
        {
            if (Titulo == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Titulo");
            }
            if (Descripcion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Descripcion");
            }
            if (IdUsuario == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IdUsuario");
            }
        }
    }


}
