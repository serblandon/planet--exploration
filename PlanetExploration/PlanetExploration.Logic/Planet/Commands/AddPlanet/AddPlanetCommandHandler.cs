using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Commands.AddPlanet
{
    public class AddPlanetCommandHandler : IRequestHandler<AddPlanetCommand, Core.Models.Planet>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public AddPlanetCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Core.Models.Planet> Handle(AddPlanetCommand request, CancellationToken cancellationToken)
        {
            var alreadyInDataBase = await _planetExplorationContext.Planets.FirstOrDefaultAsync(u => u.Name == request.Planet.Name, cancellationToken);
            if (alreadyInDataBase != null)
            {
                throw new ApiException($"Planet with name {request.Planet.Name} already exists.");
            }

            var imageAlreadyInDataBase = await _planetExplorationContext.Planets.FirstOrDefaultAsync(u => u.ImageUrl == request.Planet.ImageUrl, cancellationToken);
            if (imageAlreadyInDataBase != null)
            {
                throw new ApiException($"Planet with this image already exists.");
            }

            Core.Models.Planet entity = request.Planet;

            await _planetExplorationContext.Planets.AddAsync(entity, cancellationToken);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
