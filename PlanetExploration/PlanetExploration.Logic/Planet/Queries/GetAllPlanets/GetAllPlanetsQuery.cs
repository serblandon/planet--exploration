using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Queries.GetAllPlanets
{
    public class GetAllPlanetsQuery : IRequest<IEnumerable<Core.Models.Planet>>
    {
    }
}
