using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class MaterialDAL
    {
        public int save(Material material)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Material.Add(material);
                    context.User.Attach(material.User);
                    context.MaterialCategory.Attach(material.Category);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(Material material)
        {
            var updatedLines= 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    material.CategoryId = material.Category.Id;
                    context.Entry(material).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public Material getMaterialById(int id)
        {
            var material = new Material();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    material = context.Material.Include("Category").Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return material;
        }

        public List<Material> getMaterialsByUserId(int userId)
        {
            var materials = new List<Material>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    materials = context.Material
                        .Include("Category")
                        .Include("ListPriceResearch")
                        .Where(x => x.User.Id == userId && x.ExclusionDate == null).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return materials;
        }
 
        public List<Material> getMaterialsByCategory(int idCategory)
        {
            var materials = new List<Material>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    materials = context.Material.Where(x => x.Category.Id == idCategory && x.ExclusionDate == null).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex; 
            }

            return materials;
        }
    }
}
