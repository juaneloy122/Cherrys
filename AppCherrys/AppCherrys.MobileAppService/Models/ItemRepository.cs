using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CommonLib.Models.Tablon;

namespace AppCherrys.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<int, Anuncio> items =
            new ConcurrentDictionary<int, Anuncio>();

        public ItemRepository()
        {
            Add(new Anuncio { Id = 1, Titulo = "Visita a Kikiricoop", Descripcion = "This is an item description." });
            Add(new Anuncio { Id = 2, Titulo = "Local de Noreña concedido", Descripcion = "This is an item description." });
            Add(new Anuncio { Id = 3, Titulo = "Fran ya tiene una FPGA para pruebas", Descripcion = "This is an item description." });
                      
        }

        public IEnumerable<Anuncio> GetAll()
        {
            return items.Values;
        }

        public void Add(Anuncio item)
        {
            //esto hay que cambiarlo para que sume siempre uno
            item.Id = 4;
            items[item.Id] = item;
        }

        public Anuncio Get(int id)
        {
            Anuncio item;
            items.TryGetValue(id, out item);

            return item;
        }

        public Anuncio Remove(int id)
        {
            Anuncio item;
            items.TryRemove(id, out item);

            return item;
        }

        public void Update(Anuncio item)
        {
            items[item.Id] = item;
        }
    }
}
