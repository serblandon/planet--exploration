using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Team.Queries.GetTeamsById
{
    public class GetTeamsByIdQuery : IRequest<Core.Models.Team>
    {
        public int TeamId { get; set; }
    }
}
