using Sisacon.Domain;
using Sisacon.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Infra
{
    public class CostDAL
    {
        public Cost getCostById(int idCost)
        {
            var cost = new Cost();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    cost = context.Cost
                        .Include("VariableCost")
                        .Where(x => x.Id == idCost).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return cost;
        }

        public List<Cost> getCostByUserId(int idUser)
        {
            var cost = new List<Cost>();

            try
            {
                using(var context = new SisaconDbContext())
                {
                    cost = context.Cost
                        .Include("VariableCost")
                        .Where(x => x.User.Id == idUser).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return cost;
        }
    }
}
