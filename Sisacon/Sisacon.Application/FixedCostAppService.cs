using Sisacon.Application.Interfaces;
using Sisacon.Domain.ValueObjects;
using System;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.Sex;
using static Sisacon.Domain.Enuns.OperationType;

namespace Sisacon.Application
{
    public class FixedCostAppService : AppServiceBase<FixedCost>, IFixedCostAppService
    {
        private readonly IFixedCostService _fixedCostService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public FixedCostAppService(IFixedCostService fixedCostService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(fixedCostService)
        {
            _fixedCostService = fixedCostService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<FixedCost> deleteFixedCost(int fixedCostId)
        {
            var response = new ResponseMessage<FixedCost>();

            try
            {
                var fixedCost = _fixedCostService.getById(fixedCostId);

                if(fixedCost != null)
                {
                    _fixedCostService.delete(fixedCost);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Feminino, "Gasto Mensal");
                }

                if(_fixedCostService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<FixedCost> saveOrUpdate(FixedCost fixedCost)
        {
            var response = new ResponseMessage<FixedCost>();

            try
            {
                if(fixedCost.Id > 0)
                {
                    _fixedCostService.update(fixedCost);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Gasto Mensal");
                }
                else
                {
                    fixedCost.CostId = fixedCost.Cost.Id;
                    fixedCost.CostCategoryId = fixedCost.CostCategory.Id;

                    _fixedCostService.add(fixedCost);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Feminino, "Gasto Mensal");
                }

                if(_fixedCostService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = fixedCost;
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}
