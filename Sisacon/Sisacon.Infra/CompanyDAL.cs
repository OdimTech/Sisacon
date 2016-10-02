using Sisacon.Domain;
using System.Linq;
using Sisacon.Infra.Context;
using System;
using System.Data.Entity;

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
                    context.OccupationArea.Attach(company.OccupationArea);

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

        public int update(Company company)
        {
            var addedLines = 0;

            try
            {
                using (var context = new SisaconDbContext())
                {
                    context.Entry(company).State = EntityState.Modified;
                    context.Entry(company.Address).State = EntityState.Modified;
                    context.Entry(company.Contact).State = EntityState.Modified;
                    context.Entry(company.OccupationArea).State = EntityState.Modified;

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
                        .Include("OccupationArea")
                        .Include("User")
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
