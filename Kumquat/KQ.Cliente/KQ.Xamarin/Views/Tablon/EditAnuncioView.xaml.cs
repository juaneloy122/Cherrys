using KQ.Xamarin.ViewModels.Tablon;
using KQ.CommonLib.Models.Tablon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KQ.Xamarin.Views.Tablon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAnuncioView : ContentPage
    {

        public EditAnuncioView(Anuncio item)
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => cancel();
            btnCancel.GestureRecognizers.Add(tgr);

            TapGestureRecognizer tgr1 = new TapGestureRecognizer();
            tgr1.Tapped += (s, e) => save();
            btnSave.GestureRecognizers.Add(tgr1);


            BindingContext = new EditAnuncioViewModel(item);
        }

        private async void cancel()
        {
            await Navigation.PopModalAsync();
        }

        private async void save()
        {
            await Navigation.PopModalAsync();
        }
    }
}