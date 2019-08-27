using AppCherrys.Constantes;
using AppCherrys.Models.Calendario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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