using CommonLib.Models.Acta;
using System.Net.Http;

namespace AppCherrys.ClientService.Actas
{
    public class ClientServiceActa : ClientServiceBase<Acta>
    {

        #region Constructor
        public ClientServiceActa(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
            NombreModelo = "Acta";
        }
        #endregion

    }
}
