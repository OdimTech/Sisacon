using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.ValueObjects;

namespace Sisacon.Tests
{
    [TestClass]
    public class CompanyBLLTests
    {
        public Company company { get; set; }
        public CompanyDAL companyDAL { get; set; }

        [TestInitialize]
        public void init()
        {
            company = new Company();
            companyDAL = new CompanyDAL();
        }

        [TestMethod]
        public void save()
        {
            company.Address = new Address();
            company.Contact = new Contact();

            company.ePersonType = ePersonType.Fisica;
            company.Cpf = "05931768637";
            company.CompanyName = "OdimTech";
            company.Address.Cep = "31872380";
            company.Address.Logradouro = "serra da mantiqueira";

            var addedLines = companyDAL.save(company);

            Assert.IsTrue(addedLines > 0);
        }
    }
}
