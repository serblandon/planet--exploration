using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs
{
    public class AddHumanCaptainDto
    {
        public string Name { get; set; }

        public static implicit operator HumanCaptain(AddHumanCaptainDto entity)
        {
            return new()
            {
                Name = entity.Name
            };
        }
    }
}
