namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public Team? Team { get; set; }
    }
}
