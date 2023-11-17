using PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs;
using PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs;
using PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs;
using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.TeamDTOs
{
    public class TeamDto
    {
        public virtual HumanCaptainTeamDto HumanCaptain { get; set; }
        public virtual ICollection<RobotTeamDto> Robots { get; set; } = new HashSet<RobotTeamDto>();
        public virtual ICollection<PlanetTeamDto> Planets { get; set; } = new HashSet<PlanetTeamDto>();

        public static implicit operator Team(TeamDto entity)
        {
            return new()
            {
                HumanCaptain = entity.HumanCaptain,
                Robots = entity.Robots.Select(r => (Robot)r).ToHashSet(),
                Planets = entity.Planets.Select(p => (Planet)p).ToHashSet()
            };
        }
    }
}
