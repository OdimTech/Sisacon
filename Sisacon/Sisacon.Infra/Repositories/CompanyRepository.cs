using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public override void add(Company company)
        {
            try
            {
                company.RegistrationDate = DateTime.Now;

                Context.Company.Add(company);
                Context.User.Attach(company.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Company getByUserId(int userId)
        {
            try
            {
                return Context.Company.Where(x => x.User.Id == userId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
