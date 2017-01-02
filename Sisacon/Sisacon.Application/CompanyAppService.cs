using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.Sex;
using static Sisacon.Domain.Enuns.OperationType;

namespace Sisacon.Application
{
    public class CompanyAppService : AppServiceBase<Company>, ICompanyAppService
    {
        private readonly ICompanyService _companyService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public CompanyAppService(ICompanyService companyService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(companyService)
        {
            _companyService = companyService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<Company> saveOrUpdate(Company company)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                if(company.Id > 0)
                {
                    _companyService.update(company);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Empresa");
                }
                else
                {
                    _companyService.add(company);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Feminino, "Empresa");
                }

                _companyService.commit();
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, company.User, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Company> getCompanyByUser(int userId)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                response.Value = _companyService.getCompanyByUser(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}
