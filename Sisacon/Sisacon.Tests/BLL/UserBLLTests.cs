using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;
using Sisacon.Domain;

namespace Sisacon.Tests
{
    [TestClass]
    public class UserBLLTests
    {
        UserBLL userBLL;
        User user;

        [TestInitialize]
        public void init()
        {
            userBLL = new UserBLL();
            user = new User();
        }        

        [TestMethod]
        public void saveNewUser()
        {
            user.Email = "horrander@gmail.com";
            user.Password = Utilities.encrypt("123456");
            user.Active = true;
            user.RegistrationDate = DateTime.Now;

            var addedLines = userBLL.registrationUser(user).Quantity;

            Assert.IsTrue(addedLines > 0);
        }

        [TestMethod]
        public void getUsedEmail()
        {
            var emailList = userBLL.getUsedEmail().ValueList;

            Assert.IsTrue(emailList.Count > 0);
        }

        [TestMethod]
        public void validateIfEmailInUse()
        {
            var isInUse = userBLL.validateEmailInUse("horrander@gmail.com").LogicalTest;

            Assert.IsTrue(isInUse);
        }

        [TestMethod]
        public void logon()
        {
            var logged = userBLL.logon("111111", "horrander@hotmail.com");

            Assert.IsTrue(logged.LogicalTest);
        }
    }
}
