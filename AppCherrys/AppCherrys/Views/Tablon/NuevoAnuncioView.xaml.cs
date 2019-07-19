using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCherrys.Models;
using AppCherrys.Models.Tablon;

namespace AppCherrys.Views.Tablon
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NuevoAnuncioView : ContentPage
    {
        public Anuncio Item { get; set; }

        public NuevoAnuncioView()
        {
            InitializeComponent();

            Item = new Anuncio
            {
                Titulo = "Nombre",
                Descripcion = "Descripcion."
            };

            BindingContext = this;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            Item.FechaPublicacion = DateTime.Now;
            Item.IdUsuarioPublicacion = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}