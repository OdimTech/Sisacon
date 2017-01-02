using System.Collections.Generic;
using System.Net;

namespace Sisacon.Application
{
    public class ResponseMessage<T> where T : class
    {
        public ResponseMessage()
        {
            StatusCode = HttpStatusCode.OK;
            LogicalTest = false;
        }

        public int Quantity { get; set; }
        public T Value { get; set; }
        public List<T> ValueList { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public bool LogicalTest { get; set; }
        public bool UpdateNotifications { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResponseMessage<T> createErrorResponse()
        {
            var response = new ResponseMessage<T>();

            response.LogicalTest = false;
            response.Message = "Ops! Algo de errado aconteceu. Nossa equipe de suporte já foi informada deste erro. Favor tente novamente mais tarde.";
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return response;
        }
    }
}
