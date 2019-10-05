using KQ.Xamarin.Controls.Fuentes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KQ.Xamarin.ViewModels.ControlDeAcceoViewQR
{
    public class ControlDeAccesoQRViewModel: BaseViewModel
    {
        public string Title { get; set; } = "Fichajes QR";

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

        private string _Usuario = string.Empty;
        private DateTime _FechaRegistro = DateTime.MinValue;
        private bool _FechaVisible = false;
        private string _Icono = string.Empty;
        private Color _ColorIcono;

        public ControlDeAccesoQRViewModel()
        {
            FechaRegistro = DateTime.Now;
            Usuario = "Marina Gutierrez Sacramento";
            FechaVisible = true;
            ColorIcono = Color.Green;
            Icono = Icon.PulgarArriba;

        }
    }
}
