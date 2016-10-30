using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;
using Sisacon.Domain;

namespace Sisacon.Tests.BLL
{
    /// <summary>
    /// Summary description for AutomaticCodeTests
    /// </summary>
    [TestClass]
    public class AutomaticCodeTests
    {
        public AutomaticCode automaticCode { get; set; }

        [TestInitialize]
        public void init()
        {
            automaticCode = new AutomaticCode();
        }

        [TestMethod]
        public void CriarNovoCodigoAoInserirEntidade()
        {
            var newCode = automaticCode.createAutomaticCode(new Client(), 1);

            Assert.IsTrue(newCode != string.Empty);
        }
    }
}
