using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface ICostAppService : IAppServiceBase<Cost>
    {
        ResponseMessage<Cost> saveOrUpdate(Cost cost);
        ResponseMessage<Cost> deleteCost(int costId);
        ResponseMessage<Cost> getCostsByUserId(int userId);
    }
}
