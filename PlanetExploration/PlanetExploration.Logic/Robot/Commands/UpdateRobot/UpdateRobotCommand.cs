using MediatR;
using PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Commands.UpdateRobot
{
    public class UpdateRobotCommand : IRequest
    {
        public int Id { get; set; }
        public RobotDto Robot { get; set; }
    }
}
