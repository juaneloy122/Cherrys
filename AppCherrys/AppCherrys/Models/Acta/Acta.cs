using CommonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Acta
{
    /// <summary>
    /// Acta publicada
    /// </summary>
    public class Acta:IItem
    {
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
