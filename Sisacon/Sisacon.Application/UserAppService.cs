using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Application
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;
        private ResponseMessage<User> response;

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }

        public bool emailInUse(string email)
        {
            try
            {
                if(_userService.emailInUse(email))
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User getByEmail(string email)
        {
            try
            {
                return _userService.getByEmail(email);
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
                return _userService.getListEmailInUse();
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
                _userService.inactivateUser(id);
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
                return _userService.logon(pass, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
