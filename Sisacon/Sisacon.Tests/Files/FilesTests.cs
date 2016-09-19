using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;
using Sisacon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Tests
{
    [TestClass]
    public class FilesTests
    {
        public FilesBLL files { get; set; }

        [TestInitialize]
        public void init()
        {
            files = new FilesBLL("C:\\Users\\S1hor\\Documents\\Repositorios\\Github\\Sisacon\\Sisacon\\Sisacon.UI\\Content\\UserImages\\");
        }

        [TestMethod]
        public void createPath()
        {
            var user = new User();

            user.Email = "horrander@gmail";

            var teste = files.createUserPathAsync(user);

            Assert.IsTrue(teste != null);
        }
    }
}
