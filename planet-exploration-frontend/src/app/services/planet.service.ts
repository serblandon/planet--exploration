import { Injectable } from '@angular/core';
import { IPlanet } from '../interfaces/planet';
import { HttpClient } from '@angular/common/http'
import { GenericRestApi } from '../infrastructure/generic-rest-api';

@Injectable({
  providedIn: 'root'
})
export class PlanetService extends GenericRestApi<IPlanet>{

  constructor(protected override http: HttpClient) {
    super(http, "api/Planet");
  }
}
