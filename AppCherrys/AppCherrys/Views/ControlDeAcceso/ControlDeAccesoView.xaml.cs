using AppCherrys.ViewModels.ControlDeAcceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views.ControlDeAcceso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlDeAccesoView : ContentPage
    {
        ControlDeAccesoViewModel _ViewModel = null;

        public ControlDeAccesoView()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new ControlDeAccesoViewModel();
        }
    }
}