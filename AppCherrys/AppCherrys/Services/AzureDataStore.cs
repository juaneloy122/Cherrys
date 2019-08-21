using CommonLib.Models.Tablon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppCherrys.Services
{
    public class AzureDataStore : IDataStore<Anuncio>
    {
        readonly HttpClient Cliente;
        IEnumerable<Anuncio> Items;

        public AzureDataStore()
        {
            Cliente = new HttpClient
            {
                BaseAddress = new Uri($"{App.AzureBackendUrl}/")
            };

            Items = new List<Anuncio>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Anuncio>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await Cliente.GetStringAsync($"api/item");
                Items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Anuncio>>(json));
            }

            return Items;
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
    }
}
