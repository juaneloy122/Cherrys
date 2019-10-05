using KQ.Xamarin.ViewModels.Tareas;
using KQ.CommonLib.Models.Tarea;
using System.ComponentModel;

using Xamarin.Forms;

namespace KQ.Xamarin.Views.Tareas
{
    [DesignTimeVisible(false)]
    public partial class DetalleTareaView : ContentPage
    {
        TareaDetalleViewModel viewModel;

        public DetalleTareaView(TareaDetalleViewModel viewModel)
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => EditItem_Clicked();
            btnEdit.GestureRecognizers.Add(tgr);

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

        private async void EditItem_Clicked()
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevaTareaView(viewModel.Item)));
        }
    }
}