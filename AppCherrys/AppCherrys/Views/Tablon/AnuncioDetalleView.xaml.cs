using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCherrys.Models;
using AppCherrys.ViewModels;
using AppCherrys.ViewModels.Tablon;

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

            BindingContext = this.viewModel = viewModel;
        }

        public AnuncioDetalleView()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new AnuncioDetalleViewModel(item);
            BindingContext = viewModel;
        }
    }
}