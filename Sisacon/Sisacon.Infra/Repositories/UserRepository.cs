using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;

namespace Sisacon.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public void getByEmail(string email)
        {
            //try
            //{
            //    return Context.User.Where(x => x.Email == email && x.Active == true).FirstOrDefault();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
