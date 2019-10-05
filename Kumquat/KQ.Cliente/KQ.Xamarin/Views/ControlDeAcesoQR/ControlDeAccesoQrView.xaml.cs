using KQ.Xamarin.ViewModels.ControlDeAcceoViewQR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KQ.Xamarin.Views.ControlDeAcesoQR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlDeAccesoQr : ContentPage
    {
        ControlDeAccesoQRViewModel _ViewModel = null;

        public ControlDeAccesoQr()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new ControlDeAccesoQRViewModel();
        }
    }
}