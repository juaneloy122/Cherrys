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
        public int Id { get; set; }
        public string Cabecera => FechaPublicacion.ToShortDateString() + " (" + IdUsuarioPublicacion + ") " + Titulo;

        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public string IdUsuarioPublicacion { get; set; }
    }
}
