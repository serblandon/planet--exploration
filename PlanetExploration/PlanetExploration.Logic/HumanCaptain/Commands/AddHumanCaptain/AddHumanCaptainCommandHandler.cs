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
            var alreadyInDataBase = await _planetExplorationContext.HumanCaptains.FirstOrDefaultAsync(u => u.Name == request.HumanCaptain.Name, cancellationToken);
            if (alreadyInDataBase != null)
            {
                throw new Exception($"Human Captain with name {request.HumanCaptain.Name} already exists.");
            }

            Core.Models.HumanCaptain entity = request.HumanCaptain;

            await _planetExplorationContext.HumanCaptains.AddAsync(entity, cancellationToken);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

    }
}
