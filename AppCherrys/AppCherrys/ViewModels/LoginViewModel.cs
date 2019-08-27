using AppCherrys.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCherrys.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Atributos y propiedades

       
        private string _username;
        private string _password;
        private bool _areCredentialsInvalid;

        public string Username
        {
            get => _username;
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public ICommand AuthenticateCommand { get; set; }

        public bool AreCredentialsInvalid
        {
            get => _areCredentialsInvalid;
            set
            {
                if (value == _areCredentialsInvalid) return;
                _areCredentialsInvalid = value;
                OnPropertyChanged(nameof(AreCredentialsInvalid));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor
        public LoginViewModel(INavigation navigation)
        {
            AuthenticateCommand = new Command(() =>
            {
                AreCredentialsInvalid = !UserAuthenticated(Username, Password);

                if (AreCredentialsInvalid) return;

                navigation.PushAsync(new MainPage());

            });

            AreCredentialsInvalid = false;
        }

        #endregion

        #region Metodos
        private bool UserAuthenticated(string username, string password)
        {

            return true;


            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
            {
                return false;
            }



            //Aquí cuando este listo habrá que meter la llamada al servicio para que autentique al usuario
            return true;
        }

        #endregion

      
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}