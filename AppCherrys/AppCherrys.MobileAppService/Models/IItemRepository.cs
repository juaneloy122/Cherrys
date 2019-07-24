using System;
using System.Collections.Generic;

namespace AppCherrys.Models
{
    public interface IItemRepository
    {
        void Add(Anuncio item);
        void Update(Anuncio item);
        Anuncio Remove(int key);
        Anuncio Get(int id);
        IEnumerable<Anuncio> GetAll();
    }
}
