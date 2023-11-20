using PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs;
using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs
{
    public class UpdatePlanetDto
    {
        public string Description { get; set; }
        public PlanetStatus Status { get; set; }
        public HumanCaptainPlanetDto HumanCaptain { get; set; }

        public static implicit operator Planet(UpdatePlanetDto entity)
        {
            return new()
            {
                Description = entity.Description,
                Status = entity.Status,
                HumanCaptain = entity.HumanCaptain,
            };
        }
    }
}
