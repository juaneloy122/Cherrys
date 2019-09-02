using AppCherrys.Constantes;
using AppCherrys.Models.Tarea;
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
    public partial class NuevaTareaView : ContentPage
    {
        public Tarea Item { get; set; }

        public NuevaTareaView(Tarea item)
        {
            InitializeComponent();

            Item = item;

            asignarBotonera();

            BindingContext = this;
        }

        private void asignarBotonera()
        {
            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => Cancelar_Clicked();
            btnCancel.GestureRecognizers.Add(tgr);

            TapGestureRecognizer tgr1 = new TapGestureRecognizer();
            tgr1.Tapped += (s, e) => Guardar_Clicked();
            btnSave.GestureRecognizers.Add(tgr1);

        }

        public NuevaTareaView()
        {
            InitializeComponent();

            Item = new Tarea
            {
                Titulo = "Nombre",
                Descripcion = "Descripcion."
            };

            asignarBotonera();

            BindingContext = this;
        }

        async void Guardar_Clicked()
        {
            Item.FechaInicio = DateTime.Now;
            Item.IdUsuario = "Toño"; //Cambiar esto por el usuario logeado
            MessagingCenter.Send(this, EnumEventos.AddTarea.ToString (), Item);
            await Navigation.PopModalAsync();
        }

        async void Cancelar_Clicked()
        {
            await Navigation.PopModalAsync();
        }
    }
}