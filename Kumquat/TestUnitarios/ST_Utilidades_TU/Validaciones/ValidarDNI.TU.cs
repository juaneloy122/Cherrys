using KumquatTU;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST.Utilidades.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace ST.Utilidades.TU.Validaciones
{
   
    [TestClass]
    public class ValidarDNI_TU : TU_Base
    {
        #region Propiedades
      
        #endregion

        protected override void Arrange()
        {
            base.Arrange();          
        }
    }

    [TestClass]

    public class When_SeIntroduceDNI : ValidarDNI_TU
    {
        protected override void Act()
        {
            base.Act();

        }

        [TestMethod]
        public void Should_NoDarExcepcion()
        {
            string resultado = "09431821G";
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("09431821-G") ==resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("9431821-G") == resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("09431821 G") == resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("9431821 G") == resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("09431821G") ==resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("9431821G") == resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("9.431.821G") == resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("9.431.821-G") == resultado);
            Assert.IsTrue(ValidacionDNI.GetDNIFormatoValido("9.431.821 G") == resultado);
        }

        [TestMethod]
        public void Should_DarExcepcion()
        {
            
            Assert.ThrowsException<ValidationException>(() => ValidacionDNI.GetDNIFormatoValido("109431821-G"));
            Assert.ThrowsException<ValidationException>(() => ValidacionDNI.GetDNIFormatoValido("109431821 G"));
            Assert.ThrowsException<ValidationException>(() => ValidacionDNI.GetDNIFormatoValido("431821-G"));
            Assert.ThrowsException<ValidationException>(() => ValidacionDNI.GetDNIFormatoValido("9431821-H"));
            Assert.ThrowsException<ValidationException>(() => ValidacionDNI.GetDNIFormatoValido("94,31821-G"));
        }
    }

}
