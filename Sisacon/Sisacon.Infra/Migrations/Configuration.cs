namespace Sisacon.Infra.Migrations
{
    using Sisacon.Repositories.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SisaconDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SisaconDbContext context)
        {
            UserSeed.seed(context);
            OccupationAreaSeed.seed(context);
        }
    }
}
