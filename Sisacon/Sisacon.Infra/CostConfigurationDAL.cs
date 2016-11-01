using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class CostConfigurationDAL
    {
        public int save(CostConfiguration costConfig)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(costConfig.User);
                    context.CostConfiguration.Add(costConfig);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(CostConfiguration costConfig)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(costConfig).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public CostConfiguration getCostConfigurationById(int id)
        {
            var config = new CostConfiguration();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    config = context.CostConfiguration.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return config;

        }

        public CostConfiguration getCostConfigurationByUserId(int userId)
        {
            var configs = new CostConfiguration();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    configs = context.CostConfiguration.Where(x => x.User.Id == userId).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return configs;
        }
    }
}
