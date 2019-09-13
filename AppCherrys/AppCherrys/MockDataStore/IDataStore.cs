using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCherrys.MockDataStore
{
    public interface IDataStore<T>
    {

        IList<T> GetItems();

        Task<IList<T>> GetItemsAsync();

        void EditItem(T item);

        Task EditItemAsync(T item);

        T CreateItem(T item);

        Task<T> CreateItemAsync(T item);

        T GetItem(int id);

        Task<T> GetItemAsync(int id);

        void DeleteItem(int id);

        Task DeleteItemAsync(int id);
    }
}
