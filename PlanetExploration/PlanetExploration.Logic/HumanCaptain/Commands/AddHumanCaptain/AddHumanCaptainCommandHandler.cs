using MediatR;
using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Core.Models;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.AddHumanCaptain
{
    public class AddHumanCaptainCommandHandler : IRequestHandler<AddHumanCaptainCommand, Core.Models.HumanCaptain>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public AddHumanCaptainCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Core.Models.HumanCaptain> Handle(AddHumanCaptainCommand request, CancellationToken cancellationToken)
        {
            var alreadyInDataBase = await _planetExplorationContext.HumanCaptains.FirstOrDefaultAsync(u => u.Name.ToLower() == request.HumanCaptain.Name.ToLower(), cancellationToken);
            if (alreadyInDataBase != null)
            {
                throw new Exception($"Human Captain with name {request.HumanCaptain.Name} already exists.");
            }

            await _planetExplorationContext.HumanCaptains.AddAsync(request.HumanCaptain, cancellationToken);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return request.HumanCaptain;
        }

    }
}
