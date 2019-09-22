using AppCherrys.ViewModels.Calendario;
using CommonLib.Models.Calendario;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Calendario
{
    [DesignTimeVisible(false)]
    public partial class CalendarioView : ContentPage
    {
        CalendarioViewModel viewModel;

        public CalendarioView()
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => AddItem_Clicked();
            btnAdd.GestureRecognizers.Add(tgr);

            BindingContext = viewModel = new CalendarioViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Evento;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetalleEventoView(new EventoDetalleViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked()
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevoEventoView()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Eventos.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
