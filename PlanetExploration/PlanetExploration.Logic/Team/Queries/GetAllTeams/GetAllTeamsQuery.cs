using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Team.Queries.GetAllTeams
{
    public class GetAllTeamsQuery : IRequest<IEnumerable<Core.Models.Team>>
    {
    }
}
