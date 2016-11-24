using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class MaterialCategoryDal
    {
        public int save(MaterialCategory materialGategory)
        {
            int addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(materialGategory.User);
                    context.MaterialCategory.Add(materialGategory);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int saveList (List<MaterialCategory> listMaterialCategories)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(listMaterialCategories.Select(x => x.User).FirstOrDefault());
                    context.MaterialCategory.AddRange(listMaterialCategories);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(MaterialCategory materialCategory)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(materialCategory).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public List<MaterialCategory> getCategoriesByUserId(int userId)
        {
            var categories = new List<MaterialCategory>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    categories = context.MaterialCategory.Where(x => x.User.Id == userId && x.ExclusionDate == null).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return categories;
        }

        public MaterialCategory getCategoryById(int categoryId)
        {
            var category = new MaterialCategory();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    category = context.MaterialCategory.Where(x => x.Id == categoryId && x.ExclusionDate == null).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return category;
        }
    }
}
