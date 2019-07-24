using AppCherrys.Constantes;
using AppCherrys.Models.Acta;
using AppCherrys.Services;
using AppCherrys.Views.Actas;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCherrys.ViewModels.Actas
{
    public class ActasViewModel : BaseViewModel
    {

        public IDataStore<Acta> DataStore => DependencyService.Get<IDataStore<Acta>>() ?? new MockDataActas();

        public ObservableCollection<Acta> Actas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ActasViewModel()
        {
            Title = "Actas";
            Actas = new ObservableCollection<Acta>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevaActaView, Acta>(this, EnumEventos.AddActa.ToString (), async (obj, item) =>
            {
                var newItem = item as Acta;
                Actas.Add(newItem);
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
                Actas.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Actas.Add(item);
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

