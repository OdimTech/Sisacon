using Sisacon.Domain;
using Sisacon.Infra;
using System;

namespace Sisacon.BLL
{
    public class ConfigurationBLL
    {
        public ConfigurationDAL configDal { get; set; }

        public ConfigurationBLL()
        {
            configDal = new ConfigurationDAL();
        }

        public ResponseMessage<Configuration> save(Configuration config)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                response.Quantity = configDal.save(config);

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
                LogBLL<Configuration>.createLogNoResponse(ex);
            }

            return response;
        }

        public ResponseMessage<Configuration> update(Configuration config)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                response.Quantity = configDal.update(config);

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
                LogBLL<Configuration>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Configuration> getConfigurations()
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                response.ValueList.AddRange(configDal.getConfigurations());
            }
            catch(Exception ex)
            {
                LogBLL<Configuration>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Configuration> getConfiguratioByIdUser(int id)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                response.Value = configDal.getConfigurationsByUserId(id);
            }
            catch(Exception ex)
            {
                LogBLL<Configuration>.createLog(ex);
            }

            return response;
        }

        public Configuration createDefaultConfig(User user)
        {
            var config = new Configuration();

            try
            {
                config.DefaultPage = "#/initialDashBoard";
                config.CodAutoClient = true;
                config.CodAutoProvider = true;
                config.CodAutoMaterial = true;
                config.CodAutoProduct = true;
                config.CodAutoEstimate = true;
                config.CodAutoRequest = true;
                config.User = user;
            }
            catch(Exception ex)
            {
                LogBLL<Configuration>.createLog(ex);
            }
            return config;
        }
    }
}
