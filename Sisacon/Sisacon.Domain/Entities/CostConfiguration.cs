using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Entities
{
    public class CostConfiguration : BaseEntity
    {
        #region Propeties

        public decimal MaxValue { get; set; }
        public bool PreventCostOverLimit { get; set; }
        public bool IncludDevaluationOfEquipment { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public void createDefaultConfiguration(User user)
        {
            try
            {
                MaxValue = 0;
                PreventCostOverLimit = false;
                IncludDevaluationOfEquipment = true;
                User = user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
