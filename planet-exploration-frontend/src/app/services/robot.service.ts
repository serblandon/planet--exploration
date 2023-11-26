import { Injectable } from '@angular/core';
import { GenericRestApi } from '../infrastructure/generic-rest-api';
import { IRobot } from '../interfaces/robot';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RobotService extends GenericRestApi<IRobot>{

  constructor(protected override http: HttpClient) {
    super(http, "api/Robot");
  }
}
