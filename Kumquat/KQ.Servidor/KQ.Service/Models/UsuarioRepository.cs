using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using KQ.CommonLib.Models.Tablon;
using KQ.CommonLib.Models.Usuario;

namespace KQ.Service.Models
{
    public class UsuarioRepository :BaseRepository <Usuario>
    {
        

        public UsuarioRepository()
        {
            Add(new Usuario { Id = 1, DNI = "63052727K", Nombre = "Antoñito" });
            Add(new Usuario { Id = 2, DNI = "60529446R", Nombre = "Virgilio" });
            Add(new Usuario { Id = 3, DNI = "93074746W", Nombre = "Pepe" });
                      
        }

      
    }
}
