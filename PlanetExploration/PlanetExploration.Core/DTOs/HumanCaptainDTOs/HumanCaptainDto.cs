using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs
{
    public class HumanCaptainDto
    {
        public string Name { get; set; }

        public static implicit operator HumanCaptain(HumanCaptainDto entity)
        {
            return new()
            {
                Name = entity.Name,
            };
        }
    }
}
