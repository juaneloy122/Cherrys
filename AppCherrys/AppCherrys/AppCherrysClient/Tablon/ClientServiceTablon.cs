using AppCherrys.Services;
using CommonLib.Models.Tablon;
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

namespace AppCherrys.Tablon
{
    internal class ClientServiceTablon: ClientServiceBase, IDataStore <Anuncio>// IClientTablon
    {
        #region propiedades
       
        #endregion

        #region Constructor
        public ClientServiceTablon (HttpClient httpClient, string uri):base(httpClient, uri)
        {
           
        }
        #endregion

        #region Metodos publicos
       
        public IList<Anuncio> GetItems()
        {
            //return Task.Factory.StartNew(s => ((IAppCherrysClient)s).GetAnunciosAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            return Task.Factory.StartNew(s => GetItemsAsync(),CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }
      
        public async Task<IList<Anuncio>> GetItemsAsync()
        {
            using (var _result = await GetAnunciosWithHttpMessagesAsync().ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

       
        public void EditItem(Anuncio item = default(Anuncio))
        {
            Task.Factory.StartNew(s => EditItemAsync(item),CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }
       
        public async Task EditItemAsync(Anuncio item = default(Anuncio))
        {
            await EditWithHttpMessagesAsync(item).ConfigureAwait(false);
        }
       
        public Anuncio CreateItem(Anuncio item = default(Anuncio))
        {
            return Task.Factory.StartNew(s => CreateItemAsync(item), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }
                
        public async Task<Anuncio> CreateItemAsync(Anuncio item = default(Anuncio))
        {
            using (var _result = await CrearNuevoAnuncioWithHttpMessagesAsync(item).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
                
        public Anuncio GetItem(int id)
        {
            return Task.Factory.StartNew(s =>GetItemAsync(id), CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }
       
        public async Task<Anuncio> GetItemAsync(int id)
        {
            using (var _result = await GetItemWithHttpMessagesAsync(id).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
                
        public void DeleteItem( int id)
        {
            Task.Factory.StartNew(s =>DeleteItemAsync(id),CancellationToken.None).Unwrap().GetAwaiter().GetResult();
        }

       
        public async Task DeleteItemAsync( int id)
        {
            await DeleteAnuncioWithHttpMessagesAsync(id).ConfigureAwait(false);
        }

        #endregion
        #region Metodos privados
      
        private async Task<HttpOperationResponse<IList<Anuncio>>> GetAnunciosWithHttpMessagesAsync()
        {
            // Serialize Request
            string requestContent = null;
         
            // Tracing
            string invocationId = setTracing("GetAnuncios",new Dictionary<string, object> { { "cancellationToken", default(CancellationToken) } });

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
            var result = new HttpOperationResponse<IList<Anuncio>>
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
                    result.Body = SafeJsonConvert.DeserializeObject<IList<Anuncio>>(responseContent, this.DeserializationSettings);
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

       
        private async Task<HttpOperationResponse> EditWithHttpMessagesAsync(Anuncio item = default(Anuncio))
        {
            if (item == null)
                throw new Exception("Se intenta editar un anuncio que es nulo");
            
            item.Validar();

            string invocationId = setTracing("EditAnuncio", new Dictionary<string, object> { { "item", item },{ "cancellationToken", default(CancellationToken) } });

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


        private async Task<HttpOperationResponse<Anuncio>> CrearNuevoAnuncioWithHttpMessagesAsync(Anuncio item = default(Anuncio))
        {
            if (item == null)
                throw new Exception("Se intenta crear un anuncio que es nulo");

            item.Validar();

            string invocationId = setTracing("CrearNuevoAnuncio", new Dictionary<string, object> { { "item", item }, { "cancellationToken", default(CancellationToken) } });

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
            var result = new HttpOperationResponse<Anuncio>
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
                    result.Body = SafeJsonConvert.DeserializeObject<Anuncio>(responseContent, this.DeserializationSettings);
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

        private async Task<HttpOperationResponse<Anuncio>> GetItemWithHttpMessagesAsync(int id)
        {

            string invocationId = setTracing("CrearNuevoAnuncio", new Dictionary<string, object> { { "id", id }, { "cancellationToken", default(CancellationToken) } });

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
            var _result = new HttpOperationResponse<Anuncio>
            {
                Request =httpRequest,
                Response = httpResponse
            };
            // Deserialize Response
            if ((int)statusCode == 200)
            {
               string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Anuncio>(responseContent, this.DeserializationSettings);
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


        private async Task<HttpOperationResponse> DeleteAnuncioWithHttpMessagesAsync(int id )
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
            
            if ((int)statusCode != 200 && (int)statusCode != 404)
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
        ///TODO: Meter las extensiones como metodos publicos de la clase
        ///TODO: Borrar la clase extensiones, poner privados los metodos originales de la clase y comprobar que funciona
        ///TODO: Pruebas unitarias para los anuncios
        ///TODO: Meter el resto de objetos tanto en el servicio como en el cliente  
    }
}
