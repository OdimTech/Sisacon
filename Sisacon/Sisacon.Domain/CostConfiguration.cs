namespace Sisacon.Domain
{
    public class CostConfiguration
    {
        public int Id { get; set; }
        public decimal MaxCost { get; set; }
        public virtual User  User { get; set; }
    }
}
