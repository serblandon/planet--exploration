using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetAllHumanCaptains
{
    public class GetAllHumanCaptainsQuery : IRequest<IEnumerable<Core.Models.HumanCaptain>>
    {
    }
}
