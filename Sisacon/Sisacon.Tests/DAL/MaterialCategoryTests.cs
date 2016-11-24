using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sisacon.BLL;
using Sisacon.Domain;
using Sisacon.Infra;
using System.Collections.Generic;

namespace Sisacon.Tests.DAL
{
    [TestClass]
    public class MaterialCategoryTests
    {
        public MaterialCategoryDal materialCategoryDal { get; set; }
        public MaterialCategory materialCategory { get; set; }

        [TestInitialize]
        public void init()
        {
            materialCategoryDal = new MaterialCategoryDal();
            materialCategory = new MaterialCategory();
        }

        [TestMethod]
        public void salvarListaDeCategoriasDeMateriais()
        {
            var user = new UserBLL().getUserById(1).Value;

            var list = new List<MaterialCategory>()
            {new MaterialCategory { Description = "Embalagens", User = user },
             new MaterialCategory { Description = "Tintas", User = user },
             new MaterialCategory { Description = "Tecidos", User = user }};

            var addedLines = 0;

            addedLines = materialCategoryDal.saveList(list);

            Assert.IsTrue(addedLines > 0);
        }
    }
}
