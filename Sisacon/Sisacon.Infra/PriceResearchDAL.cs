using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class PriceResearchDAL
    {
        public int save(PriceResearch price)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Material.Attach(price.Material);
                    context.PriceResearch.Add(price);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(PriceResearch price)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(price).State = EntityState.Modified;
                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public PriceResearch getPriceById(int id)
        {
            var price = new PriceResearch();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    price = context.PriceResearch.Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return price;
        }

        public List<PriceResearch> getPriceByMaterial(int idMaterial)
        {
            var prices = new List<PriceResearch>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    prices = context.PriceResearch
                        .Where(x => x.MaterialId == idMaterial)
                        .OrderBy(x => x.SearchDate)
                        .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return prices;
        }
    }
}
