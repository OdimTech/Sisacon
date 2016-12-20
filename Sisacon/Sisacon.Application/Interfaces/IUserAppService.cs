using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        ResponseMessage<User> createUser(User user);
        ResponseMessage<User> getByEmail(string email);
        ResponseMessage<string> getListEmailInUse();
        ResponseMessage<User> logon(string pass, string email);
        void inactivateUser(int id);
        ResponseMessage<User> emailInUse(string email);
    }
}
