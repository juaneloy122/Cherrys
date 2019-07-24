using AppCherrys.Models.Tarea;
using AppCherrys.ViewModels.Tareas;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Tareas
{
    [DesignTimeVisible(false)]
    public partial class TareasView : ContentPage
    {
        TareasViewModel viewModel;

        public TareasView()
        {
            InitializeComponent();

            BindingContext = viewModel = new TareasViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Tarea;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetalleTareaView(new TareaDetalleViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevaTareaView()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Tareas .Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}