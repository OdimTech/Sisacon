using Sisacon.Domain.Interfaces;
using Sisacon.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SisaconDbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new SisaconDbContext();
        }

        public int save(T obj)
        {
            Context.Set<T>().Add(obj);
            return Context.SaveChanges();
        }

        public int update(T obj)
        {
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public T getById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> getByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
