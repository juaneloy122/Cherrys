using AppCherrys.ViewModels.Tareas;
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
    }
}