using CommonLib.Models.Calendario;

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
