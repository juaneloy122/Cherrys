using AppCherrys.Models.Calendario;
using AppCherrys.ViewModels.Calendario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views.Calendario
{
    [DesignTimeVisible(false)]
    public partial class DetalleEventoView : ContentPage
    {
        EventoDetalleViewModel viewModel;

        public DetalleEventoView(EventoDetalleViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DetalleEventoView()
        {
            InitializeComponent();

            var item = new Evento
            {
                Titulo = "Anuncio 1",
                Descripcion = "This is an item description."
            };

            viewModel = new EventoDetalleViewModel(item);
            BindingContext = viewModel;
        }
    }
}