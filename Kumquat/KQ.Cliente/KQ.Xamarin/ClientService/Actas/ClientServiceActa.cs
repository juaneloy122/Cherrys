using KQ.CommonLib.Models.Acta;
using System.Net.Http;

namespace KQ.Xamarin.ClientService.Actas
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
