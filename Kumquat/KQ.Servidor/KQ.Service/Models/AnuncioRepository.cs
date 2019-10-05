using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using KQ.CommonLib.Models.Tablon;

namespace KQ.Service.Models
{
    public class AnuncioRepository :BaseRepository <Anuncio>
    {
        public AnuncioRepository()
        {
            Add(new Anuncio { Id = 1, Titulo = "srv. Visita a Kikiricoop", Descripcion = "This is an item description." });
            Add(new Anuncio { Id = 2, Titulo = "srv. Local de Noreña concedido", Descripcion = "This is an item description." });
            Add(new Anuncio { Id = 3, Titulo = "srv. Fran ya tiene una FPGA para pruebas", Descripcion = "This is an item description." });
                      
        }
    }
}
