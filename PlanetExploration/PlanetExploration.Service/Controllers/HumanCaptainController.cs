﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetExploration.PlanetExploration.Core.DTOs.HumanCaptainDTOs;
using PlanetExploration.PlanetExploration.Core.Models;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.AddHumanCaptain;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.DeleteHumanCaptain;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetAllHumanCaptains;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetHumanCaptainsById;
using System.Net;

namespace PlanetExploration.PlanetExploration.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanCaptainController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HumanCaptainController(IMediator mediator)
        {
            _mediator = mediator;
        }

#region Get
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HumanCaptain>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllHumanCaptains()
        {
            var response = await _mediator.Send(new GetAllHumanCaptainsQuery());

            return Ok(response);
        }

        [HttpGet("[action]/{humanCaptainId}")]
        [ProducesResponseType(typeof(HumanCaptain), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHumanCaptainsById(int humanCaptainId)
        {
            var response = await _mediator.Send(new GetHumanCaptainsByIdQuery() { HumanCaptainId = humanCaptainId});

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
#endregion

#region Add
        [HttpPost]
        [ProducesResponseType(typeof(HumanCaptain), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddHumanCaptainAsync([FromBody] HumanCaptainPlanetDto humanCaptain)
        {
            var humanCaptainEntity = await _mediator.Send(new AddHumanCaptainCommand() { HumanCaptain = humanCaptain });
            return Ok(humanCaptainEntity);
        }
        #endregion

#region Delete
        [HttpDelete("{humanCaptainId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteHumanCaptainAsync(int humanCaptainId)
        {
            await _mediator.Send(new DeleteHumanCaptainCommand() { Id = humanCaptainId });
            return Ok();
        }
#endregion
    }
}
