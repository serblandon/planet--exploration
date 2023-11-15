using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Commands.DeleteRobot
{
    public class DeleteRobotCommandHandler : IRequestHandler<DeleteRobotCommand>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public DeleteRobotCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Unit> Handle(DeleteRobotCommand request, CancellationToken cancellationToken)
        {
            var robot = await _planetExplorationContext.Robots.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (robot == null)
            {
                throw new ApiException($"Robot with id: {request.Id} not found!");
            }

            _planetExplorationContext.Remove(robot);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
