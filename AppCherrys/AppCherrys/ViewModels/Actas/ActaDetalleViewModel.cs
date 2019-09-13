using CommonLib.Models.Acta;

namespace AppCherrys.ViewModels.Actas
{
    public class ActaDetalleViewModel : BaseViewModel
    {
        public Acta Item { get; set; }
        public ActaDetalleViewModel(Acta item = null)
        {
            Title = item?.Titulo;
            Item = item;
        }
    }
}
