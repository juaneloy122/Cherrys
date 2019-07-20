using AppCherrys.ViewModels.Calendario;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCherrys.Views.Calendario
{
    [DesignTimeVisible(false)]
    public partial class CalendarioView : ContentPage
    {
        CalendarioViewModel viewModel;

        public CalendarioView()
        {
            InitializeComponent();

            BindingContext = viewModel = new CalendarioViewModel();
        }
    }
}
