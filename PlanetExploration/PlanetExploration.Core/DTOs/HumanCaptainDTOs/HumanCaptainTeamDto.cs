using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs
{
    public class HumanCaptainTeamDto
    {
        public int Id { get; set; }

        public static implicit operator HumanCaptain(HumanCaptainTeamDto entity)
        {
            return new()
            {
                Id = entity.Id
            };
        }
    }
}
