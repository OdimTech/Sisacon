using Sisacon.Domain;
using Sisacon.Infra;
using System;

namespace Sisacon.BLL
{
    public class PriceResearchBLL : IBaseBLL<PriceResearch>
    {
        public PriceResearchDAL priceResearchDAL { get; set; }

        public PriceResearchBLL()
        {
            priceResearchDAL = new PriceResearchDAL();
        }

        public ResponseMessage<PriceResearch> save(PriceResearch price)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                response.Quantity = priceResearchDAL.save(price);

                response.Value = price;

                if(response.Quantity > 0)
                {
                    response.Message = MsgFormater.createClientCrudMessage(ValueObjects.eOperationType.Insert, ValueObjects.eSex.Feminino, "Pesquisa de Preço");
                }
                else
                {
                    response.Message = MsgFormater.createErrorCrudMessage();
                }
            }
            catch(Exception ex)
            {
                return LogBLL<PriceResearch>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<PriceResearch> update(PriceResearch price)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                response.Quantity = priceResearchDAL.update(price);

                if(response.Quantity > 0)
                {
                    response.Message = MsgFormater.createClientCrudMessage(ValueObjects.eOperationType.Update, ValueObjects.eSex.Feminino, "Pesquisa de Preço");
                }
            }
            catch(Exception ex)
            {
                return LogBLL<PriceResearch>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<PriceResearch> delete(int id)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                var price = priceResearchDAL.getPriceById(id);

                if(price != null)
                {
                    price.ExclusionDate = DateTime.Now;

                    response.Quantity = priceResearchDAL.update(price);

                    if(response.Quantity > 0)
                    {
                        response.Message = MsgFormater.createClientCrudMessage(ValueObjects.eOperationType.Delete, ValueObjects.eSex.Feminino, "Pesquisa de Preço");
                    }
                    else
                    {
                        response.Message = MsgFormater.createErrorCrudMessage();
                    }
                }
            }
            catch(Exception ex)
            {
                return LogBLL<PriceResearch>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<PriceResearch> getById(int id)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                response.Value = priceResearchDAL.getPriceById(id);
            }
            catch(Exception ex)
            {
                return LogBLL<PriceResearch>.createLog(ex);
            }

            return response;
        }

        public ResponseMessage<PriceResearch> getByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
