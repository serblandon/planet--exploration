using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Queries.GetRobotsById
{
    public class GetRobotsByIdQuery : IRequest<Core.Models.Robot>
    {
        public int RobotId { get; set; }
    }
}
