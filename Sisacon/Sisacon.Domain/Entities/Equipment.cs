using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Entities
{
    public class Equipment : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_DESC = 50;

        #endregion

        #region Propeties

        public string CodEquipment { get; set; }
        public string Desc { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public decimal Valor { get; set; }
        public int LifeSpan { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public bool isValid()
        {
            var valid = true;

            return valid;
        }

        public void genereteCode()
        {
            CodEquipment = string.Format("EQP{0}", Utils.gereneteRandonNumber());
        }

        public bool validatePendencesBeforeDelete()
        {
            var valid = true;

            return valid;
        }

        #endregion
    }
}
