using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class ConfigurationRepository : RepositoryBase<Configuration>, IConfigurationRepository
    {
        public Configuration getByUserId(int id)
        {
            try
            {
                return Context.Config.Where(x => x.User.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
