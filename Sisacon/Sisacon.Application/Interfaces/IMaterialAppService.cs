using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface IMaterialAppService : IAppServiceBase<Material>
    {
        ResponseMessage<Material> saveOrUpdate(Material Material);
        ResponseMessage<Material> deleteMaterial(int MaterialId);
        ResponseMessage<Material> getMaterialByUserId(int userId);
    }
}
