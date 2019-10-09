using KQ.CommonLib.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KQ.CommonLib.Models.Incidencia
{
    public enum EnumTipoIncidencia { Normal, AltaUsuario};

    /// <summary>
    /// Anuncios publicados en el tablón de inicio
    /// </summary>
    public class Incidencia : IItem
    {
        
        public Incidencia() { }

       
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [JsonProperty(PropertyName = "Titulo")]
        public string Titulo { get; set; }

        
        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        
        [JsonProperty(PropertyName = "FechaPublicacion")]
        public DateTime FechaPublicacion { get; set; }

        
        [JsonProperty(PropertyName = "FechaValidacion")]
        public DateTime FechaValidacion { get; set; }

       
        [JsonProperty(PropertyName = "FechaResuelta")]
        public DateTime FechaResuelta { get; set; }

        /// <summary>
        /// usuario que envío la incidencia
        /// </summary>
        [Required]
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
       /// Puede tener mensaje de respuesta
       /// </summary>
        [JsonProperty(PropertyName = "Respuesta")]
        public string Respuesta { get; set; }


        /// <summary>
        /// Indica el tipo de incidencia que puede ser, por ejemplo alta de usuario 
        /// </summary>
        [JsonProperty(PropertyName = "TipoIncidencia")]
        public EnumTipoIncidencia TipoIncidencia { get; set; } = EnumTipoIncidencia.Normal;
        
        /// <summary>
        ///Valida que el objeto tenga los datos necesarios
        /// </summary>
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty (Titulo))
            {
                throw new ValidationException("Es necesario incluir el campo Titulo");
            }
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new ValidationException("Es necesario incluir el campo Descripcion");
            }
            if (IdUsuario <0)
            {
                throw new ValidationException("Es necesario incluir el campo IdUsuario");
            }
        }
    }
}
