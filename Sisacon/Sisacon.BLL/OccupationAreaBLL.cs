using Sisacon.Domain;
using Sisacon.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.BLL
{
    public class OccupationAreaBLL
    {
        private OccupationAreaDAL OccupationAreaDAL { get; set; }
        public OccupationAreaBLL()
        {
            OccupationAreaDAL = new OccupationAreaDAL();
        }

        public ResponseMessage<OccupationArea> getListOccupationAreas()
        {
            var response = new ResponseMessage<OccupationArea>();

            try
            {
                response.ValueList = OccupationAreaDAL.getListOccupationArea();

                if(response.ValueList.Count == 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = Msg.ErrFailedToLoadOccupation;
                }
            }
            catch (Exception ex)
            {
                LogBLL<string>.createLog(ex);
            }

            return response;
        }
    }
}
