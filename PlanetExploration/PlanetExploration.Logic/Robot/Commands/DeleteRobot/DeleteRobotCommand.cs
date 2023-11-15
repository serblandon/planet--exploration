using MediatR;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Commands.DeleteRobot
{
    public class DeleteRobotCommand : IRequest
    {
        public int Id { get; set; }
    }
}
