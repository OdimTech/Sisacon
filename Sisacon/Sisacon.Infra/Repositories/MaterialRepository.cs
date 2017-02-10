using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class MaterialRepository : RepositoryBase<Material>, IMaterialRepository
    {
        public override void add(Material material)
        {
            try
            {
                Context.User.Attach(material.User);
                Context.MaterialCategory.Attach(material.Category);

                Context.Material.Add(material);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Material> getByUserId(int userId)
        {
            try
            {
                return Context.
                    Material.
                    Include("User").
                    Include("Category").
                    Include("PriceResearch").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
