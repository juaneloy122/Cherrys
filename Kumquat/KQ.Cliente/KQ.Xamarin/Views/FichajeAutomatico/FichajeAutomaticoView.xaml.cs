using KQ.Xamarin.ViewModels.FichajeAutomatico;
using KQ.Xamarin.Views.Tablon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KQ.Xamarin.Views.FichajeAutomatico
{
    [DesignTimeVisible(false)]
    public partial class FichajeAutomaticoView : ContentPage
    {
        FichajeAutomaticoViewModel viewModel;

        public FichajeAutomaticoView()
        {
            InitializeComponent();

            BindingContext = viewModel = new FichajeAutomaticoViewModel();
        }

        async void btnInvalidar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModificacionFichajeAutomaticoView());
        }

        async void BtnValidar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Gracias", "Ha validado el fichaje automático", "Vale");
            Navigation.InsertPageBefore(new TablonView(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }
    }
}