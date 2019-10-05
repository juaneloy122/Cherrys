using KQ.Xamarin.Controls.Fuentes;
using KQ.Xamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KQ.Xamarin.ViewModels.ControlDeAcceso
{
    public class ControlDeAccesoViewModel : BaseViewModel
    {
        public string Title { get; set; } = "Fichajes";


        public ICommand FichajesCommand { get; set; }

        public string TextoBotonFichajes
        {
            get => _TextoBotonFichajes;
            set
            {
                _TextoBotonFichajes = value;
                App.TextoBoton = TextoBotonFichajes;
                OnPropertyChanged("TextoBotonFichajes");
            }
        }

        public DateTime FechaRegistro
        {
            get => _FechaRegistro;
            set
            {
                _FechaRegistro = value;
                App.Fecha = _FechaRegistro;
                OnPropertyChanged("FechaRegistro");
            }
        }

        public string Usuario
        {
            get => _Usuario;
            set
            {
                _Usuario = value;
                App.Usuario = _Usuario;
                OnPropertyChanged("Usuario");
            }
        }

        public bool FechaVisible
        {
            get => _FechaVisible;
            set
            {
                _FechaVisible = value;
                OnPropertyChanged("FechaVisible");
            }
        }

        public Color ColorIcono
        {
            get => _ColorIcono;
            set
            {
                _ColorIcono = value;
                OnPropertyChanged("ColorIcono");
            }
        }

        public string Icono
        {
            get => _Icono;
            set
            {
                _Icono = value;
                OnPropertyChanged("Icono");
            }
        }

        public bool Enabled
        {
            get => _Enabled;
            set
            {
                _Enabled = value;
                OnPropertyChanged("Enabled");
            }
        }

        private string _Usuario = string.Empty;
        private DateTime _FechaRegistro = DateTime.MinValue;
        private string _TextoBotonFichajes = "Acceder";
        private bool _FechaVisible = false;
        private string _Icono = string.Empty;
        private Color _ColorIcono;
        private bool _Enabled = false;

        public ControlDeAccesoViewModel()
        {
            _Enabled = true;
            Usuario = App.Usuario;
            FechaRegistro = App.Fecha;
            TextoBotonFichajes = App.TextoBoton;

            if (FechaRegistro != DateTime.MinValue)
                _FechaVisible = true;

            FichajesCommand = new Command(() =>
            {
                if (string.IsNullOrEmpty(Usuario.Trim()))
                    Usuario = "Marina Gutierrez Sacramento";

                FechaRegistro = DateTime.Now;
                FechaVisible = true;

                if (!App.EntradaSalida)
                {
                    entrada();
                }
                else
                {
                    salida();
                }
                Icono = Icon.PulgarArriba;
                ColorIcono = Color.Green;
                Enabled = false;
            });
        }

        private void salida()
        {
            App.EntradaSalida = false;
            TextoBotonFichajes = "Salida Validada";
        }

        private void entrada()
        {
            App.EntradaSalida = true;
            TextoBotonFichajes = "Entrada Validada";
        }
    }
}
