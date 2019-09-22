using AppCherrys.ViewModels.FichajeAutomatico;
using AppCherrys.Views.Tablon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views.FichajeAutomatico
{
    [DesignTimeVisible(false)]
    public partial class ModificacionFichajeAutomaticoView : ContentPage
    {
        ModificacionFichajeAutomaticoViewModel viewModel;

        public ModificacionFichajeAutomaticoView()
        {
            InitializeComponent();

            BindingContext = viewModel = new ModificacionFichajeAutomaticoViewModel();
        }

        async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new FichajeAutomaticoView());
            await Navigation.PopAsync();
        }

        async void BtnAceptar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Gracias", "Ha modificado el fichaje automático", "Vale");
            Navigation.InsertPageBefore(new TablonView(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }
    }
}