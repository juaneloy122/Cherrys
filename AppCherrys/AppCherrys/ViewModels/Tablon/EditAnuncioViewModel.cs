using CommonLib.Models.Tablon;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCherrys.ViewModels.Tablon
{
    public class EditAnuncioViewModel : BaseViewModel
    {
        public Anuncio Item
        {
            get => _Item;
            set
            {
                _Item = value;
                OnPropertyChanged("Item");
            }
        }

        private Anuncio _Item = null;

        public EditAnuncioViewModel(Anuncio item = null)
        {
            Item = item;
        }
    }
}
