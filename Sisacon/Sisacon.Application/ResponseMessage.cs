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
        public HttpStatusCode StatusCode { get; set; }
    }
}
