using AppCherrys.Models.Tarea;
using System;
using System.Collections.Generic;
using System.Text;

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
