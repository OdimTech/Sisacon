namespace Sisacon.Domain
{
    public class Configuration
    {
        public int Id { get; set; }
        public string DefaultPage { get; set; }
        public bool CodAutoClient { get; set; }
        public bool CodAutoProvider { get; set; }
        public bool CodAutoMaterial { get; set; }
        public bool CodAutoProduct { get; set; }
        public bool CodAutoEstimate { get; set; }
        public bool CodAutoRequest { get; set; }
        public virtual User User { get; set; }
    }
}
