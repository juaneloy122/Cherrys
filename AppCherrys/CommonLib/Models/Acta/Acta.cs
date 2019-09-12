using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Models.Acta
{
    /// <summary>
    /// Acta publicada
    /// </summary>
    public class Acta:IItem
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

        public string Cabecera => Fecha.ToShortDateString() + " (" + IdUsuario + ") " + Titulo;
        public int Id { get; set; }       
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public string RutaDocumento { get; set; }

        public List <string> RutaAdjuntos { get; set; }

        /// <summary>
        /// Quien sube el acta
        /// </summary>
        public string IdUsuario { get; set; }
    }
}
