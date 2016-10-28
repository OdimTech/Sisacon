using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class ConfigurationDAL
    {
        public int save (Configuration config)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(config.User);
                    context.Config.Add(config);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(Configuration config)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(config).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public Configuration getConfigurationsByUserId(int id)
        {
            var configs = new Configuration();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    configs = context.Config.Where(x => x.User.Id == id).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return configs;
        }

        public List<Configuration> getConfigurations()
        {
            var listConfigs = new List<Configuration>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    listConfigs = context.Config
                        .Include("User")
                        .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return listConfigs;
        }
    }
}
