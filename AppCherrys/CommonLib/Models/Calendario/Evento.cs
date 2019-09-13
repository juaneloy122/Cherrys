using CommonLib.Interfaces;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models.Calendario
{
    /// <summary>
    /// Evento de calendario
    /// </summary>
    public class Evento : IItem
    {

        public Evento() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Evento(string titulo, string descripcion, DateTime fechaInicio, DateTime fechaFin, string idUsuarioPublicacion, int id = -1)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            FechaInicio = fechaInicio ;
            FechaFin = fechaFin;
            IdUsuario = idUsuarioPublicacion;
        }

       
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Titulo")]
        public string Titulo { get; set; }

        [JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Quien crea el evento
        /// </summary>
        [JsonProperty(PropertyName = "IdUsuario")]
        public string IdUsuario { get; set; }

        private DateTime _fechaInicio;
        [JsonProperty(PropertyName = "FechaInicio")]
        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                if (value == DateTime.MinValue)
                    value = System.DateTime.Now;

                _fechaInicio = value;
            }

        }

        private DateTime _fechaFin;
        [JsonProperty(PropertyName = "FechaFin")]
        public DateTime FechaFin
        {
            get
            {
                return _fechaFin;
            }

            set
            {
                if (value == DateTime.MinValue)
                    value = System.DateTime.Now;

                _fechaFin = value;
            }
        }

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
