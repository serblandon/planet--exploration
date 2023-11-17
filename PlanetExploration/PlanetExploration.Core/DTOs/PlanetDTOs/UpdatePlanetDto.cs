using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs
{
    public class UpdatePlanetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public static implicit operator Planet(UpdatePlanetDto entity)
        {
            return new()
            {
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
            };
        }
    }
}
