using Sisacon.Domain.Entities;
using Sisacon.Domain.Enuns;
using Sisacon.Domain.ValueObjects;
using Sisacon.Repositories.Context;
using System;
using System.Data.Entity.Migrations;

namespace Sisacon.Infra.Migrations
{
    public class UserSeed
    {
        public static void Seed(SisaconDbContext context)
        {
            var email = new Email();
            var user = new User();

            email.Address = "horrander@outlook.com";

            user.Email = email;
            user.Active = true;
            user.eUserType = UserType.eUserType.User;
            user.ExclusionDate = null;
            user.LastLogin = null;
            user.Password = "111111";
            user.RegistrationDate = DateTime.Now;
            user.ShowWellcomeMessage = true;

            context.User.AddOrUpdate(user);
        }
    }
}
