using KQ.CommonLib.Models.Usuario;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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

        #region Metodos publicos
        public Usuario GetUsuario(string email, string pwd)
        {
            return Task.Factory.StartNew(s => GetUsuarioAsync(email, pwd), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<Usuario> GetUsuarioAsync(string email, string pwd)
        {
            using (var _result = await GetItemWithHttpMessagesAsync(email, pwd).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        #endregion

        #region Metodos privados
        private async Task<HttpOperationResponse<Usuario>> GetItemWithHttpMessagesAsync(string email, string pwd)
        {

            string invocationId = setTracing($"CrearNuevo{NombreModelo}", new Dictionary<string, object> { { "email", email }, { "pwd", pwd }, { "cancellationToken", default(CancellationToken) } });

            // Construct URL                       
            _Uri = new Uri(new Uri(_BaseUri + (_BaseUri.EndsWith("/") ? "" : "/")), "{email},{pwd}").ToString();
            _Uri = _Uri.Replace("{email}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(email, this.SerializationSettings).Trim('"')));
            _Uri = _Uri.Replace("{pwd}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(pwd, this.SerializationSettings).Trim('"')));

            // Create HTTP transport objects           
            createHttpTransport(out HttpRequestMessage httpRequest, "GET");

            ServiceClientTracing.SendRequest(invocationId, httpRequest);
            default(CancellationToken).ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this._HttpClient.SendAsync(httpRequest, default(CancellationToken)).ConfigureAwait(false);
            ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            default(CancellationToken).ThrowIfCancellationRequested();


            if ((int)statusCode != 200 && (int)statusCode != 404)
                tratarError(null, invocationId, httpRequest, httpResponse, statusCode);

            // Create Result
            var _result = new HttpOperationResponse<Usuario>
            {
                Request = httpRequest,
                Response = httpResponse
            };
            // Deserialize Response
            if ((int)statusCode == 200)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Usuario>(responseContent, this.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    httpRequest.Dispose();
                    if (httpResponse != null)
                        httpResponse.Dispose();

                    throw new SerializationException("No se pudo deserializar la respuesta.", responseContent, ex);
                }
            }

            ServiceClientTracing.Exit(invocationId, _result);

            return _result;
        }

        #endregion
    }
}