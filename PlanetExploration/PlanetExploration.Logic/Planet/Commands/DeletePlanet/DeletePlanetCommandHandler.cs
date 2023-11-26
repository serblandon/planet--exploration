using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Commands.DeletePlanet
{
    public class DeletePlanetCommandHandler : IRequestHandler<DeletePlanetCommand>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public DeletePlanetCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Unit> Handle(DeletePlanetCommand request, CancellationToken cancellationToken)
        {
            var planet = await _planetExplorationContext.Planets.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (planet == null)
            {
                throw new ApiException($"Planet with id: {request.Id} not found!");
            }

            var captains = _planetExplorationContext.HumanCaptains.Where(c => c.PlanetId == request.Id);
            foreach (var captain in captains)
            {
                captain.PlanetId = null;
            }

            var robots = _planetExplorationContext.Robots.Where(c => c.PlanetId == request.Id);
            foreach (var robot in robots)
            {
                robot.PlanetId = null;
            }

            _planetExplorationContext.Remove(planet);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
