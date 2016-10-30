using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;

namespace Sisacon.BLL
{
    public class ProviderBLL
    {
        public ProviderDAL providerDAL { get; set; }

        public ProviderBLL()
        {
            providerDAL = new ProviderDAL();
        }

        public ResponseMessage<Provider> save(Provider provider)
        {
            var response = new ResponseMessage<Provider>();

            try
            {
                provider.RegistrationDate = DateTime.Now;
                provider.CodProvider = new AutomaticCode().createAutomaticCode(provider, provider.User.Id);

                response.Quantity = providerDAL.save(provider);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucInsertProvider;
                    response.LogicalTest = true;
                    response.Value = provider;
                }
                else
                {
                    response.Message = Msg.ErrInsertProvider;
                    response.LogicalTest = false;
                    response.Value = provider;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Provider>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Provider> update(Provider provider)
        {
            var response = new ResponseMessage<Provider>();

            try
            {
                response.Quantity = providerDAL.update(provider);

                if(response.Quantity > 0)
                {
                    response.Message = Msg.SucUpdateProvider;
                    response.LogicalTest = true;
                    response.Value = provider;
                }
                else
                {
                    response.Message = Msg.ErrInsertProvider;
                    response.LogicalTest = false;
                    response.Value = provider;
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Provider>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<List<Provider>> getProvidersByUserId(int userId)
        {
            var response = new ResponseMessage<List<Provider>>();

            try
            {
                response.Value = providerDAL.getProvidersByUserId(userId);
            }
            catch(Exception ex)
            {
                return LogBLL<List<Provider>>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Provider> getProviderById(int userId)
        {
            var response = new ResponseMessage<Provider>();

            try
            {
                response.Value = providerDAL.getProviderById(userId);
            }
            catch(Exception ex)
            {
                return LogBLL<Provider>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<Provider> delete(int idProvider)
        {
            var response = new ResponseMessage<Provider>();

            try
            {
                var provider = getProviderById(idProvider).Value;

                if(provider != null)
                {
                    provider.ExclusionDate = DateTime.Now;

                    response.Quantity = providerDAL.update(provider);

                    if(response.Quantity > 0)
                    {
                        response.Message = Msg.SucDeleteProvider;
                        response.LogicalTest = true;
                    }
                    else
                    {
                        response.Message = Msg.ErrDeleteProvider;
                        response.LogicalTest = false;
                    }
                }
            }
            catch(Exception ex)
            {
                return LogBLL<Provider>.createLog(ex);
            }

            return response;
        }
    }
}
