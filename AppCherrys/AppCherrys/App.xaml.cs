﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCherrys.Services;
using AppCherrys.Views;
using System.Threading.Tasks;
using System.Diagnostics;
using AppCherrys.Constantes.Localization;

namespace AppCherrys
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataAnuncios>();
            else
                DependencyService.Register<AzureDataStore>();
            MainPage = new NavigationPage(new LoginView());// new LoginView();// new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Localization.Current.OnCultureChanged += (culture) =>
            {
                Messages.Culture = culture;
            };

            Localization.Current.EnsureDeviceOrDefaultCulture(defaultCultureName: "es", availableCultures: new[] { "es", "en", "as" });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
