using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User getByEmail(string email)
        {
            try
            {
                return Context.User.Where(x => 
                        x.Email.Address == email &&
                        x.Active == true &&
                        x.ExclusionDate == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<string> getListEmailInUse()
        {
            try
            {
                return Context.User.Where(x => 
                        x.ExclusionDate == null && 
                        x.Active == true)
                        .Select(x => 
                        x.Email.Address).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void inactivateUser(int id)
        {
            try
            {
                var user = getById(id);

                user.Active = false;

                update(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User logon(string pass, string email)
        {
            try
            {
                return Context.User.Where(x => 
                        x.Password == pass && 
                        x.Email.Address == email && 
                        x.ExclusionDate == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
