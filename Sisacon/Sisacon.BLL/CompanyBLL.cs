using Sisacon.Domain;
using Sisacon.Infra;
using System;

namespace Sisacon.BLL
{
    public class CompanyBLL
    {
        public CompanyDAL companyDAL { get; set; }
        public CompanyBLL()
        {
            companyDAL = new CompanyDAL();
        }

        public ResponseMessage<Company> save(Company company)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                response.Quantity = companyDAL.save(company);
                response.Value = company;

                if (response.Quantity > 0)
                {
                    response.Message = Msg.SucInsertCompany;

                    cancelWellcomeMessage(company.User.Id);
                }
                else
                {
                    response.Message = Msg.ErrInsertCompany;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<Company>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Obtem a empresa do banco a partir de um Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ResponseMessage<Company> getCompanyByUser(int user)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                response.Value = companyDAL.getCompanyByUser(user);
                
            }
            catch (Exception ex)
            {
                return LogBLL<Company>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Company> update(Company company)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                response.Quantity = companyDAL.update(company);
                response.Value = company;

                if (response.Quantity > 0)
                {
                    response.LogicalTest = true;
                    response.Message = Msg.SucUpdateCompany;
                }
                else
                {
                    response.LogicalTest = false;
                    response.Message = Msg.ErrUpdateCompany;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<Company>.createLog(ex);                
            }

            return response;
        }

        /// <summary>
        /// Após o cadastro da empesa ter sido realizado, a mensagem de boas vindas deve ser desabilitada
        /// </summary>
        public void cancelWellcomeMessage(int idUser)
        {
            var response = new ResponseMessage<User>();
            var userBLL = new UserBLL();

            try
            {
                response = userBLL.getUserById(idUser);
                response.Value.ShowWellcomeMessage = false;

                userBLL.update(response.Value);
            }
            catch (Exception ex)
            {
                LogBLL<Company>.createLog(ex);
            }
        }
    }
}
