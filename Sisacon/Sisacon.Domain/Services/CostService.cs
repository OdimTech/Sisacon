using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class CostService : ServiceBase<Cost>, ICostService
    {
        private readonly ICostRepository _costRepository;

        public CostService(ICostRepository costRepository) : base(costRepository)
        {
            _costRepository = costRepository;
        }

        public List<Cost> getCostsByUserId(int userId)
        {
            try
            {
                return _costRepository.getCostsByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
