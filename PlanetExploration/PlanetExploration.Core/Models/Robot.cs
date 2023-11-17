namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlanetId { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
