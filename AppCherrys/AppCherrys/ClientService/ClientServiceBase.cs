using AppCherrys.MockDataStore;
using CommonLib.Interfaces;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppCherrys.ClientService
{
    /// <summary>
    /// Contiene los metodos comunes para acceder a los controladores de las APIs
    /// </summary>
    public class ClientServiceBase<T> : IDataStore<T> where T : IItem
    {
        #region propiedades
        protected string NombreModelo { get; set; }
        protected HttpClient _HttpClient = null;
        protected string _BaseUri = null;
        protected string _Uri = null;
        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        protected JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        protected JsonSerializerSettings DeserializationSettings { get; private set; }

        #endregion

        #region Constructor
        public ClientServiceBase(HttpClient httpClient, string uri)
        {
            this._HttpClient = httpClient;
            this._Uri = this._BaseUri = uri;

            SetConfiguracionSerializacionJSon();
            SetConfiguracionDeserializacionJSon();

            ServiceClientTracing.IsEnabled = true;
            ServiceClientTracing.AddTracingInterceptor(new LogServicio());
        }

        #endregion

        #region Metodos publicos

        public IList<T> GetItems()
        {
            //return Task.Factory.StartNew(s => ((IAppCherrysClient)s).GetAnunciosAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            return Task.Factory.StartNew(s => GetItemsAsync(), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<IList<T>> GetItemsAsync()
        {
            using (var _result = await GetItemsWithHttpMessagesAsync().ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        public void EditItem(T item = default(T))
        {
            Task.Factory.StartNew(s => EditItemAsync(item), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }

        public async Task EditItemAsync(T item = default(T))
        {
            await EditWithHttpMessagesAsync(item).ConfigureAwait(false);
        }

        public T CreateItem(T item = default(T))
        {
            return Task.Factory.StartNew(s => CreateItemAsync(item), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<T> CreateItemAsync(T item = default(T))
        {
            using (var _result = await CrearNuevoItemWithHttpMessagesAsync(item).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        public T GetItem(int id)
        {
            return Task.Factory.StartNew(s => GetItemAsync(id), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<T> GetItemAsync(int id)
        {
            using (var _result = await GetItemWithHttpMessagesAsync(id).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        public void DeleteItem(int id)
        {
            Task.Factory.StartNew(s => DeleteItemAsync(id), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }


        public async Task DeleteItemAsync(int id)
        {
            await DeleteAnuncioWithHttpMessagesAsync(id).ConfigureAwait(false);
        }

        #endregion

        #region Metodos abstractos

        protected virtual async Task<HttpOperationResponse<IList<T>>> GetItemsWithHttpMessagesAsync()
        {
            // Serialize Request
            string requestContent = null;

            // Tracing
            string invocationId = setTracing($"Get{NombreModelo}", new Dictionary<string, object> { { "cancellationToken", default(CancellationToken) } });

            _Uri = _BaseUri;

            // Create HTTP transport objects            
            createHttpTransport(out HttpRequestMessage httpRequest, "Get");

            HttpResponseMessage httpResponse = await this._HttpClient.SendAsync(httpRequest, default(CancellationToken)).ConfigureAwait(false);
            ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            default(CancellationToken).ThrowIfCancellationRequested();

            string responseContent = null;
            if ((int)statusCode != 200)
                tratarError(requestContent, invocationId, httpRequest, httpResponse, statusCode);

            // Create Result
            var result = new HttpOperationResponse<IList<T>>
            {
                Request = httpRequest,
                Response = httpResponse
            };
            // Deserialize Response
            if ((int)statusCode == 200)
            {
                responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    result.Body = SafeJsonConvert.DeserializeObject<IList<T>>(responseContent, this.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    httpRequest.Dispose();
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                    throw new SerializationException("No se ha podido deserializar el resultado.", responseContent, ex);
                }
            }

            ServiceClientTracing.Exit(invocationId, result);

            return result;
        }


        protected virtual async Task<HttpOperationResponse> EditWithHttpMessagesAsync(T item = default(T))
        {
            if (item == null)
                throw new Exception($"Se intenta editar un {NombreModelo} que es nulo");

            item.Validar();

            string invocationId = setTracing($"Edit{NombreModelo}", new Dictionary<string, object> { { NombreModelo, item }, { "cancellationToken", default(CancellationToken) } });

            _Uri = _BaseUri;

            // Create HTTP transport objects           
            createHttpTransport(out HttpRequestMessage httpRequest, "PUT");

            // Serialize Request
            string requestContent = SafeJsonConvert.SerializeObject(item, SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json-patch+json; charset=utf-8");

            ServiceClientTracing.SendRequest(invocationId, httpRequest);
            default(CancellationToken).ThrowIfCancellationRequested();

            HttpResponseMessage httpResponse = await this._HttpClient.SendAsync(httpRequest, default(CancellationToken)).ConfigureAwait(false);

            ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            default(CancellationToken).ThrowIfCancellationRequested();
            if ((int)statusCode != 204 && (int)statusCode != 400)
                tratarError(requestContent, invocationId, httpRequest, httpResponse, statusCode);

            // Create Result
            var _result = new HttpOperationResponse
            {
                Request = httpRequest,
                Response = httpResponse
            };

            ServiceClientTracing.Exit(invocationId, _result);

            return _result;
        }


        protected virtual async Task<HttpOperationResponse<T>> CrearNuevoItemWithHttpMessagesAsync(T item = default(T))
        {
            if (item == null)
                throw new Exception($"Se intenta crear un {NombreModelo} que es nulo");

            item.Validar();

            string invocationId = setTracing($"CrearNuevo{NombreModelo}", new Dictionary<string, object> { { NombreModelo, item }, { "cancellationToken", default(CancellationToken) } });

            // Construct URL                       
            _Uri = _BaseUri;
            // Create HTTP transport objects           
            createHttpTransport(out HttpRequestMessage httpRequest, "POST");

            string requestContent = SafeJsonConvert.SerializeObject(item, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json-patch+json; charset=utf-8");

            ServiceClientTracing.SendRequest(invocationId, httpRequest);
            default(CancellationToken).ThrowIfCancellationRequested();

            HttpResponseMessage httpResponse = await this._HttpClient.SendAsync(httpRequest, default(CancellationToken)).ConfigureAwait(false);
            ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            default(CancellationToken).ThrowIfCancellationRequested();

            if ((int)statusCode != 201 && (int)statusCode != 400)
                tratarError(requestContent, invocationId, httpRequest, httpResponse, statusCode);

            // Create Result
            var result = new HttpOperationResponse<T>
            {
                Request = httpRequest,
                Response = httpResponse
            };
            // Deserialize Response
            if ((int)statusCode == 201)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    result.Body = SafeJsonConvert.DeserializeObject<T>(responseContent, this.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    httpRequest.Dispose();
                    if (httpResponse != null)
                        httpResponse.Dispose();

                    throw new SerializationException("No se pudo deserializar la respuesta.", responseContent, ex);
                }
            }

            ServiceClientTracing.Exit(invocationId, result);

            return result;
        }

        private async Task<HttpOperationResponse<T>> GetItemWithHttpMessagesAsync(int id)
        {

            string invocationId = setTracing($"CrearNuevo{NombreModelo}", new Dictionary<string, object> { { "id", id }, { "cancellationToken", default(CancellationToken) } });

            // Construct URL                       
            _Uri = new Uri(new Uri(_BaseUri + (_BaseUri.EndsWith("/") ? "" : "/")), "{id}").ToString();
            _Uri = _Uri.Replace("{id}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(id, this.SerializationSettings).Trim('"')));

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
            var _result = new HttpOperationResponse<T>
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
                    _result.Body = SafeJsonConvert.DeserializeObject<T>(responseContent, this.DeserializationSettings);
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


        private async Task<HttpOperationResponse> DeleteAnuncioWithHttpMessagesAsync(int id)
        {
            string invocationId = setTracing("DeleteAnuncio", new Dictionary<string, object> { { "id", id }, { "cancellationToken", default(CancellationToken) } });

            _Uri = new Uri(new Uri(_BaseUri + (_BaseUri.EndsWith("/") ? "" : "/")), "{id}").ToString();
            _Uri = _Uri.Replace("{id}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(id, this.SerializationSettings).Trim('"')));

            // Create HTTP transport objects
            createHttpTransport(out HttpRequestMessage httpRequest, "DELETE");
            ServiceClientTracing.SendRequest(invocationId, httpRequest);
            default(CancellationToken).ThrowIfCancellationRequested();

            HttpResponseMessage httpResponse = await this._HttpClient.SendAsync(httpRequest, default(CancellationToken)).ConfigureAwait(false);
            ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            default(CancellationToken).ThrowIfCancellationRequested();

            if ((int)statusCode == 404)
                throw new Exception("No se encontró el Id del item que se pretendía borrar");

            if ((int)statusCode != 200)
                tratarError(null, invocationId, httpRequest, httpResponse, statusCode);

            // Create Result
            var _result = new HttpOperationResponse
            {
                Request = httpRequest,
                Response = httpResponse
            };

            ServiceClientTracing.Exit(invocationId, _result);

            return _result;
        }

        #endregion 

        #region Metodos heredados
        protected async void tratarError(string requestContent, string invocationId, HttpRequestMessage httpRequest, HttpResponseMessage httpResponse, HttpStatusCode statusCode)
        {
            var ex = new HttpOperationException(string.Format("La operación devuelve un código de error '{0}'", statusCode));
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
            ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

            ServiceClientTracing.Error(invocationId, ex);

            httpRequest.Dispose();
            if (httpResponse != null)
                httpResponse.Dispose();

            throw ex;
        }

        protected void createHttpTransport(out HttpRequestMessage _httpRequest, string metodo)
        {
            _httpRequest = new HttpRequestMessage
            {
                Method = new HttpMethod(metodo),
                RequestUri = new Uri(_Uri)
            };

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(acceptAllCertifications);
            default(CancellationToken).ThrowIfCancellationRequested();
        }

        protected string setTracing(string metodo, Dictionary<string, object> tracingParameters)
        {
            string invocationId = ServiceClientTracing.NextInvocationId.ToString();
            ServiceClientTracing.Enter(invocationId, this, metodo, tracingParameters);

            return invocationId;
        }

        protected bool acceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void Dispose()
        {

            _HttpClient.Dispose();
            _HttpClient = null;
        }

        #endregion

        #region Metodos privados
        private void SetConfiguracionDeserializacionJSon()
        {
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
        }

        private void SetConfiguracionSerializacionJSon()
        {
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
        }
        #endregion
    }
}
