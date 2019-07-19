using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCherrys.Models;
using AppCherrys.Views;
using AppCherrys.ViewModels;
using AppCherrys.ViewModels.Tablon;
using AppCherrys.Models.Tablon;

namespace AppCherrys.Views.Tablon
{
    
    [DesignTimeVisible(false)]
    public partial class TablonView : ContentPage
    {
        TablonViewModel viewModel;

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
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}