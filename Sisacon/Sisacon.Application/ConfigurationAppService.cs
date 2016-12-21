using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;

namespace Sisacon.Application
{
    public class ConfigurationAppService : AppServiceBase<Configuration>, IConfigurationAppService
    {
        private readonly IConfigurationService _configService;

        public ConfigurationAppService(IConfigurationService serviceBase) : base(serviceBase)
        {
            _configService = serviceBase;
        }

        public ResponseMessage<Configuration> getByUserId(int id)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                response.Value = _configService.getByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseMessage<Configuration> updateConfig(Configuration config)
        {
            var response = new ResponseMessage<Configuration>();

            try
            {
                if (config.Id > 0)
                {
                    _configService.update(config);

                    response.Quantity = _configService.commit();

                    if (response.Quantity > 0)
                    {
                        response.Message = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
