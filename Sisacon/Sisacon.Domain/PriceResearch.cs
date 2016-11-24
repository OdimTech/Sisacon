using System;

namespace Sisacon.Domain
{
    public class PriceResearch
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime SearchDate { get; set; }
        public DateTime? ExclusionDate { get; set; }
    }
}
