using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Data.Entity;

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

        public int update (Provider provider)
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
    }
}
