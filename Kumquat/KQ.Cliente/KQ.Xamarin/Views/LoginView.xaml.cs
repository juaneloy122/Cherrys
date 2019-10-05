using KQ.Xamarin.Services;
using KQ.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KQ.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        LoginViewModel _ViewModel;

        public LoginView()
        {
            InitializeComponent();

            _ViewModel = new LoginViewModel(Navigation);
            BindingContext = _ViewModel;
           
            UsernameEntry.Completed += (sender, args) => { PasswordEntry.Focus(); };
            PasswordEntry.Completed += (sender, args) => 
            {

                _ViewModel.AuthenticateCommand.Execute(null);
               
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() =>
            {
                var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();

                statusBarStyleManager.SetDarkTheme();
            });
        }
    }
}