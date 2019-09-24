using AppCherrys.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppCherrys.Constantes.Localization;
using System;
using ST_Utilidades.Log;
using AppCherrys.Enums;

namespace AppCherrys
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:37601";
        public static bool UseMockDataStore = true;

        //Puesto para fichajes maqueta

        public static bool EntradaSalida = false;

        public static string Usuario = string.Empty;

        public static DateTime Fecha = DateTime.MinValue;

        public static string TextoBoton = "Acceder";


        public App()
        {
            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ2MDgyQDMxMzcyZTMzMmUzMGlERUxKYkdqcWxpK0lSb0I2YXplNmFVbTdCb0V5ejVYb28zb1lCUDJJcnc9");

            Localization.Current.OnCultureChanged += (culture) =>
            {
                Messages.Culture = culture;
            };
            Localization.Current.EnsureDeviceOrDefaultCulture(defaultCultureName: "es", availableCultures: new[] { "es", "en", "as" });

            MainPage = new NavigationPage(new LoginView());// new LoginView();// new MainPage();

            Log.AddNormal("Se inicializa la aplicación");
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

          