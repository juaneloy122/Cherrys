using KQ.CommonLib.Models.Tarea;

namespace KQ.Xamarin.ViewModels.Tareas
{
    public class TareaDetalleViewModel : BaseViewModel
    {
        public Tarea Item { get; set; }
        public TareaDetalleViewModel(Tarea item = null)
        {
            Title = item?.Titulo;
            Item = item;
        }
    }
}
