using System;
using System.Collections.Generic;

namespace Sisacon.Domain
{
    public class Cost
    {
        public int Id { get; set; }
        public DateTime ReferenceMonth { get; set; }
        public int WorkedHours { get; set; }
        public decimal Remuneration { get; set; }
        public bool IsReferenceCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostPerHour { get; set; }
        public virtual List<VariableCost> VariableCosts { get; set; }
        public virtual User User { get; set; }
    }
}
