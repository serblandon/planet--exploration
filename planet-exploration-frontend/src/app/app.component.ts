import { Component, OnInit } from '@angular/core';
import { IPlanet } from './interfaces/planet';
import { PlanetService } from './services/planet.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

  planets: IPlanet[] = [];

  constructor(private planetService: PlanetService) {}

  ngOnInit(): void {
    this.planetService.getAll().subscribe({
      next: (data: IPlanet[]) => {
        this.planets = data;
      },
      error: (error) => {
        console.error('Error fetching planets:', error);
      }
    });
  }
  title = 'planet-exploration-frontend';
}
