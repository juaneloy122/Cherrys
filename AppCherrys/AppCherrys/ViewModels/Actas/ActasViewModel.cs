using AppCherrys.ClientService;
using AppCherrys.Constantes;
using AppCherrys.MockDataStore;
using AppCherrys.Views.Actas;
using CommonLib.Models.Acta;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCherrys.ViewModels.Actas
{
    public class ActasViewModel : BaseViewModel
    {

        private IDataStore<Acta> _Cliente = null;
        public IDataStore<Acta> Cliente
        {
            get
            {
                if (App.UseMockDataStore)
                    return new MockDataActas();
                else
                {
                    if (_Cliente == null)
                        _Cliente = AppCherrysClient.GetInstance().ServiceActa;

                    return _Cliente;
                }
            }
        }

        public ObservableCollection<Acta> Actas { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ActasViewModel()
        {
            Title = "Actas";
            Actas = new ObservableCollection<Acta>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevaActaView, Acta>(this, EnumEventos.AddActa.ToString(), async (obj, item) =>
           {
               var newItem = item as Acta;
               Actas.Add(newItem);
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
                Actas.Clear();
                var items = await Cliente.GetItemsAsync();
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

