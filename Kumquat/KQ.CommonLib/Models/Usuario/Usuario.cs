using KQ.CommonLib.Interfaces;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;

namespace KQ.CommonLib.Models.Usuario
{
    /// <summary>
    /// Contiene los datos nuestros, los que necesita la aplicación logicamente.
    /// </summary>
    public class Usuario:IItem
    {

        public Usuario() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Usuario(int id, string email,string alias, string pwd)
        {
            Id = id;
            Email = email;
            Alias = alias;
            PWD = pwd;
        }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Puesto")]
        public string Puesto { get; set; }

        [JsonProperty(PropertyName = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty(PropertyName = "FechaBaja")]
        public DateTime FechaBaja { get; set; }

        [JsonProperty(PropertyName = "FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Alias")]
        public string Alias { get; set; }

        [JsonProperty(PropertyName = "PWD")]
        public string PWD { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validar()
        {
            if (Nombre == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Nombre");
            }
            if (PWD == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PWD");
            }
            if (Id < 0)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
        }
    }
}
