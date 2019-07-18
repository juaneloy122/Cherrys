using System;

using AppCherrys.Models;

namespace AppCherrys.ViewModels.Tablon
{
    public class AnuncioDetalleViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public AnuncioDetalleViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
