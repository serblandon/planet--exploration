using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs
{
    public class RobotDto
    {
        public string Name { get; set; }

        public static implicit operator Robot(RobotDto entity)
        {
            return new()
            {
                Name = entity.Name,
            };
        }
    }
}
