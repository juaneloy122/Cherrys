using AppCherrys.Constantes;
using AppCherrys.Services;
using AppCherrys.Views.Tablon;
using CommonLib.Models.Tablon;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCherrys.ViewModels.Tablon
{
    public class TablonViewModel : BaseViewModel
    {
        public IDataStore<Anuncio> DataStore
        {
            get
            {
                if (App.UseMockDataStore)
                    return new MockDataAnuncios();
                else
                    return new AzureDataStoreAnuncio();
            }
        }

        public ObservableCollection<Anuncio> Anuncios { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TablonViewModel()
        {
            Title = "Tablón";
            Anuncios = new ObservableCollection<Anuncio>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevoAnuncioView, Anuncio>(this, EnumEventos.AddAnuncio.ToString(), async (obj, item) =>
           {
               var newItem = item as Anuncio;               
               await DataStore.AddItemAsync(newItem);
               await ExecuteLoadItemsCommand();
           });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Anuncios.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Anuncios.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}