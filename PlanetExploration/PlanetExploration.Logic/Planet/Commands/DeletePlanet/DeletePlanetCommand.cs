using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Commands.DeletePlanet
{
    public class DeletePlanetCommand : IRequest
    {
        public int Id { get; set; }
    }
}
