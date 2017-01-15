using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Entities
{
    public class Equipment
    {
        #region Propeties

        public string CodEquipment { get; set; }
        public string Desc { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public decimal Valor { get; set; }
        public int LifeSpan { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        #endregion
    }
}
