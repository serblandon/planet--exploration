using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Team.Queries.GetAllTeams
{
    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<Core.Models.Team>>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetAllTeamsQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<IEnumerable<Core.Models.Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            return await _planetExplorationContext.Teams.ToListAsync(cancellationToken);
        }
    }
}
