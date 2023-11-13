using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetHumanCaptainsById
{
    public class GetHumanCaptainsByIdQueryHandler : IRequestHandler<GetHumanCaptainsByIdQuery, Core.Models.HumanCaptain>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public GetHumanCaptainsByIdQueryHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Core.Models.HumanCaptain> Handle(GetHumanCaptainsByIdQuery request, CancellationToken cancellationToken)
        {
            var humanCaptainById = await _planetExplorationContext.HumanCaptains.Where(entry => entry.Id == request.HumanCaptainId)
                                                                                .SingleOrDefaultAsync (cancellationToken);


            return humanCaptainById;
        }
    }
}
