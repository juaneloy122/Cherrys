using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Acta
{
    /// <summary>
    /// Acta publicada
    /// </summary>
    public class Acta
    {
        public string Id { get; set; }       
        public string Description { get; set; }
        public DateTime Fecha { get; set; }

        public string RutaDocumento { get; set; }

        public List <string> RutaAdjuntos { get; set; }
    }
}
