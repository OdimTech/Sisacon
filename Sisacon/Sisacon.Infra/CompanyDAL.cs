using Sisacon.Domain;
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
    }
}
