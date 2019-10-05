using KQ.Xamarin.ClientService;
using KQ.Xamarin.Constantes;
using KQ.Xamarin.MockDataStore;
using KQ.Xamarin.Views.Tareas;
using KQ.CommonLib.Models.Tarea;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KQ.Xamarin.ViewModels.Tareas
{
    public class TareasViewModel : BaseViewModel
    {

        private IDataStore<Tarea> _Cliente = null;
        public IDataStore<Tarea> Cliente
        {
            get
            {
                if (App.UseMockDataStore)
                    return new MockDataTareas();
                else
                {
                    if (_Cliente == null)
                        _Cliente =  KQClient.GetInstance().ServiceTarea;

                    return _Cliente;
                }
            }
        }

        public ObservableCollection<Tarea> Tareas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TareasViewModel()
        {
            Title = "Tareas";
            Tareas = new ObservableCollection<Tarea>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevaTareaView, Tarea>(this, EnumEventos.AddTarea.ToString(), async (obj, item) =>
           {
               var newItem = item as Tarea;
               Tareas.Add(newItem);
               await Cliente.CreateItemAsync(newItem);
           });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Tareas.Clear();
                var items = await Cliente.GetItemsAsync();
                foreach (var item in items)
                {
                    Tareas.Add(item);
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

