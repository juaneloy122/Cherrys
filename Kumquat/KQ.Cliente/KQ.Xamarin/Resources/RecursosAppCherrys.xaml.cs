using KQ.Xamarin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KQ.Xamarin.Resources
{
    public partial class RecursosAppCherrys : ResourceDictionary
    {
        public RecursosAppCherrys()
        {
            InitializeComponent();
            cambiarTema();


        }

        private void cambioTemaApp(object sender, EventArgs e)
        {
            cambiarTema();
        }

        private void cambiarTema()
        {
            //switch (App.ActualTema)
            //{
            //    case Theme.Dark:
            //        temaApp.Source = new Uri("DarkTheme.xaml");
            //        break;
            //    case Theme.Light:
            //        temaApp.Source = new Uri("LightTheme.xaml");
            //        break;
            //}
        }
    }
}