﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace AppCherrys
{
    using AppCherrys.Tablon;
    using Microsoft.Rest;
    using System;

    /// <summary>
    /// Loggin de usuarios, servidor de anuncios, eventos, actas...
    /// </summary>
    public partial class AppCherrysClient : ServiceClient<AppCherrysClient>
    {
        #region Propiedades y atributos
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        protected Uri BaseUri { get; set; }

        public ClientServiceTablon ServiceTablon { get; private set; } = null;
        #endregion

        #region Constructor


        public AppCherrysClient() : base()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            this.BaseUri = new Uri($"{App.AzureBackendUrl}");

            var baseUrl = this.BaseUri.AbsoluteUri;

            //pal tablon
            var urlTablon = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "api/item").ToString();
            ServiceTablon = new ClientServiceTablon(this.HttpClient, urlTablon);
        }

        #endregion





    }
}
