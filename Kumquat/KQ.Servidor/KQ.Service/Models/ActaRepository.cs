using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using KQ.CommonLib.Models.Tablon;
using KQ.CommonLib.Models.Acta;

namespace KQ.Service.Models
{
    public class ActaRepository :BaseRepository <Acta>
    {
        public ActaRepository()
        {
            Add(new Acta { Id = 1, Titulo = "srv. Acta reunión cliente lunes 2", Descripcion = "This is an item description." });
            Add(new Acta { Id = 2, Titulo = "srv. Acta reunión equipo miércoles 5", Descripcion = "This is an item description." });
            Add(new Acta { Id = 3, Titulo = "srv. Acta reunión cliente lunes 9", Descripcion = "This is an item description." });
                      
        }
    }
}
