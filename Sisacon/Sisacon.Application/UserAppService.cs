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

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }

        public ResponseMessage<User> createUser(User user)
        {
            var response = new ResponseMessage<User>();

            try
            {
                _userService.add(user);

                response.Quantity = _userService.commit();

                if (response.Quantity > 0)
                {
                    _userService.createDefaultConfig(user);

                    response.Message = "Usuário criado com sucesso.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<User> emailInUse(string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                if (_userService.emailInUse(email))
                {
                    response.LogicalTest = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<User> getByEmail(string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                response.Value = _userService.getByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<string> getListEmailInUse()
        {
            var response = new ResponseMessage<string>();

            try
            {
                response.ValueList = _userService.getListEmailInUse();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
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

        public ResponseMessage<User> logon(string pass, string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                response.Value = _userService.logon(pass, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
