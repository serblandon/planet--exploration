namespace PlanetExploration.PlanetExploration.Core.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public PlanetStatus Status { get; set; } = PlanetStatus.EnRoute;
        public string? ImageUrl { get; set; }
        public virtual HumanCaptain? HumanCaptain { get; set; }
        public virtual ICollection<Robot>? Robots { get; set; } = new HashSet<Robot>();
    }

    public enum PlanetStatus
    {
        EnRoute,
        OK,
        NotOK,
    }
}
