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

        private IntPtr _passwordEncriptada;
        public IntPtr PasswordEncriptada
        {
            get => _passwordEncriptada;
            set
            {
                if (value == _passwordEncriptada) return;
                _passwordEncriptada = value;
                OnPropertyChanged(nameof(PasswordEncriptada));
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

                navigation.PushAsync(new NavigationPage(new MainPage()));

            });

            AreCredentialsInvalid = false;
        }

        #endregion

        #region Metodos
        private bool UserAuthenticated(string username, string password)
        {
            // variable que se retorna para comprobar si se ha validado correctamente o no.
            //  en estos momentos se retorna siempre por defecto "True" y no la variable.
            bool autenticadoCorrectamente = false;


            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password))
            {
                autenticadoCorrectamente = false;
            }
            else
            {
                //A modo de prueba se realiza la encriptación de la contraseña insertada por el usuario, que se comprobará con la que
                //  exista (también encriptada en la BBDD)

                PasswordEncriptada = Encriptar(password);
                Password = Desencriptar(PasswordEncriptada);

                autenticadoCorrectamente = true;
            }

            //Aquí cuando este listo habrá que meter la llamada al servicio para que autentique al usuario
            return true;
        }

        private IntPtr Encriptar(string passSinEncriptar)
		{
			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = System.Runtime.InteropServices.Marshal.StringToHGlobalUni(passSinEncriptar);
                return unmanagedString;
			}
            catch
            {
                throw new Exception("Error al encriptar");
            }
		}

        private string Desencriptar(IntPtr passEncriptada)
        {
           string unmanagedString = string.Empty;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.PtrToStringUni(passEncriptada);
                return unmanagedString;
            }
            catch
            {
                throw new Exception("Error al desencriptar");
            }
        }

        #endregion


        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}