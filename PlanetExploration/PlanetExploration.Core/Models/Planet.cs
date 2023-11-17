namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public int HumanCaptainId { get; set; }
        public virtual HumanCaptain HumanCaptain { get; set; }
        public virtual ICollection<Robot> Robots { get; set; } = new HashSet<Robot>();
    }
}
