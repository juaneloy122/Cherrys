using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCherrys.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IList<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
