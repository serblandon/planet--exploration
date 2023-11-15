using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.DeleteHumanCaptain
{
    public class DeleteHumanCaptainCommand : IRequest
    {
        public int Id { get; set; }
    }
}
