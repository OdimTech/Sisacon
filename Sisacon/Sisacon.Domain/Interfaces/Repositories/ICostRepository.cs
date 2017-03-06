using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface ICostRepository : IRepositoryBase<Cost>
    {
        List<Cost> getCostsByUserId(int userId);
    }
}
