using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using System;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public User getByEmail(string email)
        {
            try
            {
                return Context.User.Where(x => x.Email == email && x.Active == true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
