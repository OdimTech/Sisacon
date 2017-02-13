﻿using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public override void update(Material material)
        {
            try
            {
                material.Category = null;
                material.ListPriceResearch = null;

                Context.Entry(material).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Material getById(int id, bool includeUser)
        {
            try
            {
                return Context.
                    Material.
                    Include("User").
                    Include("Category").
                    Include("ListPriceResearch").
                    Include("ListPriceResearch.Provider").
                    Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefault();
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
                    Include("ListPriceResearch").
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
