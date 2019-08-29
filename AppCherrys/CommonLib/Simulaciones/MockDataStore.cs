using CommonLib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLib.Simulaciones
{
    public class MockDataStore <T>: IDataStore<T> where T: IItem
    {
        protected  List<T> Items;

        public MockDataStore()
        {
           
        }

        public async Task<bool> AddItemAsync(T anuncio)
        {
            Items.Add(anuncio);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T anuncio)
        {
            var oldItem = Items.Where((T arg) => arg.Id == anuncio.Id).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(anuncio);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((T arg) => arg.Id == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}