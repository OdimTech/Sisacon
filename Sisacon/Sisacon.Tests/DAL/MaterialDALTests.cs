using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;

namespace Sisacon.Tests.DAL
{
    [TestClass]
    public class MaterialDALTests
    {
        public MaterialDAL materialDal { get; set; }
        public Material material { get; set; }

        [TestInitialize]
        public void init()
        {
            materialDal = new MaterialDAL();
            material = new Material();
        }

        [TestMethod]
        public void saveNewMaterial()
        {
            material.CodMaterial = "MAT32343";
            material.Desc = "Material teste";
            material.RegistrationDate = DateTime.Now;
            material.Category = new MaterialCategory() { Id = 7 };
            material.ListPriceResearch = new List<PriceResearch>() { new PriceResearch { Id = 0, Price = 1, SearchDate = DateTime.Now } };

            var addedLines = materialDal.save(material);

            Assert.IsTrue(addedLines > 0);
        }
    }
}
