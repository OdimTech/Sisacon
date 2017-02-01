using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Entities
{
    public class Material : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_DESC = 50;

        #endregion

        #region Propeties

        public string CodMaterial { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual MaterialCategory Category { get; set; }
        public virtual List<PriceResearch> ListPriceResearch { get; set; }
        public virtual User User { get; set; }

        #endregion
    }
}
