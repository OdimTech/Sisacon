using System;
using System.Collections.Generic;

namespace Sisacon.Application.Interfaces
{
    public interface IAppServiceBase<T> : IDisposable where T : class
    {
        void attach(T obj);
        void add(T obj);
        void update(T obj);
        void delete(int id);
        T getById(int id);
        List<T> getAll();
        void commit();
        void commitAsync();
        void rollback();
    }
}
