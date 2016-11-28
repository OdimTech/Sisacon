using System;

namespace Sisacon.Domain
{
    public class PriceResearch : EntityBase
    {
        public decimal Price { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
