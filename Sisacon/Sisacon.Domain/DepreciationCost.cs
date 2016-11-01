namespace Sisacon.Domain
{
    public class DepreciationCost
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public decimal Value { get; set; }
        public double OperationTime { get; set; }
        public decimal CostPerMonth { get; set; }
    }
}
