using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using Sisacon.Domain.ValueObjects;
using Sisacon.Repositories.Context;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Sisacon.Infra.Migrations
{
    public class UserSeed
    {
        public static void Seed(SisaconDbContext context)
        {
            var email = new Email();
            var user = context.User.Where(x => x.Id > 0).FirstOrDefault();

            if (user == null)
            {
                email.Address = "horrander@outlook.com";

                user.Email = email;
                user.Active = true;
                user.eUserType = UserType.eUserType.Single;
                user.ExclusionDate = null;
                user.LastLogin = null;
                user.Password = "111111";
                user.RegistrationDate = DateTime.Now;
                user.ShowWellcomeMessage = true;

                context.User.Add(user);
            }
        }
    }
}
