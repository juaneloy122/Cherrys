using AppCherrys.ViewModels.Calendario;
using CommonLib.Models.Calendario;
using System.ComponentModel;

using Xamarin.Forms;

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