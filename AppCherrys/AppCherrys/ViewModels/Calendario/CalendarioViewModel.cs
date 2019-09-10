using AppCherrys.Constantes;
using AppCherrys.Models.Calendario;
using AppCherrys.Services;
using AppCherrys.Views.Calendario;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCherrys.ViewModels.Calendario
{
    public class CalendarioViewModel : BaseViewModel
    {

        public IDataStore<Evento> DataStore => DependencyService.Get<IDataStore<Evento>>() ?? new MockDataCalendario();

        public ObservableCollection<Evento> Eventos { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CalendarioViewModel()
        {
            Title = "Calendario";
            Eventos = new ObservableCollection<Evento>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevoEventoView, Evento>(this, EnumEventos.AddEvento.ToString (), async (obj, item) =>
            {
                var newItem = item as Evento;
                Eventos.Add(newItem);
                await DataStore.CreateItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Eventos.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Eventos.Add(item);
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

