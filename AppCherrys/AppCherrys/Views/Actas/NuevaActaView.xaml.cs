﻿using AppCherrys.Constantes;
using AppCherrys.Models.Acta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views.Actas
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