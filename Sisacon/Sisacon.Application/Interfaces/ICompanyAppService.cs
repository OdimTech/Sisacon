using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Application.Interfaces
{
    public interface ICompanyAppService : IAppServiceBase<Company>
    {
        ResponseMessage<Company> saveOrUpdate(Company company);
        ResponseMessage<Company> getCompanyByUser(int userId);
    }
}
