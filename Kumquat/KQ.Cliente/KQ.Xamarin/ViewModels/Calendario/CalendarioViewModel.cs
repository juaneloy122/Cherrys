﻿using KQ.Xamarin.ClientService;
using KQ.Xamarin.Constantes;
using KQ.Xamarin.MockDataStore;
using KQ.Xamarin.Views.Calendario;
using KQ.CommonLib.Models.Calendario;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KQ.Xamarin.ViewModels.Calendario
{
    public class CalendarioViewModel : BaseViewModel
    {

        private IDataStore<Evento> _Cliente = null;
        public IDataStore<Evento> Cliente
        {
            get
            {
                if (App.UseMockDataStore)
                    return new MockDataCalendario();
                else
                {
                    if (_Cliente == null)
                        _Cliente = KQClient.GetInstance().ServiceCalendario;

                    return _Cliente;
                }
            }
        }

        public ObservableCollection<Evento> Eventos { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CalendarioViewModel()
        {
            Title = "Calendario";
            Eventos = new ObservableCollection<Evento>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NuevoEventoView, Evento>(this, EnumEventos.AddEvento.ToString(), async (obj, item) =>
           {
               var newItem = item as Evento;
               Eventos.Add(newItem);
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
                Eventos.Clear();
                var items = await Cliente.GetItemsAsync();
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
