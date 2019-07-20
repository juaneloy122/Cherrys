using AppCherrys.ViewModels.Doodle;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Doodle
{
    [DesignTimeVisible(false)]
    public partial class DoodleView : ContentPage
    {
        DoodleViewModel viewModel;

        public DoodleView()
        {
            InitializeComponent();

            BindingContext = viewModel = new DoodleViewModel();
        }
    }
}
