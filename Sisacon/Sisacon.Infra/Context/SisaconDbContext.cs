using Sisacon.Domain;
using Sisacon.Infra.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sisacon.Infra.Context
{
    class SisaconDbContext : DbContext
    {
        public SisaconDbContext() : base("SisaconConnectionString")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<OccupationArea> OccupationArea { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Configuration> Config { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Cost> Cost { get; set; }
        public DbSet<VariableCost> VariableCost { get; set; }
        public DbSet<CostConfiguration> CostConfiguration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LogMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new NotificationMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ConfigurationMap());
            modelBuilder.Configurations.Add(new ProviderMap());
            modelBuilder.Configurations.Add(new CostMap());
            modelBuilder.Configurations.Add(new VariableCostMap());
            modelBuilder.Configurations.Add(new CostConfigurationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
