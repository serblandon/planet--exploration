using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.AddHumanCaptain
{
    public class AddHumanCaptainCommand : IRequest<Core.Models.HumanCaptain>
    {
        public Core.Models.HumanCaptain HumanCaptain { get; set; }
    }
}
