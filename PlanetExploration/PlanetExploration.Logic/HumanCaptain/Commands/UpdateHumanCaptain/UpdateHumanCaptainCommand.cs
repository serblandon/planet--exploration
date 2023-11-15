using MediatR;
using PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.UpdateHumanCaptain
{
    public class UpdateHumanCaptainCommand : IRequest
    {
        public int Id { get; set; }
        public HumanCaptainDto HumanCaptain { get; set; }
    }
}
