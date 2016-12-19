using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Application.Interfaces
{
    public interface IUserAppService
    {
        User getByEmail(string email);
        List<string> getListEmailInUse();
        User logon(string pass, string email);
        void inactivateUser(int id);
        bool emailInUse(string email);
    }
}
