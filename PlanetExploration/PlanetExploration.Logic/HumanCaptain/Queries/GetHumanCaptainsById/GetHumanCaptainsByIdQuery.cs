using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetHumanCaptainsById
{
    public class GetHumanCaptainsByIdQuery : IRequest<Core.Models.HumanCaptain>
    {
        public int HumanCaptainId { get; set; }
    }
}
