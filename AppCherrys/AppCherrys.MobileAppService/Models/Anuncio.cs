using System;
using System.ComponentModel.DataAnnotations;

namespace AppCherrys.Models
{
    public class Anuncio
    {        
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        public string IdUsuarioPublicacion { get; set; }
    }
}
