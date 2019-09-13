using CommonLib.Models.Tablon;
using System.Net.Http;

namespace AppCherrys.ClientService.Tablon
{
    public class ClientServiceTablon : ClientServiceBase<Anuncio>
    {

        #region Constructor
        public ClientServiceTablon(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
            this.NombreModelo = "Anuncio";
        }
        #endregion

      
    }
}
