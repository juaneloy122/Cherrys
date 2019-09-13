using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CommonLib.Models.Tablon;
using CommonLib.Models.Tarea;

namespace AppCherrys.Models
{
    public class TareaRepository :BaseRepository <Tarea>
    {
        

        public TareaRepository()
        {
            Add(new Tarea { Id = 1, Titulo = "srv. Sacar los escombros", Descripcion = "Hay que sacar con el carretillo los escombros para que los pueda cargar la pala al camión." });
            Add(new Tarea { Id = 2, Titulo = "srv. Tabique del primer piso", Descripcion = "Tabicar lo que queda que es más o menos 10 metros cuadrados." });
            Add(new Tarea { Id = 3, Titulo = "srv. Echar cemento al suelo del garaje", Descripcion = "Echar y pulir bien el cemento del suelo del garaje para dejarlo ya listo." });
                      
        }

      
    }
}
