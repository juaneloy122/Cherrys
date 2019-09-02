using AppCherrys.Models.Tarea;
using AppCherrys.ViewModels.Tareas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views.Tareas
{
    [DesignTimeVisible(false)]
    public partial class DetalleTareaView : ContentPage
    {
       TareaDetalleViewModel viewModel;

        public DetalleTareaView(TareaDetalleViewModel viewModel)
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => EditItem_Clicked();
            btnEdit.GestureRecognizers.Add(tgr);

            BindingContext = this.viewModel = viewModel;
        }

        public DetalleTareaView()
        {
            InitializeComponent();

            var item = new Tarea
            {
                Titulo = "Anuncio 1",
                Descripcion = "This is an item description."
            };

            viewModel = new TareaDetalleViewModel(item);
            BindingContext = viewModel;
        }

        private async void EditItem_Clicked()
        {
            await Navigation.PushModalAsync(new NavigationPage(new NuevaTareaView(viewModel.Item)));
        }
    }
}