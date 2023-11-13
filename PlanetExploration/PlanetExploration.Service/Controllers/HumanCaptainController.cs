using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetExploration.PlanetExploration.Core.Models;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Commands.AddHumanCaptain;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetAllHumanCaptains;
using PlanetExploration.PlanetExploration.Logic.HumanCaptain.Queries.GetHumanCaptainsById;
using System.Net;
using System.Security.Claims;

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

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<HumanCaptain>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllHumanCaptains()
        {
            var response = await _mediator.Send(new GetAllHumanCaptainsQuery());

            //var foundCustomers = _mapper.Map<List<CustomerGetDto>>(customers);
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

        [HttpPost]
        [ProducesResponseType(typeof(HumanCaptain), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddBingQueryAsync([FromBody] HumanCaptain humanCaptain)
        {
            var humanCaptainEntity = await _mediator.Send(new AddHumanCaptainCommand() { HumanCaptain = humanCaptain });
            return Ok(humanCaptainEntity);
        }
    }
}
