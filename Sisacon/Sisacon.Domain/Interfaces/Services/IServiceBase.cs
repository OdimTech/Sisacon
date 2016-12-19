using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IServiceBase<T> : IDisposable where T : BaseEntity
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
