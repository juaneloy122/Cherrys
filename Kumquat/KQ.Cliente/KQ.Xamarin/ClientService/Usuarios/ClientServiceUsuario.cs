using KQ.CommonLib.Models.Usuario;
using System.Net.Http;

namespace KQ.Xamarin.ClientService.Usuarios
{
    public class ClientServiceUsuario : ClientServiceBase<Usuario>
    {

        #region Constructor
        public ClientServiceUsuario(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
            NombreModelo = "Usuario";
        }
        #endregion

    }
}