using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs
{
    public class AddRobotDto
    {
        public string Name { get; set; }

        public static implicit operator Robot(AddRobotDto entity)
        {
            return new()
            {
                Name = entity.Name,
            };
        }
    }
}
