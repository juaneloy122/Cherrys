using AppCherrys.Models.Calendario;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.ViewModels.Calendario
{
    public class EventoDetalleViewModel : BaseViewModel
    {
        public Evento Item { get; set; }
        public EventoDetalleViewModel(Evento item = null)
        {
            Title = item?.Titulo;
            Item = item;
        }
    }
}
