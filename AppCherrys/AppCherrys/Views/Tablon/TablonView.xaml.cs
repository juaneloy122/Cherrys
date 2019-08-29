using AppCherrys.ViewModels.Tablon;
using CommonLib.Models.Tablon;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Tablon
{

    [DesignTimeVisible(false)]
    public partial class TablonView : ContentPage
    {
        readonly TablonViewModel viewModel;

        public TablonView()
        {
            InitializeComponent();

            BindingContext = viewModel = new TablonViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Anuncio;
            if (item == null)
                return;

            await Navigation.PushAsync(new AnuncioDetalleView(new AnuncioDetalleViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevoAnuncioView()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Anuncios.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}