using CommonLib.Models.Tablon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCherrysClientTU.ClientService
{
    [TestClass]
    public class When_SePidenDatosDeAnunciosAlServidor : For_SeInicializaElServicio
    {
        protected override void Act()
        {
            base.Act();

        }

        [TestMethod]
        public void Should_DevolverDatosSincronamente()
        {
            IList<Anuncio> items = Cliente.GetItems();
            comprobarDatos(items);
        }

        [TestMethod]
        public void Should_DevolverDatosAsincronamente()
        {
            IList<Anuncio> items = Cliente.GetItemsAsync().GetAwaiter().GetResult();
            comprobarDatos(items);
        }

        private void comprobarDatos(IList<Anuncio> items)
        {
            Assert.IsNotNull(items);

            Assert.IsTrue(items.Count > 0);
        }
    }

    [TestClass]
    public class When_SeBorraUnAnunciodelServidor : For_SeInicializaElServicio
    {
        

        protected override void Act()
        {
            base.Act();
        }

        [TestMethod]
        public void Should_DeleteItemSincronamente()
        {
            Anuncio item = addAnuncioPrueba();
            Cliente.DeleteItem(item.Id);
            comprobarDatos();
        }

        [TestMethod]
        public void Should_DeleteItemAsincronamente()
        {
            Anuncio item = addAnuncioPrueba();
            Cliente.DeleteItemAsync(item.Id).GetAwaiter().GetResult();
            comprobarDatos();
        }


        [TestMethod]
        public void Should_DeleteItemNoValido()
        {
            Assert.ThrowsException<System.Exception>(() => Cliente.DeleteItem(-2));
        }

        private void comprobarDatos()
        {
            Anuncio item = getAnuncioPruebaDelServidor();

            Assert.IsNull (item);
        }

        private Anuncio getAnuncioPruebaDelServidor()
        {
            return Cliente.GetItems().FirstOrDefault(x => x.IdUsuario == "VS" && x.Titulo == "Prueba");
        }

        private Anuncio addAnuncioPrueba()
        {
            //borramos primero no vaya a ser de que ya exista, para intentar que sólo exista uno
            Anuncio item = getAnuncioPruebaDelServidor();
            if (item == null)
                item = Cliente.CreateItem(NuevoAnuncio);

            return item;
        }
    }

    [TestClass]
    public class When_SeAnadeUnAnuncioAlServidor : For_SeInicializaElServicio
    {
       

        protected override void Act()
        {
            base.Act();

            
        }

        [TestMethod]
        public void Should_AddItemSincronamente()
        {
            borrarAnuncioPrueba();
            Anuncio devuelto = Cliente.CreateItem(NuevoAnuncio);
            comprobarDatos(devuelto);
        }

        [TestMethod]
        public void Should_AddItemAsincronamente()
        {
            borrarAnuncioPrueba();
            Anuncio devuelto = Cliente.CreateItemAsync(NuevoAnuncio).GetAwaiter ().GetResult ();
            comprobarDatos(devuelto);
        }


        [TestMethod]
        public void Should_AddItemNull()
        {  
            Assert.ThrowsException<System.Exception>(() => Cliente.CreateItem(null));
        }

        private void comprobarDatos(Anuncio devuelto)
        {
            Anuncio item = getAnuncioPruebaDelServidor();
           
            Assert.AreEqual (item.Id, devuelto.Id);
            Assert.AreEqual(item.Titulo, devuelto.Titulo);
        }

        private Anuncio getAnuncioPruebaDelServidor()
        {
            return Cliente.GetItems().FirstOrDefault(x => x.IdUsuario == "VS" && x.Titulo == "Prueba");
        }

        private void borrarAnuncioPrueba()
        {
            //borramos primero no vaya a ser de que ya exista, para intentar que sólo exista uno
            Anuncio item = getAnuncioPruebaDelServidor();
            if (item !=null)
                Cliente.DeleteItem(item.Id);
        }
    }

    [TestClass]
    public class When_SeEditaUnAnuncioAlServidor : For_SeInicializaElServicio
    {
        
        protected override void Act()
        {
            base.Act();

        }

        [TestMethod]
        public void Should_EditItemSincronamente()
        {
            Anuncio item = addAnuncioPrueba();
            item.Descripcion = "Prueba sincrona";
            Cliente.EditItem(item);
            comprobarDatos();
        }

        [TestMethod]
        public void Should_EditItemAsincronamente()
        {
            Anuncio item = addAnuncioPrueba();
            item.Descripcion = "Prueba sincrona";
            Cliente.EditItemAsync(item);
            comprobarDatos();
        }


        [TestMethod]
        public void Should_EditItemNull()
        {
            Assert.ThrowsException<System.Exception>(() => Cliente.EditItem(null));
        }

        private void comprobarDatos()
        {
            Anuncio item = getAnuncioPruebaDelServidor();

            Assert.AreEqual("Prueba sincrona", item.Descripcion );
        }

        private Anuncio getAnuncioPruebaDelServidor()
        {
            return Cliente.GetItems().FirstOrDefault(x => x.IdUsuario == "VS" && x.Titulo == "Prueba");
        }

        private Anuncio addAnuncioPrueba()
        {
            //borramos primero no vaya a ser de que ya exista, para intentar que sólo exista uno
            Anuncio item = getAnuncioPruebaDelServidor();
            if (item == null)
                item = Cliente.CreateItem(NuevoAnuncio);

            return item;
        }
    }
}
