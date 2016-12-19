using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected SisaconDbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new SisaconDbContext();
        }

        private DbSet<T> Entity { get { return Context.Set<T>(); } }

        public void save(T obj)
        {
            try
            {
                obj.RegistrationDate = DateTime.Now;
                Entity.Add(obj);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void update(T obj)
        {
            try
            {
                Context.Entry(obj).State = EntityState.Modified;

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete(int id)
        {
            try
            {
                var obj = getById(id);
                obj.ExclusionDate = DateTime.Now;

                update(obj);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public T getById(int id)
        {
            try
            {
                return Entity.Where(x => x.Id == id && x.ExclusionDate == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> getAll()
        {
            try
            {
                return Entity.Where(x => x.ExclusionDate == null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
