using CommonLib.Models.Tarea;
using System.Net.Http;

namespace AppCherrys.ClientService.Tareas
{
    public class ClientServiceTarea : ClientServiceBase<Tarea>
    {

        #region Constructor
        public ClientServiceTarea(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
            NombreModelo = "Tarea";
        }
        #endregion

    }
}