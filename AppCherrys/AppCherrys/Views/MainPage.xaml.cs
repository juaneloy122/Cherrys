using AppCherrys.Views.Tareas;
using System;
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

            TapGestureRecognizer tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => OnSettingsTap();
            masterPage.settings.GestureRecognizers.Add(tgr);


            //Este código es el que hace que en Universal Windows se oculte el menú izquierdo
            //pero cuando selecciono una vista, deja de aparecer el menú, por eso lo deshabilité,
            //porque con tal de que lo haga bien en IOS y Android suficiente.
            //if (Device.RuntimePlatform == Device.UWP)
            //{
            //    MasterBehavior = MasterBehavior.Popover;
            //}
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                var root = Detail.Navigation.NavigationStack[0];
                Detail.Navigation.InsertPageBefore((Page)Activator.CreateInstance(item.TargetType), root);
                await Detail.Navigation.PopToRootAsync();

                IsPresented = false;

                //Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                //masterPage.listView.SelectedItem = null;
                //IsPresented = false;
            }
        }

        private async void OnSettingsTap()
        {
            var root = Detail.Navigation.NavigationStack[0];
            Detail.Navigation.InsertPageBefore(new TareasView(), root);
            await Detail.Navigation.PopToRootAsync();

            IsPresented = false;
        }


    }
}