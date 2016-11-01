using Sisacon.Domain;
using Sisacon.Infra;
using System;

namespace Sisacon.BLL
{
    public class CostConfigurationBLL
    {
        public CostConfigurationDAL costConfigDAL { get; set; }

        public CostConfigurationBLL()
        {
            costConfigDAL = new CostConfigurationDAL();
        }

        /// <summary>
        /// Salva uma nova configuração de custo 
        /// </summary>
        /// <param name="costConfig"></param>
        /// <returns></returns>
        public ResponseMessage<CostConfiguration> save(CostConfiguration costConfig)
        {
            var response = new ResponseMessage<CostConfiguration>();

            try
            {
                response.Quantity = costConfigDAL.save(costConfig);

                if(response.Quantity > 0)
                {
                    response.LogicalTest = true;
                }
                else
                {
                    response.LogicalTest = false;
                }
            }
            catch(Exception ex)
            {
                LogBLL<CostConfiguration>.createLog(ex);
            }

            return response;
        }

        /// <summary>
        /// Atualiza as configurações de custo 
        /// </summary>
        /// <param name="costConfig"></param>
        /// <returns></returns>
        public ResponseMessage<CostConfiguration> update(CostConfiguration costConfig)
        {
            var response = new ResponseMessage<CostConfiguration>();

            try
            {
                response.Quantity = costConfigDAL.update(costConfig);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucUpdateCostConfig;
                    response.LogicalTest = true;
                }
                else
                {
                    response.Message = Msg.ErrUpdateCostConfig;
                    response.LogicalTest = false;
                }
            }
            catch(Exception ex)
            {
                LogBLL<CostConfiguration>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<CostConfiguration> getCostConfigurationById(int id)
        {
            var response = new ResponseMessage<CostConfiguration>();

            try
            {
                response.Value = costConfigDAL.getCostConfigurationById(id);
            }
            catch(Exception ex)
            {
                return LogBLL<CostConfiguration>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<CostConfiguration> getCostsConfigurationByUserId(int userId)
        {
            var response = new ResponseMessage<CostConfiguration>();

            try
            {
                response.Value = costConfigDAL.getCostConfigurationByUserId(userId);
            }
            catch(Exception ex)
            {
                return LogBLL<CostConfiguration>.createLog(ex);
            }

            return response;
        }

        public CostConfiguration createDefaultConfig(User user)
        {
            var config = new CostConfiguration();

            try
            {
                config.MaxCost = 0;
                config.User = user;
            }
            catch(Exception ex)
            {
                LogBLL<CostConfiguration>.createLogNoResponse(ex);
            }

            return config;
        }
    }
}
