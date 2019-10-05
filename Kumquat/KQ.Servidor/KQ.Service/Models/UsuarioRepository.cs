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
            Add(new Usuario { Id = 1, Puesto = "Tornero", Nombre = "Antoñito" });
            Add(new Usuario { Id = 2, Puesto = "Albañil", Nombre = "Virgilio" });
            Add(new Usuario { Id = 3, Puesto = "Auxiliar",Nombre = "Pepe" });
                      
        }

      
    }
}
