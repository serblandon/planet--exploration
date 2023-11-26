import { Component, OnInit } from '@angular/core';
import { IPlanet } from './interfaces/planet';
import { PlanetService } from './services/planet.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

  planets: IPlanet[] = [];

  constructor(
    private planetService: PlanetService,
    private spinner: NgxSpinnerService
    ) {}

  ngOnInit(): void {
    this.spinner.show("spinnerDetails");
    this.planetService.getAll()
    .pipe(
      finalize(() => this.spinner.hide("spinnerDetails"))
    )
    .subscribe({
      next: (data: IPlanet[]) => {
        this.planets = data;
        this.spinner.hide("spinnerDetails");
      },
      error: (error) => {
        console.error('Error fetching planets:', error);
      }
    });
  }
  title = 'planet-exploration-frontend';
}
