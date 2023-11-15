using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Commands.UpdateRobot
{
    public class UpdateRobotCommandHandler : IRequestHandler<UpdateRobotCommand>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public UpdateRobotCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Unit> Handle(UpdateRobotCommand request, CancellationToken cancellationToken)
        {
            if (request.Robot.Name.IsNullOrEmpty())
            {
                throw new ApiException("Field Name is required!");
            }

            var robot = await _planetExplorationContext.Robots.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (robot == null)
            {
                throw new ApiException($"Robot with id: {request.Id} not found!");
            }

            Core.Models.Robot entity = request.Robot;


            robot.Name = entity.Name;

            _planetExplorationContext.Robots.Update(robot);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
