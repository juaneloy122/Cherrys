using AppCherrys.ViewModels.Actas;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Actas
{
    [DesignTimeVisible(false)]
    public partial class ActasView : ContentPage
    {
        ActasViewModel viewModel;

        public ActasView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ActasViewModel();
        }
    }
}
