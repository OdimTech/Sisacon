using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : BaseEntity 
    {
        void save(T obj);
        void update(T obj);
        void delete(int id);
        T getById(int id);
        IEnumerable<T> getAll();
    }
}
