using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Tablon
{
    /// <summary>
    /// Anuncios publicados en el tablón de inicio
    /// </summary>
    public class Anuncio:IItem
    {
        public int Id { get; set; }
        public string Cabecera => FechaPublicacion.ToShortDateString() + " (" + IdUsuario + ") " + Titulo;

        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public string IdUsuario { get; set; }
    }
}
