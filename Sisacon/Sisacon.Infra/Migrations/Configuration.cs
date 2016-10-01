namespace Sisacon.Infra.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.SisaconDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.SisaconDbContext context)
        {
            context.OccupationArea.AddOrUpdate(

                x => x.Descrption,

                new OccupationArea { Descrption = "Pintura" },
                new OccupationArea { Descrption = "Marcenaria" },
                new OccupationArea { Descrption = "Serralheria" },
                new OccupationArea { Descrption = "Alimentos" },
                new OccupationArea { Descrption = "Bijouterias" },
                new OccupationArea { Descrption = "Decoração" });
        }
    }
}
