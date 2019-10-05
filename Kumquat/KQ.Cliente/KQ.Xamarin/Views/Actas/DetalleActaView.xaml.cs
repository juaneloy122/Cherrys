using KQ.Xamarin.ViewModels.Actas;
using KQ.CommonLib.Models.Acta;
using System.ComponentModel;

using Xamarin.Forms;

namespace KQ.Xamarin.Views.Actas
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