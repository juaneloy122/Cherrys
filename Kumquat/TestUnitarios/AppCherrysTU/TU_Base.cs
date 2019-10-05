using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppCherrysTU
{
    /// <summary>
    /// Clase de la que heredan todos los test unitarios de Cherrys.
    /// Contiene los metodos comunes que facilitan el desarrollo de las pruebas
    /// </summary>
    [TestClass]
    public class TU_Base
    {
        [TestInitialize]
        public void Init()
        {
            Arrange();
            Act();
        }

        protected virtual void Arrange() { }

        protected virtual void Act() { }

        #region Metodos comunes

        #endregion

    }
}
