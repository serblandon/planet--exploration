using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Commands.UpdatePlanet
{
    public class UpdatePlanetCommandHandler : IRequestHandler<UpdatePlanetCommand>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public UpdatePlanetCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Unit> Handle(UpdatePlanetCommand request, CancellationToken cancellationToken)
        {
            var planet = await _planetExplorationContext.Planets.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (planet == null)
            {
                throw new ApiException($"Planet with id: {request.Id} not found!");
            }

            Core.Models.Planet entity = request.Planet;

            if (!string.IsNullOrEmpty(request.Planet.Name))
            {
                planet.Name = entity.Name;
            }
            if (!string.IsNullOrEmpty(request.Planet.Status))
            {
                planet.Status = entity.Status;
            }
            if (!string.IsNullOrEmpty(request.Planet.Description))
            {
                planet.Description = entity.Description;
            }

        _planetExplorationContext.Planets.Update(planet);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
