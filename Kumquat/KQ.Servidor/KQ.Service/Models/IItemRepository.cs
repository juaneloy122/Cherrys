using KQ.CommonLib.Models.Tablon;
using System;
using System.Collections.Generic;

namespace KQ.Service.Models
{
    public interface IItemRepository <T>
    {
        void Add(T item);
        void Update(T item);
        T Remove(int key);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
