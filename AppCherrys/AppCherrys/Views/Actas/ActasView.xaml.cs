using AppCherrys.Models.Acta;
using AppCherrys.ViewModels.Actas;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Actas
{
    [DesignTimeVisible(false)]
    public partial class ActasView : ContentPage
    {
        ActasViewModel viewModel;

        public ActasView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ActasViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Acta;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetalleActaView(new ActaDetalleViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevaActaView()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Actas.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
