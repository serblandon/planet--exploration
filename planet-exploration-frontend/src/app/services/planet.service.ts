import { Injectable } from '@angular/core';
import { IPlanet } from '../interfaces/planet';
import { HttpClient } from '@angular/common/http'
import { GenericRestApi } from '../infrastructure/generic-rest-api';

@Injectable({
  providedIn: 'root'
})
export class PlanetService{

  // constructor(protected override http: HttpClient) {
  //   super(http, "api/Planet");
  // }

  _baseURL: string = "api/Planet";

  constructor(private http: HttpClient) { }

  getAllPlanets() {
    return this.http.get<IPlanet[]>(this._baseURL+"/GetAllPlanets");
  }
}
