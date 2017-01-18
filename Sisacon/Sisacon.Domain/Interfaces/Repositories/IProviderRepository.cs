using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface IProviderRepository : IRepositoryBase<Provider>
    {
        List<Provider> getByUserId(int userId);
    }
}
