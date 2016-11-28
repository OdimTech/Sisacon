using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;
using Sisacon.Domain;

namespace Sisacon.Tests.BLL
{
    [TestClass]
    public class CreateClientMessageTests
    {
        [TestMethod]
        public void createClientCrudMessage()
        {
            var message = MsgFormater.createClientCrudMessage(ValueObjects.eOperationType.Insert, ValueObjects.eSex.Feminino, "Material");

            Assert.IsTrue(message.Equals("A Material foi Salva com Sucesso!"));
        } 
    }
}
