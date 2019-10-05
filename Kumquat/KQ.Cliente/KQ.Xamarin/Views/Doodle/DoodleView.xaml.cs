using KQ.Xamarin.ViewModels.Doodle;
using System.ComponentModel;
using Xamarin.Forms;

namespace KQ.Xamarin.Views.Doodle
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
