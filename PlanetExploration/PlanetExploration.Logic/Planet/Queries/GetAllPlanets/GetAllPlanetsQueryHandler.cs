using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Queries.GetAllPlanets
{
    public class GetAllPlanetsQueryHandler : IRequestHandler<GetAllPlanetsQuery, IEnumerable<Core.Models.Planet>>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetAllPlanetsQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<IEnumerable<Core.Models.Planet>> Handle(GetAllPlanetsQuery request, CancellationToken cancellationToken)
        {
            return await _planetExplorationContext.Planets.ToListAsync(cancellationToken);
        }
    }
}
