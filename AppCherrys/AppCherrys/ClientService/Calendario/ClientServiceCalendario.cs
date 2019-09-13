using CommonLib.Models.Calendario;
using System.Net.Http;

namespace AppCherrys.ClientService.Calendario
{
    public class ClientServiceCalendario : ClientServiceBase<Evento>
    {

        #region Constructor
        public ClientServiceCalendario(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
            NombreModelo = "Evento";
        }
        #endregion

    }
}
