using MediatR;
using PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.AddHumanCaptain
{
    public class AddHumanCaptainCommand : IRequest<Core.Models.HumanCaptain>
    {
        public HumanCaptainDto HumanCaptain { get; set; }
    }
}
