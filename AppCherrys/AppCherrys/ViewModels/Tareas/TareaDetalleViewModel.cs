using CommonLib.Models.Tarea;

namespace AppCherrys.ViewModels.Tareas
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
