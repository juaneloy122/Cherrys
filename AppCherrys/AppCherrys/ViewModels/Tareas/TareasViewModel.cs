using AppCherrys.Constantes;
using AppCherrys.Models.Tarea;
using AppCherrys.Services;
using AppCherrys.Views.Tareas;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCherrys.ViewModels.Tareas
{
    public class TareasViewModel : BaseViewModel
    {

        public IDataStore<Tarea> DataStore => DependencyService.Get<IDataStore<Tarea>>() ?? new MockDataTareas();

        public ObservableCollection<Tarea> Tareas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TareasViewModel()
        {
            Title = "Tareas";
            Tareas = new ObservableCollection<Tarea>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevaTareaView, Tarea>(this, EnumEventos.AddTarea.ToString (), async (obj, item) =>
            {
                var newItem = item as Tarea;
                Tareas.Add(newItem);
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
                Tareas.Clear();
                var items = await DataStore.GetItemsAsync();
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

