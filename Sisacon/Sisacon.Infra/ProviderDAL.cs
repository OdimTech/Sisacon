using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra
{
    public class ProviderDAL
    {
        public int save(Provider provider)
        {
            var addedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.User.Attach(provider.User);

                    context.Provider.Add(provider);

                    addedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        public int update(Provider provider)
        {
            var updatedLines = 0;

            try
            {
                using(var context = new SisaconDbContext())
                {
                    context.Entry(provider.Address).State = EntityState.Modified;
                    context.Entry(provider.Contact).State = EntityState.Modified;
                    context.Entry(provider).State = EntityState.Modified;

                    updatedLines = context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return updatedLines;
        }

        public List<Provider> getProvidersByUserId(int userId)
        {
            var providers = new List<Provider>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    providers = context.Provider
                        .Include("Address")
                        .Include("Contact")
                        .Where(x => x.User.Id == userId && x.ExclusionDate == null).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return providers;
        }

        public Provider getProviderById(int id)
        {
            var provider = new Provider();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    provider = context.Provider
                        .Include("Address")
                        .Include("Contact")
                        .Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return provider;
        }
    }
}
