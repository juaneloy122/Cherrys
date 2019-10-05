using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace KQ.Xamarin.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://coralesdesign.es")));
        }

        public ICommand OpenWebCommand { get; }
    }
}