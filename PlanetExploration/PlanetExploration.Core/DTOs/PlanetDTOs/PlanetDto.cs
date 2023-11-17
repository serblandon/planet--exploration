using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs
{
    public class PlanetDto
    {
        public string Name { get; set; }

        public static implicit operator Planet(PlanetDto entity)
        {
            return new()
            {
                Name = entity.Name
            };
        }
    }
}
