namespace Sisacon.Infra.Migrations
{
    using Domain;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.SisaconDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.SisaconDbContext context)
        {
            context.OccupationArea.AddOrUpdate(

                x => x.Description,

                new OccupationArea { Description = "Pintura" },
                new OccupationArea { Description = "Marcenaria" },
                new OccupationArea { Description = "Serralheria" },
                new OccupationArea { Description = "Alimentos" },
                new OccupationArea { Description = "Bijouterias" },
                new OccupationArea { Description = "Decora��o" });
        }
    }
}
