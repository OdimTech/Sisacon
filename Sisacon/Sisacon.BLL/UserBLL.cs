using Sisacon.BLL;
using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using System.Net;

namespace Sisacon.BLL
{
    public class UserBLL
    {
        private UserDAL userDal { get; set; }

        public UserBLL()
        {
            userDal = new UserDAL();
        }

        /// <summary>
        /// Retorna um usuário de acordo com o Id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseMessage<User> getUserById(int id)
        {
            var response = new ResponseMessage<User>();

            try
            {
                response.Value = userDal.getUserById(id);

                if(response.Value == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<User>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Valida o acesso do usuario ao sistema
        /// </summary>
        /// <param name="pass">Senha</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public ResponseMessage<User> logon(string pass, string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                pass = Utilities.encrypt(pass);

                var user = userDal.logon(pass, email);

                if(user != null && user.Id > 0)
                {
                    if(user.Active)
                    {
                        response.LogicalTest = true;
                        response.Value = user;

                        user.LastLogin = DateTime.Now;

                        update(user);
                    }
                    else
                    {
                        response.LogicalTest = false;
                        response.Message = Msg.ErrUserNotActive;
                        response.StatusCode = HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.LogicalTest = false;
                    response.Message = Msg.ErrFailedLogon;
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<User>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Insere um novo usuário no Sistema
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Quantidade de registros inseridos no banco de dados</returns>
        public ResponseMessage<string> registrationUser(User user)
        {
            var response = new ResponseMessage<string>();

            try
            {
                user.Password = Utilities.encrypt(user.Password);

                response.Quantity = userDal.registerUser(user);
                
                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucInsertUser;
                    response.LogicalTest = true;
                }
                else
                {
                    response.Message = Msg.ErrInsertUser;
                    response.LogicalTest = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<string>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Obtem do banco de dados os email de usuários já cadastrados
        /// </summary>
        /// <returns></returns>
        public ResponseMessage<string> getUsedEmail()
        {
            var response = new ResponseMessage<string>();

            try
            {
                response.ValueList = userDal.getUsedEmail();
            }
            catch (Exception ex)
            {
                return LogBLL<string>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Valida se o email informado pelo usuário já está em uso
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public ResponseMessage<string> validateEmailInUse(string email)
        {
            var response = new ResponseMessage<string>();

            try
            {
                var emailList = getUsedEmail().ValueList;

                if (emailList.Contains(email))
                {
                    response.LogicalTest = true;
                    response.Message = Msg.ErrEmailInUse;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<string>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Atualiza as informações do Usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Quantidade de linhas alteradas</returns>
        public ResponseMessage<string> update(User user)
        {
            var response = new ResponseMessage<string>();

            try
            {
                response.Quantity = userDal.update(user);

                if(response.Quantity > 0)
                {
                    response.LogicalTest = true;
                    response.Message = Msg.SucUpdateUser;
                }
                else
                {
                    response.LogicalTest = false;
                    response.Message = Msg.ErrUpdateUser;
                    response.StatusCode = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<string>.createLog(ex);
            }

            return response;
        }
    }
}
