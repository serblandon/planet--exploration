using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries
{
    public class GetAllHumanCaptainsQuery : IRequest<IEnumerable<Core.Models.HumanCaptain>>
    {
    }
}
