﻿using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Core.Models;
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
            using var transaction = await _planetExplorationContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                if (request.Planet.Status == PlanetStatus.EnRoute)
                {
                    throw new ApiException($"This planet has been explored; a status of OK or NOTOK is expected.");
                }

                var planet = await _planetExplorationContext.Planets
                    .Include(p => p.HumanCaptain)
                    .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (planet == null)
                {
                    throw new ApiException($"Planet with id: {request.Id} not found!");
                }
                if (planet.Status is not 0)
                {
                    throw new ApiException($"Planet with id: {request.Id} has already been visited!");
                }

                var humanCaptain = await _planetExplorationContext.HumanCaptains.FirstOrDefaultAsync(h => h.Name == request.Planet.HumanCaptain.Name, cancellationToken);
                if (humanCaptain == null)
                {
                    throw new ApiException($"Human Captain with name: {request.Planet.HumanCaptain.Name} not found!");
                }

                // get all requested robot names
                var robotNames = request.Planet.Robots.Select(r => r.Name).ToList();
                // get all matching robot names from DB
                var robots = await _planetExplorationContext.Robots
                    .Where(r => robotNames.Contains(r.Name))
                    .ToListAsync(cancellationToken);
                // check if any of the requested robot with a name doesn't exist
                foreach (var requestedRobotName in robotNames)
                {
                    if (!robots.Any(r => r.Name == requestedRobotName))
                    {
                        throw new ApiException($"Robot with Name: {requestedRobotName} not found!");
                    }
                }

                if (!string.IsNullOrEmpty(request.Planet.Status.ToString()))
                {
                    planet.Status = request.Planet.Status;
                }
                if (!string.IsNullOrEmpty(request.Planet.Description))
                {
                    planet.Description = request.Planet.Description;
                }

                planet.HumanCaptain = humanCaptain;
                planet.Robots = robots;

                _planetExplorationContext.Planets.Update(planet);
                await _planetExplorationContext.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw new ApiException("An error occurred while updating the planet.", ex);
            }

            return Unit.Value;
        }
    }
}
