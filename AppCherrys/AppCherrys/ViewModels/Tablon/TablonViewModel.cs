using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AppCherrys.Models;
using AppCherrys.Views;
using AppCherrys.Models.Tablon;

namespace AppCherrys.ViewModels.Tablon
{
    public class TablonViewModel : BaseViewModel
    {
        public ObservableCollection<Anuncio> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TablonViewModel()
        {
            Title = "Tablón";
            Items = new ObservableCollection<Anuncio>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Anuncio>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Anuncio;
                Items.Add(newItem);
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
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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