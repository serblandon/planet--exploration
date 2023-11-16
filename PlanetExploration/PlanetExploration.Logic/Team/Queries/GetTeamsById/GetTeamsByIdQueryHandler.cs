using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Team.Queries.GetTeamsById
{
    public class GetTeamsByIdQueryHandler : IRequestHandler<GetTeamsByIdQuery, Core.Models.Team>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetTeamsByIdQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Core.Models.Team> Handle(GetTeamsByIdQuery request, CancellationToken cancellationToken)
        {
            var teamById = await _planetExplorationContext.Teams.Where(entry => entry.Id == request.TeamId)
                                                                                .SingleOrDefaultAsync(cancellationToken);

            return teamById;
        }
    }
}
