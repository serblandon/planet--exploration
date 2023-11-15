using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Queries.GetRobotsById
{
    public class GetRobotsByIdQueryHandler : IRequestHandler<GetRobotsByIdQuery, Core.Models.Robot>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetRobotsByIdQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Core.Models.Robot> Handle(GetRobotsByIdQuery request, CancellationToken cancellationToken)
        {
            var robotById = await _planetExplorationContext.Robots.Where(entry => entry.Id == request.RobotId)
                                                                                .SingleOrDefaultAsync(cancellationToken);


            return robotById;
        }
    }
}
