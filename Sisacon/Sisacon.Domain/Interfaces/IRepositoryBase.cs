using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        int save(T obj);
        int update(T obj);
        int delete(int id);
        T getById(int id);
        IEnumerable<T> getByUserId(int id);
    }
}
