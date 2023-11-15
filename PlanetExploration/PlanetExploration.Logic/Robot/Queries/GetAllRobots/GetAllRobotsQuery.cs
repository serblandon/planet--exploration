using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Queries.GetAllRobots
{
    public class GetAllRobotsQuery : IRequest<IEnumerable<Core.Models.Robot>>
    {
    }
}
