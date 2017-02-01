using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.ValueObjects
{
    public class PriceResearch : BaseEntity
    {
        #region Propeties

        public decimal Price { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public DateTime SearchDate { get; set; }

        #endregion
    }
}
