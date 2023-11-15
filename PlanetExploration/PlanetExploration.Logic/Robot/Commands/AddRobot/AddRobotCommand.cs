using MediatR;
using PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs;

namespace PlanetExploration.PlanetExploration.Logic.Robot.Commands.AddRobot
{
    public class AddRobotCommand : IRequest<Core.Models.Robot>
    {
        public RobotDto Robot { get; set; }
    }
}
