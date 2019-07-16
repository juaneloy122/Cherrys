using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.Models.Usuario
{
    /// <summary>
    /// Contiene los datos nuestros, los que necesita la aplicación logicamente.
    /// </summary>
    public class Usuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }

        public string PWD { get; set; }
    }
}
