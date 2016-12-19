﻿using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        User getByEmail(string email);
        List<string> getListEmailInUse();
        bool emailInUse(string email);
        User logon(string pass, string email);
        void inactivateUser(int id);
    }
}
