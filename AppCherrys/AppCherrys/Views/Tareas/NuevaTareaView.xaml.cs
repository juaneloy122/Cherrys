using AppCherrys.Constantes;
using CommonLib.Models.Tarea;
using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace AppCherrys.Views.Tareas
{
    [DesignTimeVisible(false)]
    public partial class NuevaTareaView : ContentPage
    {
        public Tarea Item { get; set; }

        public NuevaTareaView()
        {
            InitializeComponent();

            Item = new Tarea
            {
                Titulo = "Nombre",
                Descripcion = "Descripcion."
            };

            BindingContext = this;
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            Item.FechaInicio = DateTime.Now;
            Item.IdUsuario = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, EnumEventos.AddTarea.ToString(), Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}