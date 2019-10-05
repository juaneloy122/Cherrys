using KQ.Xamarin.Constantes;
using KQ.CommonLib.Models.Acta;
using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace KQ.Xamarin.Views.Actas
{
    [DesignTimeVisible(false)]
    public partial class NuevaActaView : ContentPage
    {
        public Acta Item { get; set; }

        public NuevaActaView()
        {
            InitializeComponent();

            Item = new Acta
            {
                Titulo = "Nombre",
                Descripcion = "Descripcion."
            };

            BindingContext = this;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            Item.Fecha = DateTime.Now;
            Item.IdUsuario = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, EnumEventos.AddActa.ToString(), Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}