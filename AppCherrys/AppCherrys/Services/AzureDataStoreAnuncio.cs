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
    public class AzureDataStoreAnuncio : AzureDataStore, IDataStore<Anuncio>
    {
        
        public AzureDataStoreAnuncio()
        {
           
        }

        #region Metodos publicos
        public async Task<IList<Anuncio>> GetItemsAsync(bool forceRefresh = false)
        {
            IList<Anuncio> items = AppCherrysClientExtensions.List(Cliente);

            return items;

        }

        public async Task<Anuncio> GetItemAsync(int id)
        {

            Anuncio item = AppCherrysClientExtensions.GetItem(Cliente, id);

            return item;
        }

        public async Task<bool> AddItemAsync(Anuncio item)
        {
            AppCherrysClientExtensions.CreateAsync(Cliente, item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Anuncio anuncio)
        {
            AppCherrysClientExtensions.EditAsync(Cliente, anuncio);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            AppCherrysClientExtensions.DeleteAsync(Cliente, id); 

            return await Task.FromResult(true);
        }
        #endregion
    }
}
