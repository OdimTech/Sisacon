using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Sisacon.Application
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;
        private ResponseMessage<User> _response;

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
            _response = new ResponseMessage<User>();
        }

        public bool emailInUse(string email)
        {
            var inUse = false;

            try
            {
                var user = new User();

                user.Active = true;
                user.Email = new Email();
                user.Email.Address = "horrander@outlook.com";
                user.eUserType = UserType.eUserType.Admin;
                user.ExclusionDate = null;
                user.Password = "asflkdjfsoe232fdfs";
                user.RegistrationDate = DateTime.Now;
                user.ShowWellcomeMessage = true;

                _userService.add(user);

                if (_userService.emailInUse(email))
                {
                    inUse = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return inUse;
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

        public List<string> getListEmailInUse()
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
