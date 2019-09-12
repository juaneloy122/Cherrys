using System;

namespace CommonLib.Models.Usuario
{
    /// <summary>
    /// Contiene los datos nuestros, los que necesita la aplicación logicamente.
    /// </summary>
    public class Usuario
    {

        public Usuario() { }

        /// <summary>
        /// Initializes a new instance of the Anuncio class.
        /// </summary>
        public Usuario(string id, string email,string alias, string pwd)
        {
            Id = id;
            Email = email;
            Alias = alias;
            PWD = pwd;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }

        public string PWD { get; set; }
    }
}
