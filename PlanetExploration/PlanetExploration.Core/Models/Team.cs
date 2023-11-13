namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public HumanCaptain HumanCaptain { get; set; }
        public ICollection<Robot> Robots { get; set; }
    }
}
