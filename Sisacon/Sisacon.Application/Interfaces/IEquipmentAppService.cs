using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface IEquipmentAppService : IAppServiceBase<Equipment>
    {
        ResponseMessage<Equipment> saveOrUpdate(Equipment equipment);
        ResponseMessage<Equipment> deleteEquipment(int equipmentId);
        ResponseMessage<Equipment> getEquipmentsByUserId(int userId);
    }
}
