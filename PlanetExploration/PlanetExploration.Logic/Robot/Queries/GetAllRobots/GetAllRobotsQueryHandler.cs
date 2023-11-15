using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Queries.GetAllRobots
{
    public class GetAllRobotsQueryHandler : IRequestHandler<GetAllRobotsQuery, IEnumerable<Core.Models.Robot>>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetAllRobotsQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<IEnumerable<Core.Models.Robot>> Handle(GetAllRobotsQuery request, CancellationToken cancellationToken)
        {
            return await _planetExplorationContext.Robots.ToListAsync(cancellationToken);
        }
    }
}
