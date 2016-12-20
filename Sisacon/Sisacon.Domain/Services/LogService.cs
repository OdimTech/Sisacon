using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Enuns;

namespace Sisacon.Domain.Services
{
    public class LogService : ServiceBase<Log>, ILogService
    {
        public LogService(IRepositoryBase<Log> repository)
            : base(repository)
        {
        }

        public List<Log> getByGravity(ErrorGravity.eErrorGravity errorGravity)
        {
            throw new NotImplementedException();
        }
    }
}
