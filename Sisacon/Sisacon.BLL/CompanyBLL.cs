using Sisacon.Domain;
using Sisacon.Infra;
using System;

namespace Sisacon.BLL
{
    public class CompanyBLL
    {
        public CompanyDAL companyDAL { get; set; }
        public CompanyBLL()
        {
            companyDAL = new CompanyDAL();
        }

        public ResponseMessage<Company> save(Company company)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                response.Quantity = companyDAL.save(company);

                if(response.Quantity > 0)
                {
                    response.Value = company;
                }
            }
            catch (Exception ex)
            {
                return LogBLL<Company>.createLog(ex);
            }

            return response;
        }
    }
}
