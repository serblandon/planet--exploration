using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs;
using PlanetExploration.PlanetExploration.Core.Models;
using PlanetExploration.PlanetExploration.Logic.Planet.Commands.AddPlanet;
using PlanetExploration.PlanetExploration.Logic.Planet.Commands.DeletePlanet;
using PlanetExploration.PlanetExploration.Logic.Planet.Commands.UpdatePlanet;
using PlanetExploration.PlanetExploration.Logic.Planet.Queries.GetAllPlanets;
using System.Net;

namespace PlanetExploration.PlanetExploration.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PlanetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<Planet>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPlanets()
        {
            var response = await _mediator.Send(new GetAllPlanetsQuery());

            return Ok(response);
        }
        #endregion

        #region Add
        [HttpPost]
        [ProducesResponseType(typeof(Planet), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddPlanetAsync([FromBody] AddPlanetDto planet)
        {
            var planetEntity = await _mediator.Send(new AddPlanetCommand() { Planet = planet });
            return Ok(planetEntity);
        }
        #endregion

        #region Update
        [HttpPut("{planetId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdatePlanetAsync(int planetId, [FromBody] UpdatePlanetDto planet)
        {
            await _mediator.Send(new UpdatePlanetCommand() { Id = planetId, Planet = planet });
            return Ok();
        }
        #endregion

        #region Delete
        [HttpDelete("{planetId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeletePlanetAsync(int planetId)
        {
            await _mediator.Send(new DeletePlanetCommand() { Id = planetId });
            return Ok();
        }
        #endregion
    }
}
