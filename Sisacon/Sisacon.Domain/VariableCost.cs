namespace Sisacon.Domain
{
    public class VariableCost
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public decimal Value { get; set; }
        public virtual Cost Cost { get; set; }
    }
}
