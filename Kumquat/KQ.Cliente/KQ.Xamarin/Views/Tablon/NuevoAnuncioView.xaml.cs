using KQ.Xamarin.Constantes;
using KQ.CommonLib.Models.Tablon;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace KQ.Xamarin.Views.Tablon
{
    [DesignTimeVisible(false)]
    public partial class NuevoAnuncioView : ContentPage
    {
        public Anuncio Item { get; set; }

        public NuevoAnuncioView()
        {
            InitializeComponent();
            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => Cancelar_Clicked();
            btnCancel.GestureRecognizers.Add(tgr);

            TapGestureRecognizer tgr1 = new TapGestureRecognizer();
            tgr1.Tapped += (s, e) => Guardar_Clicked();
            btnSave.GestureRecognizers.Add(tgr1);

            Item = new Anuncio
            {
                //Titulo = "Nombre",
                //Descripcion = "Descripcion."
            };

            BindingContext = this;
        }

        async void Guardar_Clicked()
        {
            Item.FechaPublicacion = DateTime.Now;
            Item.IdUsuario = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, EnumEventos.AddAnuncio.ToString(), Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked()
        {
            await Navigation.PopModalAsync();
        }
    }
}