namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Team Team { get; set; }
    }
}
