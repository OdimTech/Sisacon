using Sisacon.Domain;
using System.Linq;
using Sisacon.Infra.Context;
using System;

namespace Sisacon.Infra
{
    public class CompanyDAL
    {
        /// <summary>
        /// Salva uma nova empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int save(Company company)
        {
            var addedLines = 0;

            try
            {
                using (var context = new SisaconDbContext())
                {
                    context.User.Attach(company.User);

                    context.Company.Add(company);
                    addedLines = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addedLines;
        }

        /// <summary>
        /// Realiza uma busca na tabela Company, pelo usuario inforamado
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public Company getCompanyByUser(int idUser)
        {
            var company = new Company();

            try
            {
                using (var context = new SisaconDbContext())
                {
                    company = context.Company
                        .Include("Address")
                        .Include("Contact")
                        .Where(x => x.User.Id == idUser).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return company;
        }
    }
}
