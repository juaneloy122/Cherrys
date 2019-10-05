using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using KQ.CommonLib.Models.Tablon;
using KQ.CommonLib.Models.Calendario;

namespace KQ.Service.Models
{
    public class CalendarioRepository :BaseRepository <Evento>
    {
        

        public CalendarioRepository()
        {
            Add(new Evento { Id = 1, Titulo = "srv. Reunión en la oficina.", Descripcion = "Se tratará el diseño de la nueva carretera." });
            Add(new Evento { Id = 2, Titulo = "srv. visita presidente EDP", Descripcion = "Trataremos la negociación de la nueva tarifa eléctrica." });
            Add(new Evento { Id = 3, Titulo = "srv. Cena de empresa", Descripcion = "En el local Entreviñes, habrá música en directo y barra libre." });
                      
        }

        
    }
}
