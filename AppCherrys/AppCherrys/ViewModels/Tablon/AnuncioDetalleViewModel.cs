using System;

using AppCherrys.Models;
using AppCherrys.Models.Tablon;

namespace AppCherrys.ViewModels.Tablon
{
    public class AnuncioDetalleViewModel : BaseViewModel
    {
        public Anuncio Item { get; set; }
        public AnuncioDetalleViewModel(Anuncio item = null)
        {
            Title = item?.Titulo;
            Item = item;
        }
    }
}
