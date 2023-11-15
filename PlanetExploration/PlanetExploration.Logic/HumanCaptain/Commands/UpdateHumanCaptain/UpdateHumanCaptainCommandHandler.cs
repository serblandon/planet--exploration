using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanetExploration.Infrastructure.Exceptions;
using PlanetExploration.PlanetExploration.Dal.Data;

namespace PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.UpdateHumanCaptain
{
    public class UpdateHumanCaptainCommandHandler : IRequestHandler<UpdateHumanCaptainCommand>
    {
        private readonly PlanetExplorationContext _planetExplorationContext;
        public UpdateHumanCaptainCommandHandler(PlanetExplorationContext planetExplorationContext)
        {
            _planetExplorationContext = planetExplorationContext;
        }
        public async Task<Unit> Handle(UpdateHumanCaptainCommand request, CancellationToken cancellationToken)
        {
            if (request.HumanCaptain.Name.IsNullOrEmpty()) 
            {
                throw new ApiException("Field Name is required!");
            }

            var humanCaptain = await _planetExplorationContext.HumanCaptains.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (humanCaptain == null)
            {
                throw new ApiException($"Human Captain with id: {request.Id} not found!");
            }

            Core.Models.HumanCaptain entity = request.HumanCaptain;


            humanCaptain.Name = entity.Name;

            _planetExplorationContext.HumanCaptains.Update(humanCaptain);
            await _planetExplorationContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
