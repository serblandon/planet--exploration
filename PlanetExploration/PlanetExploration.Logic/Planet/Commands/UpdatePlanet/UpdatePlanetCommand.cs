﻿using MediatR;
using PlanetExploration.PlanetExploration.Core.DTOs.PlanetDTOs;

namespace PlanetExploration.PlanetExploration.Logic.Planet.Commands.UpdatePlanet
{
    public class UpdatePlanetCommand : IRequest
    {
        public int Id { get; set; }
        public UpdatePlanetDto Planet { get; set; }
    }
}
