using KQ.CommonLib.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KQ.CommonLib.Models.Usuario
{
    /// <summary>
    /// Contiene los datos nuestros, los que necesita la aplicación logicamente.
    /// </summary>
    public class Usuario:IItem
    {

        public Usuario() { }

        [Required]
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// DNI con formato 00000000L.
        /// Se puede usar la utilidad ValidacionDNI.GetDNIFormatoValido  de ST.Utilidades para facilitar esto
        /// </summary>
        [Required]
        [StringLength (9)]
        [JsonProperty(PropertyName = "DNI")]
        public string DNI { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [JsonProperty(PropertyName = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(100, MinimumLength = 4)]
        [JsonProperty(PropertyName = "Apellidos")]
        public string Apellidos { get; set; }

        [JsonProperty(PropertyName = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty(PropertyName = "FechaBaja")]
        public DateTime FechaBaja { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Normalmente el nombre, pero puede tener un mote en la empresa
        /// </summary>
        [StringLength(50, MinimumLength = 4)]
        [JsonProperty(PropertyName = "Alias")]
        public string Alias { get; set; }

        [Required]
        [JsonProperty(PropertyName = "PWD")]
        public string PWD { get; set; }

        /// <summary>
        /// Indica el identificador del usuario que lo dió de alta
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuarioAlta")]
        public int IdUsuarioAlta { get; set; }


        /// <summary>
        /// Con true, significa que la primera vez que se conecte tiene que meter una contraseña nueva
        /// </summary>
        [JsonProperty(PropertyName = "NecesitaActualizarPWD")]
        public bool NecesitaActualizarPWD { get; set; }

        /// <summary>
        /// Comprueba que se metieron los campos requeridos. Throws ValidationException si falla la validación.
        /// </summary>
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty (Nombre))
            {
                throw new ValidationException("Es necesario incluir el campo Nombre");
            }

            if (string.IsNullOrEmpty(DNI))
            {
                throw new ValidationException("Es necesario incluir el campo DNI");
            }
            if (string.IsNullOrEmpty(PWD))
            {
                throw new ValidationException("Es necesario incluir el campo PWD");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new ValidationException("Es necesario incluir el campo Email");
            }
            if (Id < 0)
            {
                throw new ValidationException("Es necesario incluir el campo Id");
            }
            if (IdUsuarioAlta < 0)
            {
                throw new ValidationException("Es necesario incluir el campo IdUsuarioAlta");
            }
        }
    }
}
