using System;

namespace Sisacon.Application.Interfaces
{
    public interface IAppServiceBase<T> : IDisposable where T : class
    {
        void attach(T obj);
        int add(T obj);
        int update(T obj);
        int delete(int id);
        ResponseMessage<T> getById(int id);
        ResponseMessage<T> getAll();
        int commit();
        void commitAsync();
        void rollback();
    }
}
