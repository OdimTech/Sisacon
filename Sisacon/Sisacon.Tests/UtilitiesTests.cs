using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;

namespace Sisacon.Tests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void encryptValue()
        {
            var decryptedValue = "111111";
            var encryptValue = Utilities.encrypt(decryptedValue);

            Assert.IsTrue(encryptValue != string.Empty);
        }
    }
}
