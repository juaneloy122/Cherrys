using AppCherrysTU;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST_Utilidades.Comunicaciones;

namespace ST_Utilidades_TU.Comunicaciones
{
    [TestClass]
    public class TU_EnvioEmail : TU_Base
    {
        #region Propiedades
        protected string DireccionDestino { get; set; } = "antonioastur@gmail.com";
        protected string Asunto { get; set; } = "Prueba Unitaria de envio de email";

        protected EnvioMail Mail { get; set; }
        #endregion

        protected override void Arrange()
        {
            base.Arrange();

            Mail = new EnvioMail(DireccionDestino, Asunto, "Si te llegó, todo bien ;)");
        }
    }

    [TestClass]

    public class When_SeEnviaUnEmail : TU_EnvioEmail
    {
        protected override void Act()
        {
            base.Act();
            
        }

        [TestMethod]
        public void Should_NoDarExcepcion()
        {
            Assert.IsTrue (Mail.EnviarEmail()); 
        }
    }


}
