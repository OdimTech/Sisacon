using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void save(T obj);
        void update(T obj);
        void delete(int id);
        T getById(int id);
        IEnumerable<T> getAll();
    }
}
