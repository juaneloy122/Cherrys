﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CommonLib.Models.Tablon;
using CommonLib.Interfaces;

namespace AppCherrys.Models
{
    public class BaseRepository<T> : IItemRepository<T> where T : IItem
    {
        private static ConcurrentDictionary<int, T> Items =
            new ConcurrentDictionary<int, T>();

        public BaseRepository()
        {
           
                      
        }

        public IEnumerable<T> GetAll()
        {
            return Items.Values;
        }

        public void Add(T item)
        {
            //esto hay que cambiarlo para que sume siempre uno

            Items.TryAdd(item.Id, item);
        }

        public T Get(int id)
        {
            T item;
            Items.TryGetValue(id, out item);

            return item;
        }

        public T Remove(int id)
        {
            T item;
            Items.TryRemove(id, out item);

            return item;
        }

        public void Update(T item)
        {
            Items[item.Id] = item;
        }
    }
}