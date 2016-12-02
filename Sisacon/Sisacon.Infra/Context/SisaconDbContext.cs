using Sisacon.Domain.Entities;
using System.Data.Entity;

namespace Sisacon.Repositories.Context
{
    public class SisaconDbContext : DbContext
    {
        public SisaconDbContext()
            : base("SisaconConnectionString")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }
    }
}
