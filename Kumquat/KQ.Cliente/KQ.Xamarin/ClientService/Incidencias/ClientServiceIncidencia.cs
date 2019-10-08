using KQ.CommonLib.Models.Incidencia;
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
    public class ClientServiceIncidencia : ClientServiceBase<Incidencia>
    {

        #region Constructor
        public ClientServiceIncidencia(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
            NombreModelo = "Incidencia";
        }
        #endregion
              
    }
}