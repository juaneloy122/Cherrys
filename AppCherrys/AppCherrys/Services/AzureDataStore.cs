using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using AppCherrys.Models;
using AppCherrys.Models.Tablon;

namespace AppCherrys.Services
{
    public class AzureDataStore : IDataStore<Anuncio>
    {
        HttpClient client;
        IEnumerable<Anuncio> items;

        public AzureDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<Anuncio>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Anuncio>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Anuncio>>(json));
            }

            return items;
        }

        public async Task<Anuncio> GetItemAsync(int id)
        {
            if (id >= 0 && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Anuncio>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Anuncio item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Anuncio item)
        {
            if (item == null || item.Id < 0 || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            if (id<0 || !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
