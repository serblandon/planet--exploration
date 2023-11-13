using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Core.Models;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetAllHumanCaptains
{
    public class GetAllHumanCaptainsQueryHandler : IRequestHandler<GetAllHumanCaptainsQuery, IEnumerable<Core.Models.HumanCaptain>>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetAllHumanCaptainsQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }

        public async Task<IEnumerable<Core.Models.HumanCaptain>> Handle(GetAllHumanCaptainsQuery request, CancellationToken cancellationToken)
        {
            return await _planetExplorationContext.HumanCaptains.ToListAsync(cancellationToken);
        }
    }
}
