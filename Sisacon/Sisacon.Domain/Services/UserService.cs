using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base (repository)
        {
            _repository = repository;
        }

        public User getByEmail(string email)
        {
            try
            {
                return _repository.getByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> getListEmailInUse()
        {
            try
            {
                return _repository.getListEmailInUse();
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
                _repository.inactivateUser(id);
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
                return _repository.logon(pass, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool emailInUse(string email)
        {
            var emailInUse = false;

            try
            {
                var emaIlList = getListEmailInUse();

                if(!emaIlList.Contains(email))
                {
                    emailInUse = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return emailInUse;
        }
    }
}
