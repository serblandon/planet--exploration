import { Component, Input, OnInit } from '@angular/core';
import { IPlanet } from 'src/app/interfaces/planet';
import { RobotListPipe } from 'src/app/pipes/robot-list.pipe';
import { PlanetService } from 'src/app/services/planet.service';
@Component({
  selector: 'app-planet',
  templateUrl: './planet.component.html',
  styleUrls: ['./planet.component.css']
})

export class PlanetComponent{

  @Input()
  public planet!: IPlanet;

  constructor(private planetService: PlanetService) { }
}
