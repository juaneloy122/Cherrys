using AppCherrys.ViewModels.Tareas;
using CommonLib.Models.Tarea;
using System.ComponentModel;

using Xamarin.Forms;

namespace AppCherrys.Views.Tareas
{
    [DesignTimeVisible(false)]
    public partial class DetalleTareaView : ContentPage
    {
        TareaDetalleViewModel viewModel;

        public DetalleTareaView(TareaDetalleViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DetalleTareaView()
        {
            InitializeComponent();

            var item = new Tarea
            {
                Titulo = "Anuncio 1",
                Descripcion = "This is an item description."
            };

            viewModel = new TareaDetalleViewModel(item);
            BindingContext = viewModel;
        }
    }
}