using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Exceptions;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.DeleteHumanCaptain
{
    public class DeleteHumanCaptainCommandHandler : IRequestHandler<DeleteHumanCaptainCommand>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public DeleteHumanCaptainCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Unit> Handle(DeleteHumanCaptainCommand request, CancellationToken cancellationToken)
        {
            var humanCaptain = await _planetExplorationContext.HumanCaptains.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (humanCaptain == null)
            {
                throw new ApiException($"Human Captain with id: {request.Id} not found!");
            }

            _planetExplorationContext.Remove(humanCaptain);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
