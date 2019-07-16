using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Tablon
{
    /// <summary>
    /// Anuncios publicados en el tablón de inicio
    /// </summary>
    public class Anuncio
    {
        public string Id { get; set; }        
        public string Description { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public string IdUsuarioPublicacion { get; set; }
    }
}
