using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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
            obj.RegistrationDate = DateTime.Now;
            Entity.Add(obj);
        }

        public void update(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void delete(int id)
        {
            var obj = getById(id);
            obj.ExclusionDate = DateTime.Now;
        }

        public T getById(int id)
        {
            
        }

        public IEnumerable<T> getByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> getAll()
        {
            throw new NotImplementedException();
        }

        public void commit()
        {
            
        }
    }
}
