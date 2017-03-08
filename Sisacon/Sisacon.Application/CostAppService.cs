﻿using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;
using System.Collections.Generic;

namespace Sisacon.Application
{
    public class CostAppService : AppServiceBase<Cost>, ICostAppService
    {
        private readonly ICostService _costService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public CostAppService(ICostService costService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(costService)
        {
            _costService = costService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<Cost> deleteCost(int costId)
        {
            var response = new ResponseMessage<Cost>();

            try
            {
                var cost = _costService.getById(costId);

                if(cost != null)
                {
                    if(cost.validateBeforeDelete())
                    {
                        _costService.delete(cost);

                        if(_costService.commit() == 0)
                        {
                            response.Message = _crudMsgFormater.createErrorCrudMessage();
                        }
                        else
                        {
                            response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Custo Mensal");
                        }
                    }
                    else
                    {
                        response.Message = "Não é possível excluir Custos de meses anteriores, apenas o Custo Atual.";
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Cost> getCostsByUserId(int userId)
        {
            var response = new ResponseMessage<Cost>();
            response.ValueList = new List<Cost>();

            try
            {
                response.ValueList = _costService.getCostsByUserId(userId);
            }
            catch (Exception ex) 
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Cost> saveOrUpdate(Cost cost)
        {
            var response = new ResponseMessage<Cost>();

            try
            {
                if(cost.isValid())
                {
                    cost.calcCosts();

                    if(cost.Id > 0)
                    {
                        _costService.update(cost);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Custo Mensal");
                    }
                    else
                    {
                        _costService.add(cost);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Custo Mensal");
                    }
                }

                if(_costService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = cost;
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