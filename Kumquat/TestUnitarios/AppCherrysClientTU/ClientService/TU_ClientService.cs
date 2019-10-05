using AppCherrysTU;
using KQ.CommonLib.Models.Tablon;
using KQ.Xamarin.ClientService;
using KQ.Xamarin.MockDataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppCherrysClientTU.ClientService
{
    /// <summary>
    /// Para ejecutar las pruebas, es necesario que el servicio este corriendo para que se pueda conectar a él y pedir los datos.
    /// Las propias pruebas NO lo levantan en automático.
    /// </summary>
    [TestClass]
    public class For_SeInicializaElServicio : TU_Base
    {
        #region Propiedades
        public string BackendUrl { get; } = "http://localhost:37601";

        public IDataStore<Anuncio> Cliente { get; private set; }

        public Anuncio NuevoAnuncio { get; set; } = new Anuncio("Prueba", "Prueba unitaria", DateTime.Now, "VS");

        #endregion
        protected override void Arrange()
        {
            base.Arrange();

            Cliente = KQClient.GetInstance().ServiceTablon;
        }
    }


}
