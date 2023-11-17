using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs
{
    public class RobotTeamDto
    {
        public int Id { get; set; }

        public static implicit operator Robot(RobotTeamDto entity)
        {
            return new()
            {
                Id = entity.Id
            };
        }
    }
}