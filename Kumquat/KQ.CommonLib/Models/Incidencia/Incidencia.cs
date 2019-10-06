using KQ.CommonLib.Interfaces;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;

namespace KQ.CommonLib.Models.Incidencia
{
    /// <summary>
    /// Anuncios publicados en el tablón de inicio
    /// </summary>
    public class Incidencia : IItem
    {
        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Incidencia() { }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FechaValidacion")]
        public DateTime FechaValidacion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "FechaResuelta")]
        public DateTime FechaResuelta { get; set; }

        /// <summary>
        /// usuario que envío la incidencia
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuario")]
        public int IdUsuario { get; set; }

        /// <summary>
        /// usuario que valido la incidencia
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuarioValidacion")]
        public int IdUsuarioValidacion { get; set; }

        /// <summary>
        /// usuario que cerró la incidencia
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuarioResolucion")]
        public int IdUsuarioResolucion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Respuesta")]
        public string Respuesta { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty (Titulo))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Titulo");
            }
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Descripcion");
            }
            if (IdUsuario <0)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IdUsuario");
            }
        }
    }
}
