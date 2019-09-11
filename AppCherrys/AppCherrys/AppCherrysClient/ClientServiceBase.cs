using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace AppCherrys
{
    /// <summary>
    /// Contiene los metodos comunes para acceder a los controladores de las APIs
    /// </summary>
    public class ClientServiceBase
    {
        #region propiedades
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

        #region Metodos publicos y heredados
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
