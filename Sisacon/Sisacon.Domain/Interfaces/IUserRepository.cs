using Sisacon.Domain.Entities;

namespace Sisacon.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User getByEmail(string email);
    }
}
