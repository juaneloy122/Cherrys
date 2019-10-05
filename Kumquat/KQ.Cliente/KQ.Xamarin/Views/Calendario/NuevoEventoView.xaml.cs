using KQ.Xamarin.Constantes;
using KQ.CommonLib.Models.Calendario;
using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace KQ.Xamarin.Views.Calendario
{
    [DesignTimeVisible(false)]
    public partial class NuevoEventoView : ContentPage
    {
        public Evento Item { get; set; }

        public NuevoEventoView()
        {
            InitializeComponent();

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => Cancelar_Clicked();
            btnCancel.GestureRecognizers.Add(tgr);

            TapGestureRecognizer tgr1 = new TapGestureRecognizer();
            tgr1.Tapped += (s, e) => Guardar_Clicked();
            btnSave.GestureRecognizers.Add(tgr1);

            Item = new Evento
            {
                Titulo = "Nombre",
                Descripcion = "Descripcion.",
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now
            };

            BindingContext = this;
        }

        async void Guardar_Clicked()
        {
            //Item.FechaInicio = DateTime.Now;
            Item.IdUsuario = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, EnumEventos.AddEvento.ToString(), Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked()
        {
            await Navigation.PopModalAsync();
        }
    }
}