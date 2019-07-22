using System;

namespace CommonLib.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }

        string Titulo { get; set; }

        string Descripcion { get; set; }

        /// <summary>
        /// Quien crea el item
        /// </summary>
        string IdUsuario { get; set; }
    }
}

