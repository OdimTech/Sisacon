using Sisacon.BLL;
using Sisacon.Domain;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class EquipmentController : ApiController
    {
        [HttpPost]
        [Route("equip")]
        public HttpResponseMessage Save(Equipment equipment)
        {
            var response = new ResponseMessage<Equipment>();
            var equipmentBLL = new EquipmentBLL();

            if(equipment != null)
            {
                if(equipment.Id == 0)
                {
                    response = equipmentBLL.save(equipment);
                }
                else
                {
                    response = equipmentBLL.update(equipment);
                }
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("equip")]
        public HttpResponseMessage Delete(int id)
        {
            var response = new ResponseMessage<Equipment>();
            var equipmentBLL = new EquipmentBLL();

            response = equipmentBLL.delete(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("equip")]
        public HttpResponseMessage GetEquipmentByUserId(int userId)
        {
            var response = new ResponseMessage<Equipment>();
            var equipmentBLL = new EquipmentBLL();

            response = equipmentBLL.getEquipmentsByUserId(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("equip")]
        public HttpResponseMessage GetEquipmentById(int id)
        {
            var response = new ResponseMessage<Equipment>();
            var equipmentBLL = new EquipmentBLL();

            response = equipmentBLL.getEquipmentById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
