using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetExploration.PlanetExploration.Core.DTOs.RobotDTOs;
using PlanetExploration.PlanetExploration.Core.Models;
using PlanetExploration.PlanetExploration.Logic.Robot.Commands.AddRobot;
using PlanetExploration.PlanetExploration.Logic.Robot.Commands.DeleteRobot;
using PlanetExploration.PlanetExploration.Logic.Robot.Commands.UpdateRobot;
using PlanetExploration.PlanetExploration.Logic.Robot.Queries.GetAllRobots;
using PlanetExploration.PlanetExploration.Logic.Robot.Queries.GetRobotsById;
using System.Net;

namespace PlanetExploration.PlanetExploration.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RobotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Robot>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllRobots()
        {
            var response = await _mediator.Send(new GetAllRobotsQuery());

            return Ok(response);
        }

        [HttpGet("[action]/{robotId}")]
        [ProducesResponseType(typeof(Robot), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRobotsById(int robotId)
        {
            var response = await _mediator.Send(new GetRobotsByIdQuery() { RobotId = robotId });

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        #endregion

        #region Add
        [HttpPost]
        [ProducesResponseType(typeof(Robot), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddRobotAsync([FromBody] RobotDto robot)
        {
            var robotEntity = await _mediator.Send(new AddRobotCommand() { Robot = robot });
            return Ok(robotEntity);
        }
        #endregion

        #region Update
        [HttpPut("{robotId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateRobotAsync(int robotId, [FromBody] RobotDto robot)
        {
            await _mediator.Send(new UpdateRobotCommand() { Id = robotId, Robot = robot });
            return Ok();
        }
        #endregion

        #region Delete
        [HttpDelete("{robotId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteRobotAsync(int robotId)
        {
            await _mediator.Send(new DeleteRobotCommand() { Id = robotId });
            return Ok();
        }
        #endregion
    }
}
