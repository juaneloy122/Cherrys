using CommonLib.Interfaces;
using CommonLib.Models.Tablon;
using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppCherrys.Services
{
    public class AzureDataStore<T> : IDataStore<T> where T : IItem
    {
        readonly IAppCherrysClient Cliente = new AppCherrysClient();
        protected List<T> Items;

        public AzureDataStore()
        {
            
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IList<T>> GetItemsAsync(bool forceRefresh = false)
        {
            IList<T> items = AppCherrysClientExtensions.List (Cliente);

            return items;
                        
        }

        public async Task<Anuncio> GetItemAsync(int id)
        {
            if (id >= 0 && IsConnected)
            {
                var json = await Cliente.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Anuncio>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Anuncio item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await Cliente.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Anuncio item)
        {
            if (item == null || item.Id < 0 || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await Cliente.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            if (id < 0 || !IsConnected)
                return false;

            var response = await Cliente.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
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

       
    }
}
