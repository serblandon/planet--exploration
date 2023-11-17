using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs
{
    public class AddPlanetDto
    {
        public string Name { get; set; }

        public static implicit operator Planet(AddPlanetDto entity)
        {
            return new()
            {
                Name = entity.Name
            };
        }
    }
}
