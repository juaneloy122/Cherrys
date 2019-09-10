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
    public class AzureDataStoreAnuncio //: IDataStore<Anuncio>
    {
        //IClientTablon Cliente = null;

        //public AzureDataStoreAnuncio()
        //{
        //    Cliente = new AppCherrysClient().ServiceTablon;
        //}

        //#region Metodos publicos
        //public async Task<IList<Anuncio>> GetItemsAsync(bool forceRefresh = false)
        //{
        //    IList<Anuncio> items = Cliente.GetAnuncios();// AppCherrysClientExtensions.List(Cliente);

        //    return items;

        //}

        //public async Task<Anuncio> GetItemAsync(int id)
        //{

        //    Anuncio item = Cliente.GetAnuncio( id);

        //    return item;
        //}

        //public async Task<bool> AddItemAsync(Anuncio item)
        //{
        //    Cliente.CreateAnuncioAsync( item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateItemAsync(Anuncio anuncio)
        //{
        //    Cliente.EditAnuncioAsync( anuncio);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteItemAsync(int id)
        //{
        //    Cliente.DeleteAnuncioAsync( id); 

        //    return await Task.FromResult(true);
        //}
        //#endregion
    }
}
