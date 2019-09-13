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

        async void AddItem_Clicked(object sender, EventArgs e)
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
