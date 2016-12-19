using System.Collections.Generic;

namespace Sisacon.Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        void save(T obj);
        void update(T obj);
        void delete(int id);
        T getById(int id);
        IEnumerable<T> getAll();
    }
}
