﻿using KQ.Xamarin.ViewModels.Tareas;
using KQ.CommonLib.Models.Tarea;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace KQ.Xamarin.Views.Tareas
{
    [DesignTimeVisible(false)]
    public partial class TareasView : ContentPage
    {
        TareasViewModel viewModel;

        public TareasView()
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => AddItem_Clicked();
            btnAdd.GestureRecognizers.Add(tgr);

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

        async void AddItem_Clicked()
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevaTareaView()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Tareas.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}