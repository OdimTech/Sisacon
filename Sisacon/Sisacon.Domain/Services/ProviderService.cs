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
    public class ProviderService : ServiceBase<Provider>, IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository repository) : base(repository)
        {
            _providerRepository = repository;
        }

        public List<Provider> getByUserId(int userId)
        {
            try
            {
                return _providerRepository.getByUserId(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
