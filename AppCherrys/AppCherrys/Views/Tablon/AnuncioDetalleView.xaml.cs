﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCherrys.Models;
using AppCherrys.ViewModels;
using AppCherrys.ViewModels.Tablon;
using AppCherrys.Models.Tablon;

namespace AppCherrys.Views.Tablon
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AnuncioDetalleView : ContentPage
    {
        AnuncioDetalleViewModel viewModel;

        public AnuncioDetalleView(AnuncioDetalleViewModel viewModel)
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => EditItem_Clicked();
            btnEdit.GestureRecognizers.Add(tgr);

            BindingContext = this.viewModel = viewModel;
        }

        public AnuncioDetalleView()
        {
            InitializeComponent();

            var item = new Anuncio
            {
                Titulo = "Anuncio 1",
                Descripcion = "This is an item description."
            };

            viewModel = new AnuncioDetalleViewModel(item);
            BindingContext = viewModel;
        }

        private async void EditItem_Clicked()
        {
            await Navigation.PushModalAsync(new NavigationPage(new EditAnuncioView(viewModel.Item)));
        }
    }
}