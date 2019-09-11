using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using CommonLib.Interfaces;

namespace CommonLib.Models.Tablon
{
    /// <summary>
    /// Anuncios publicados en el tablón de inicio
    /// </summary>
    public class Anuncio:IItem
    {       
        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Anuncio() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Anuncio(string titulo, string descripcion, DateTime fechaPublicacion, string idUsuarioPublicacion, int? id = default(int?))
        {
            Id = id.HasValue ? id.Value :-1;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaPublicacion = fechaPublicacion;
            IdUsuario = idUsuarioPublicacion;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "titulo")]
        public string Titulo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "idUsuario")]
        public string IdUsuario { get; set; }
       
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
                throw new ValidationException(ValidationRules.CannotBeNull, "IdUsuarioPublicacion");
            }
        }
    }
}
