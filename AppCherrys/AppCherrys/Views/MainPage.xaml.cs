﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCherrys.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.listView.ItemSelected += OnItemSelected;

            //Este código es el que hace que en Universal Windows se oculte el menú izquierdo
            //pero cuando selecciono una vista, deja de aparecer el menú, por eso lo deshabilité,
            //porque con tal de que lo haga bien en IOS y Android suficiente.
            //if (Device.RuntimePlatform == Device.UWP)
            //{
            //    MasterBehavior = MasterBehavior.Popover;
            //}
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}