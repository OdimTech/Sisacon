﻿using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public override void add(Provider provider)
        {
            try
            {
                Context.Provider.Add(provider);
                Context.Address.Add(provider.Address);
                Context.Contact.Add(provider.Contact);

                Context.User.Attach(provider.User);
            }
            catch (Exception ex)
            {
                throw ex; 
            }            
        }

        public override void update(Provider provider)
        {
            try
            {
                Context.Entry(provider).State = EntityState.Modified;
                Context.Entry(provider.Address).State = EntityState.Modified;
                Context.Entry(provider.Contact).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Provider getById(int id, bool includeUser)
        {
            try
            {
                return Context.
                    Provider.
                    Include("Address").
                    Include("Contact").
                    Include("User").
                    Where(x => x.Id == id && x.ExclusionDate == null).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Provider> getByUserId(int userId)
        {
            try
            {
                return Context.
                    Provider.
                    Include("Address").
                    Include("Contact").
                    Include("User").
                    Where(x => x.IdUser == userId && x.ExclusionDate == null).
                    ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
