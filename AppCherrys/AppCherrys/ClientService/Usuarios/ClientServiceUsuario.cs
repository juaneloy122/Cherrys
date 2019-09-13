using CommonLib.Models.Usuario;
using System.Net.Http;

namespace AppCherrys.ClientService.Usuarios
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