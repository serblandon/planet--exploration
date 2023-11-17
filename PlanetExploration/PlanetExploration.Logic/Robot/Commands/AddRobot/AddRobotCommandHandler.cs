using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Commands.AddRobot
{
    public class AddRobotCommandHandler : IRequestHandler<AddRobotCommand, Core.Models.Robot>
    { 
        private readonly PlanetExplorationContext _planetExplorationContext;
        public AddRobotCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Core.Models.Robot> Handle(AddRobotCommand request, CancellationToken cancellationToken)
        {
            var alreadyInDataBase = await _planetExplorationContext.Robots.FirstOrDefaultAsync(u => u.Name == request.Robot.Name, cancellationToken);
            if (alreadyInDataBase != null)
            {
                throw new ApiException($"Robot with name {request.Robot.Name} already exists.");
            }

            Core.Models.Robot entity = request.Robot;

            await _planetExplorationContext.Robots.AddAsync(entity, cancellationToken);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
