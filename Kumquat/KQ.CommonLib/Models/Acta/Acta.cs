using KQ.CommonLib.Interfaces;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KQ.CommonLib.Models.Acta
{
    /// <summary>
    /// Acta publicada
    /// </summary>
    public class Acta : IItem
    {
        public Acta() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Acta(string titulo, string descripcion, DateTime fecha, string rutaDocumento, string idUsuarioPublicacion, int id = -1)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            Fecha = fecha;
            IdUsuario = idUsuarioPublicacion;
            RutaDocumento = rutaDocumento;
        }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Titulo")]
        public string Titulo { get; set; }

        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "Fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty(PropertyName = "RutaDocumento")]
        public string RutaDocumento { get; set; }

        [JsonProperty(PropertyName = "RutaAdjuntos")]
        public List<string> RutaAdjuntos { get; set; }

        /// <summary>
        /// Quien sube el acta
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuario")]
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
                throw new ValidationException(ValidationRules.CannotBeNull, "IdUsuario");
            }
        }
    }
}
