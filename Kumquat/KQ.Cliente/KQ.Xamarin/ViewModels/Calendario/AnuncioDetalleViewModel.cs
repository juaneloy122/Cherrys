using KQ.CommonLib.Models.Tablon;

namespace KQ.Xamarin.ViewModels.Tablon
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
