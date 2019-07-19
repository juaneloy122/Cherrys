using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AppCherrys.Models;
using AppCherrys.Views;
using AppCherrys.Models.Tablon;
using AppCherrys.Views.Tablon;

namespace AppCherrys.ViewModels.Tablon
{
    public class TablonViewModel : BaseViewModel
    {
        public ObservableCollection<Anuncio> Anuncios { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TablonViewModel()
        {
            Title = "Tablón";
            Anuncios = new ObservableCollection<Anuncio>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevoAnuncioView, Anuncio>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Anuncio;
                Anuncios.Add(newItem);
                await DataStore.AddItemAsync(newItem);
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