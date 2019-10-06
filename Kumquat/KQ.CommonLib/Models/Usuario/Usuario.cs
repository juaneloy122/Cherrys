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
            
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "DNI")]
        public string DNI { get; set; }

        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Apellidos")]
        public string Apellidos { get; set; }

        [JsonProperty(PropertyName = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty(PropertyName = "FechaBaja")]
        public DateTime FechaBaja { get; set; }
       
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Normalmente el nombre, pero puede tener un mote en la empresa
        /// </summary>
        [JsonProperty(PropertyName = "Alias")]
        public string Alias { get; set; }

        [JsonProperty(PropertyName = "PWD")]
        public string PWD { get; set; }

        /// <summary>
        /// Indica el identificador del usuario que lo dió de alta
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuarioAlta")]
        public int IdUsuarioAlta { get; set; }

        /// <summary>
        /// Comprueba que se metieron los campos requeridos. Throws ValidationException si falla la validación.
        /// </summary>
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty (Nombre))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Nombre");
            }

            if (string.IsNullOrEmpty(DNI))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DNI");
            }
            if (string.IsNullOrEmpty(PWD))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PWD");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Email");
            }
            if (Id < 0)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
            if (IdUsuarioAlta < 0)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IdUsuarioAlta");
            }
        }
    }
}
