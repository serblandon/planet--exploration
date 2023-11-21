using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs
{
    public class HumanCaptainPlanetDto
    {
        public string Name { get; set; }


        public static implicit operator HumanCaptain(HumanCaptainPlanetDto entity)
        {
            return new()
            {
                Name = entity.Name,
            };
        }
    }
}
