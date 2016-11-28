using Sisacon.Domain;

namespace Sisacon.BLL
{
    public interface IBaseBLL<T> where T : class
    {
        ResponseMessage<T> save(T entity);
        ResponseMessage<T> update(T entity);
        ResponseMessage<T> delete(int id);
        ResponseMessage<T> getById(int id);
        ResponseMessage<T> getByUserId(int userId);
    }
}
