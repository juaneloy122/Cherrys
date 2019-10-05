using KQ.CommonLib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KQ.Xamarin.MockDataStore
{
    public class MockDataStore<T> : IDataStore<T> where T : IItem
    {
        protected List<T> Items;

        public MockDataStore()
        {

        }


        public IList<T> GetItems()
        {
            return Items;
        }

        public Task<IList<T>> GetItemsAsync()
        {
            return Task.Factory.StartNew(s => GetItems(), CancellationToken.None);
        }

        public void EditItem(T item)
        {
            var oldItem = Items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);
        }

        public Task EditItemAsync(T item)
        {
            return Task.Factory.StartNew(s => EditItem(item), CancellationToken.None);
        }

        public T CreateItem(T item)
        {
            int newId = Items.Select((T arg) => arg.Id).Max() + 1;
            item.Id = newId;
            Items.Add(item);

            return item;
        }

        public Task<T> CreateItemAsync(T item)
        {
            return Task.Factory.StartNew(s => CreateItem(item), CancellationToken.None);
        }

        public T GetItem(int id)
        {
            return Items.FirstOrDefault(s => s.Id == id);
        }

        public Task<T> GetItemAsync(int id)
        {
            return Task.Factory.StartNew(s => GetItem(id), CancellationToken.None);
        }

        public void DeleteItem(int id)
        {
            T deletedItem = Items.FirstOrDefault(s => s.Id == id);
            Items.Remove(deletedItem);
        }

        public Task DeleteItemAsync(int id)
        {
            return Task.Factory.StartNew(s => DeleteItem(id), CancellationToken.None);
        }
    }
}