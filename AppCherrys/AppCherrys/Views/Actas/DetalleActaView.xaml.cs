using AppCherrys.Models.Acta;
using AppCherrys.ViewModels.Actas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views.Actas
{
    [DesignTimeVisible(false)]
    public partial class DetalleActaView : ContentPage
    {
        ActaDetalleViewModel viewModel;

        public DetalleActaView(ActaDetalleViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DetalleActaView()
        {
            InitializeComponent();

            var item = new Acta
            {
                Titulo = "Anuncio 1",
                Descripcion = "This is an item description."
            };

            viewModel = new ActaDetalleViewModel(item);
            BindingContext = viewModel;
        }
    }
}