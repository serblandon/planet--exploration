using MediatR;
using PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Commands.AddPlanet
{
    public class AddPlanetCommand : IRequest<Core.Models.Planet>
    {
        public AddPlanetDto Planet { get; set; }
    }
}
