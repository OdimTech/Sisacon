using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Repositories
{
    public class FixedCostRepository : RepositoryBase<FixedCost>, IFixedCostRepository
    {
        public override void add(FixedCost fixedCost)
        {
            try
            {
                fixedCost.Cost.ListFixedCost = null;
                fixedCost.CostCategory.User = null;

                Context.User.Attach(fixedCost.Cost.User);
                Context.Cost.Attach(fixedCost.Cost);
                Context.CostCategory.Attach(fixedCost.CostCategory);

                Context.FixedCost.Add(fixedCost);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
