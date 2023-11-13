namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public virtual HumanCaptain HumanCaptain { get; set; }
        public virtual ICollection<Robot> Robots { get; set; } = new HashSet<Robot>();
        public virtual ICollection<Planet> Planets { get; set; } = new HashSet<Planet>();
    }
}
