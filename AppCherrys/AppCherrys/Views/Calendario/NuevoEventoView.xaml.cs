using AppCherrys.Constantes;
using CommonLib.Models.Calendario;
using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace AppCherrys.Views.Calendario
{
    [DesignTimeVisible(false)]
    public partial class NuevoEventoView : ContentPage
    {
        public Evento Item { get; set; }

        public NuevoEventoView()
        {
            InitializeComponent();

            Item = new Evento
            {
                Titulo = "Nombre",
                Descripcion = "Descripcion.",
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now
            };

            BindingContext = this;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            //Item.FechaInicio = DateTime.Now;
            Item.IdUsuario = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, EnumEventos.AddEvento.ToString(), Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}